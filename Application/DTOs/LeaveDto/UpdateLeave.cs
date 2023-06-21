using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Entities.Leave;

namespace Application.DTOs.LeaveDto
{
    public class UpdateLeave
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int NoOfDays { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public int EmployeeId { get; set; }
    }
}
