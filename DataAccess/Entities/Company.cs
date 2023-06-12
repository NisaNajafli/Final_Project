using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Company:BaseAuditable
    {
        public Company()
        {
            Clients = new HashSet<Client>();
        }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
