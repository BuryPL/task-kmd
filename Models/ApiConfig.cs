using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ConnStringConf
    {
        public string KmdDb { get; set; }
    }
    public class ApiConfig
    {
        public ConnStringConf ConnectionStrings { get; } = new ConnStringConf();
    }
}
