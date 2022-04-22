using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Security.Encryption;
using TokenOptions = Core.Security.Jwt.TokenOptions;
using Infrastructure.Contexts;
using Application.Services;
using WebAPI.Services;
using Core.Application.Services;
using Core.Domain.Entities;
using Core.Application.Pipelines.Caching;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod() );
});

builder.Services.AddControllers();

//IoC Container Extension Methods:
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

//For Identity:
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<BaseDbContext>()
    .AddDefaultTokenProviders();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(options =>
                {
                    //Token geldiğinde hangi kontroller yapılsın ayarları:
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,          //Issuer'ı biz www.engin.com yapmıştık, o şekilde gelsin. Gelmezse hata verir.
                        ValidateAudience = true,        //Audience'ı biz www.engin.com yapmıştık, o şekilde gelsin. Gelmezse hata verir.
                        ValidateLifetime = true,        //sistemde hep login olabilsin istiyorsak burayı false yap.
                        ValidIssuer = tokenOptions.Issuer,      //appsetting.json'daki Issuer'ı verdik. Yani www.engin.com
                        ValidAudience = tokenOptions.Audience,  //appsetting.json'daki Audience'ı verdik. Yani www.engin.com
                        ValidateIssuerSigningKey = true,        // signing keyi de validate edecek.
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)    //appsettings.jsondan alıyor yine.
                    };
                });

builder.Services.AddAuthorization();

//Caching için in memory kullanmamızı sağlar.
builder.Services.AddDistributedMemoryCache();

//Caching için Reddis ile çalışmak istersen: 
//builder.Services.AddStackExchangeRedisCache(options => options.Configuration= "localhost:6379");

builder.Services.AddScoped<CacheSettings>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection Cycle'ı önlemek için.
//builder.Services.AddLazyResolution();

builder.Services.AddLogging(config =>
{
   config.AddDebug();
   config.AddConsole();
});


//Database'den gelen verinin birbirini çağırma döngüsüne girmesini engelliyor.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
