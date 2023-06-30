using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.LeaveTypeDto
{
    public class GetLeaveType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
