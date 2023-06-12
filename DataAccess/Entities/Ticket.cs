using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ticket:BaseAuditable
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
