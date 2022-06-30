using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMBTestApp.Connected_Services.Services.Abstract
{
    public interface IBanksService
    {
        void GetAllBanks();

        void InvokeService(string a, string b = "", string c = "");
    }
}
