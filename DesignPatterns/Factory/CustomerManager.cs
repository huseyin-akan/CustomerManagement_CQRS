using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class CustomerManager
    {
        private readonly ILoggerFactory loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved Customer");
            ILogger logger = loggerFactory.CreateLoger();
            logger.Log();
        }
    }
}
