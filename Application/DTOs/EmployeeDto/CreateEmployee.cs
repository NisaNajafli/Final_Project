﻿using DataAccess.Entities;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //public string Password { get; set; }
        //[Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
    }
}
