using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Project : BaseAuditable
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int TeamleaderId { get; set; }
        public User Teamleader { get; set; }
        public ICollection<Task> Tasks { get; set; }
        
    }

}
