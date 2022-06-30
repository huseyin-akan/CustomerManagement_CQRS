
using Singleton;

Console.WriteLine("Hello, World!");

var customerService = CustomerManager.CreateAsSingleton();
customerService.Save();




/*  --------NOTLAR------
 * Bir nesne instance'ından sadece bir kez üretip o nesne instance'ını sadece bir kez kullandığımız tasarım desenidir.
 * 
 * Mesela bir websitesinde herkese anlık kullanıcı sayısını göstermek istiyoruz. O zaman tek bir kullaniciSayisi nesnesi oluşturup birisi girince bir artırarak herkese
 * bunu gösteririz.
 * 
 * İş katmanındaki bir Manager servis nesnesini Singleton yapabilirsin.
 * 
 * Ne zaman kullanmamalıyım? : Oluşan nesne IIS tekrar başlatılmadığı sürece hep kalır. Herkes gerçekten aynı şeyi mi kullanıcak. Eğer kişiden kişiye farklı davranacaksa o zaman
 * Singleton kullanamayız. Ayrıca eğer nadir kullanılan bir nesne ise Singleton kullanıp boşuna RAM'den yer almaya gerek yok. Kullanıldığında oluşturulsun ve sonra silinsin.
 *
 * Tabi bu şekilde kullanmaya gerek yok artık. Bunun yerine Factory Tasarım Deseni kullanarak bu instance'ları üreten bir sistem yazmak daha iyi bir kullanış.
 * Fakat esasen artık IoC Container'ların gelişimi ile Factory tsarım desenine de gerek kalmadı. IoC Container'a diyoruz ki bana şu nesneden bir Singleton oluştur.
 *
 * Bir nesneyi 2 kullanıcı aynı anda isterse, Multi Threaded yapılarda bir nesnenin 2 instance'ının oluşması durumu ortaya çıkabilir. Bu durumda _locker kullanarak kitleme yapıyoruz.
 *
 */
