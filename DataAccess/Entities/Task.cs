using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Task:BaseAuditable
    {
        public Task()
        {
            Employees = new HashSet<Employee>(); 
            Clients = new HashSet<Client>();
        }
        public string Content { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
