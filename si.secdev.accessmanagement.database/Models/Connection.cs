using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si.secdev.accessmanagement.database.Models
{
    public class Connection
    {
        public string ConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public int Port { get; set; }
        public bool SSO { get; set; }
    }
}
