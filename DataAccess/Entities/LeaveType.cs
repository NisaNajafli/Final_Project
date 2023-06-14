using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class LeaveType:BaseEntity
    {
        public LeaveType()
        {
            Leaves = new HashSet<Leave>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Leave> Leaves { get; set; }  
    }
}
