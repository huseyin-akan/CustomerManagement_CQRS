using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class CustomerManager
    {
        private static CustomerManager _customerManager;

        static object _locker = new object();   //Oluşan instance'ı kullanım esnasında kitlemek için. Böylece aynı instance'tan bir şekilde 2 tane oluşmasını engelliyoruz.
        private CustomerManager()   //constructor'ı private yaptık çünkü dışarıdan erişimi olsun istemiyoruz. Böylece kullanmak isteyen newleyemez.
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (_locker)
            {
                if (_customerManager is null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager; 
        }

        public void Save()
        {
            Console.WriteLine("Customer has been saved");
        }
    }
}
