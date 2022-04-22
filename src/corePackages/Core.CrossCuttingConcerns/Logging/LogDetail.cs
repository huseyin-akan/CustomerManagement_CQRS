﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; } = "";
        public string MethodName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string UserId{ get; set; } = "";

        public List<LogParameter> Parameters { get; set; } = new List<LogParameter>();
    }
}
