using Application;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Security.Encryption;
using TokenOptions = Core.Security.Jwt.TokenOptions;
using Infrastructure.Contexts;
using WebAPI.Services;
using Core.Application.Services;
using Core.Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.CrossCuttingConcerns.ExceptionHandling;
using Application.Features.Todos.Commands.CreateTodoCommand;
using Application.Services.Repositories;
using Microsoft.AspNetCore.Authorization;

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

//Default Debug and Console Logger.
builder.Services.AddLogging(config =>
{
   config.AddDebug();
   config.AddConsole();
});

//FileLogger - SeriLog implementation
builder.Services.AddSingleton<LoggerServiceBase, FileLogger>();

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

app.UseCustomExceptionMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//A small demonstration of reading configuration files and using Minipal Apis
var weatherResult = builder.Configuration["MiniApiDeneme:weather"];
var tempResult = app.Configuration["MiniApiDeneme:temperature"];

ConfigurationManager cm = new();
cm.AddJsonFile("specialSettings.json"); //we can read any json files we want.
var yearResult = cm["SpecialAppSettings:Year"];

//minimal Api Get Example
app.MapGet("/MiniApiGetTest", () => "Hello World, My name is MinimalApi. And today the weather is " + weatherResult
+ " and the temperature is " + tempResult + "\n"
+ "And we are in the year : " + yearResult);

//minimal Api Post Example
app.MapPost("/MiniApiPostTest/{input}", [Authorize] (string input, CreateTodoCommand command, ITodoRepository todoRepository) => //we get input variable from root and we get command object from body
{
    //we can also use Authorize attribute as shown above.
    //ITodoRepository in the parameters are provided from services collection. This is how dependency injection work is minimal APIs.
    Console.WriteLine("Post methpd in minimal API worked!!");
    Console.WriteLine("And the comcrete instance of the dependency injected interface is : " + todoRepository.GetType() );
});

app.Run();