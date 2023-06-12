using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Session:BaseAuditable
    {
        public Session()
        {
            Employees = new HashSet<Employee>();
        }
        public string Name { get; set; }
        public DateTime PuchIn { get; set; }
        public DateTime PuchOut { get; set;}
        public ICollection<Employee> Employees { get; set; }
    }
}
