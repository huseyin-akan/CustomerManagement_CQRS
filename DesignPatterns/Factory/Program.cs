using Factory_Method;

CustomerManager customerManager = new CustomerManager(new LoggerFactory() );
customerManager.Save();

Console.ReadLine();



/*  --------NOTLAR------
 * Amaç yazılımda sürekliliği sağlamaktır. 
 * 
 * Bir interface için, mesela bu örnekte ILogger interface'i için hangi instance'ı oluşturacağımıza karar veriyoruz.
 * İşin güzel yanı istersek belli şartlarda farklı instancelar oluşturup dönebiliriz.
 * Mesela Webconfig dosyasından okuyarak, belli durumlarda FileLogger, belli durumlarda DBLogger dönebiliriz.
 * 
 * Aslında biraz IoC Container'a benziyor. Ama burası sanırım daha özelleştirilmiş hali.
 * 
 * 
 * 
 * 
 * 
 * 
 */