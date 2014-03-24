using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaaSAPI.Model
{
    public class ServiceCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }

        //public string Domain { get; set; }
        //public string Port { get; set; }
    }
}
