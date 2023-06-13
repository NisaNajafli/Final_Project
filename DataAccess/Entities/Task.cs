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
        }
        public string Content { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
