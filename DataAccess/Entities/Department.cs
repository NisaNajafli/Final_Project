using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Department:BaseAuditable
    {
        public Department()
        {
            Designations = new HashSet<Designation>();
        }
        public string Name { get; set; }
        public ICollection<Designation> Designations { get; set; }
    }
}
