using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Leave : BaseAuditable
    {
        public enum LeaveStatus
        {
            New=1,
            Pending,
            Approved,
            Declined
        }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int RemainingLeaves { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int NoOfDays { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public int EmployeeId{ get; set; }
        public Employee Employee { get; set; }
    }
}
