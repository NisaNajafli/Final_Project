using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ticket:BaseAuditable
    {
        public enum PriorityType
        {
            High,
            Medium,
            Low
        }
        public enum StatusType
        {
            Open,
            Closed,
            New,
            OnHold,
            InProgress,
            Cancelled
        }
        public PriorityType Priority { get; set; }
        public StatusType Status { get; set; }
        public string Subject { get; set; }
        public string CC { get; set; }
        public string ImageName { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
