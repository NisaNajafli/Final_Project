using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Project:BaseAuditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int TeamleaderId { get; set; }
        public User Teamleader { get; set; }
        
    }
}
