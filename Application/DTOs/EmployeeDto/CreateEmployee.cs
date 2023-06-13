using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EmployeeDto
{
    public class CreateEmployee
    {
        public string UserName { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }

    }
}
