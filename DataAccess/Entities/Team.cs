using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<Employee> Employees { get; set; } 
    }
}
