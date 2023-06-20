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
            Employees = new HashSet<Employee>();
        }
        public string Name { get; set; }
        public ICollection<Designation> Designations { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Policy> Policies { get; set; }
    }
}
