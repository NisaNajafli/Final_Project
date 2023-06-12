using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Client:User
    {
        public Client()
        {
            Companies = new HashSet<Company>();
        }
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string FullName { get; set; }
        public string Job { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
