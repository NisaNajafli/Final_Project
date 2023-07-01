using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string AppPassword { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
