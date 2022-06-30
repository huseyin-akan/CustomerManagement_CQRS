using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMBTestApp.Connected_Services.Services.Abstract;

namespace TCMBTestApp.Connected_Services
{
    public class Tester
    {
        private readonly IBanksService _banksService;

        public Tester(IBanksService banksService)
        {
            _banksService = banksService;
        }

        public void Test()
        {
            //_banksService.InvokeService("BLS");
            Console.WriteLine("Tester works");
        }
    }
}
