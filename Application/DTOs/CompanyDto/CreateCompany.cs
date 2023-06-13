﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CompanyDto
{
    public class CreateCompany
    {
        public string Name { get; set; }
        public ICollection<Client>? Clients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        
    }
}