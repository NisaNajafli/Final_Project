using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AttedanceDto
{
    public class EmployeeAttedanceDto
    {
        public int EmployeeID { get; set; }
        public bool IsPunch { get; set; }
        
    }
}
