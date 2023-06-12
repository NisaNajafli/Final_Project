using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Designation:BaseAuditable
    {
        public Designation()
        {
            Employees=new HashSet<Employee>();
        }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
