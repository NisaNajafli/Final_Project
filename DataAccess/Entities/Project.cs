using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Project:BaseAuditable
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}
