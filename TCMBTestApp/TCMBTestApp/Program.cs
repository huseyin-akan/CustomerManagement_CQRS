using Microsoft.Extensions.DependencyInjection;
using TCMBTestApp.Connected_Services.Services.Abstract;
using TCMBTestApp.Connected_Services.Services.Concrete;
using TCMBTestApp.Connected_Services;

var services = new ServiceCollection();
ConfigureServices(services);

services
            .AddSingleton<Tester, Tester>()
            .BuildServiceProvider()
            .GetService<Tester>()
            .Test();

TCMB.bankaSubeOkuClient bankaSubeOku = new TCMB.bankaSubeOkuClient();

try
{
    var result2 = await bankaSubeOku.bankaSubeOkuAsync("BLS", "0000", "00000");
    var result = await bankaSubeOku.bankaSubeOkuAsync("TUM", "0000", "00000");
    TCMB.BLSCvp cevap = (TCMB.BLSCvp) result2.Item;
    var bankalar = cevap.banka.OrderBy(b => b.bAd);

    TCMB.TUMCvp cevap2 = (TCMB.TUMCvp)result.Item;
    var subeler = cevap2.bankaSubeleri.Where(bs => bs.sube.Any(s => s.sKd == "00001") );    

    int siraNo = 0;
    foreach (var banka in bankalar)
    {
        Console.WriteLine(siraNo + " Banka Adı:  " + banka.bAd + " ve Banka Kodu: " + banka.bKd);
        siraNo++;
    }
    siraNo = 0;
    foreach (var banka in subeler)
    {
        Console.WriteLine(siraNo + " Banka Adı:  " + banka.banka.bAd);
        siraNo++;
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());    
}


static void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<IBanksService, BanksTestService>();
}
