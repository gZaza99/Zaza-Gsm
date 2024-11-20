using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZazaGSM_Moblie.Models
{
    public class Settings
    {
        public Settings(string a, string n, string u, string p, int t = 15)
        {
            this.DbAddress = a;
            this.DbName = n;
            this.UsrName = u;
            this.UsrPassword = p;
            this.ConnectionTimeout = t;
        }

        public const string DbAddressProperty = "DbAddress";
        public const string DbNameProperty = "DbName";
        public const string UsrNameProperty = "UsrName";
        public const string UsrPasswordProperty = "UsrPassword";

        public string DbAddress { get; set; }
        public string DbName { get; set; }
        public string UsrName { get; set; }
        public string UsrPassword { get; set; }
        public int ConnectionTimeout { get; set; }

        public string ConnectionString =>
            $"Server={DbAddress};User ID={UsrName};Password={UsrPassword};Database={DbName};Connection Timeout={ConnectionTimeout}";
    }
}
