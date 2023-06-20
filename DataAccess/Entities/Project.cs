using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Project : BaseAuditable
    {
        public enum PriorityType
        {
            High,
            Medium,
            Low
        }
        public enum RateType
        {
            Hourly,
            Fixed
        }
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RateAmount { get; set; }
        public RateType Rate { get; set; }
        public PriorityType Priority { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int TeamleaderId { get; set; }
        public User Teamleader { get; set; }
        public ICollection<Task> Tasks { get; set; }
        
    }

}
