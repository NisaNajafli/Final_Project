﻿using Application.DTOs.EmployeeDto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Enums.AllEnums;

namespace Application.DTOs.ProjectDto
{
    public class CreateProject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RateAmount { get; set; }
        public RateType RateType { get; set; }
        public PriorityType PriorityType { get; set; }
        public int TeamLeaderId { get; set; }
        //public List<CreateEmployee> Employees { get; set; }
        public List<int> EmployeeIds { get; set; }
        public int ClientId { get; set; }

    }
}
