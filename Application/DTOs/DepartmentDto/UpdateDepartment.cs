﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DepartmentDto
{
    public class UpdateDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
