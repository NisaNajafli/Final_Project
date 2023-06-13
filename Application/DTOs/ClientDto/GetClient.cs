﻿using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Entities.Client;
using Task = DataAccess.Entities.Task;

namespace Application.DTOs.ClientDto
{
    public class GetClient
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public int CompanyId { get; set; }
        public Genders Gender { get; set; }
        public DateTime Brithday { get; set; }
        public string Address { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<Task>? Tasks { get; set; }

    }
}