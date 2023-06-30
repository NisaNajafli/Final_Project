using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Enums.AllEnums;

namespace DataAccess.Entities
{
    public class Project : BaseAuditable
    {

        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RateAmount { get; set; }
        public RateType Rate { get; set; }
        public PriorityType Priority { get; set; }
        public int TeamleaderId { get; set; }
        public User Teamleader { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

}
