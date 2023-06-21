using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.InformationDto
{
    public class EmployeeInformationDto
    {
        public int EmployeeId { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public bool IsMarried { get; set; }
        public int EmploymentOfSpouse { get; set; }
        public int NoOfChildren { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public bool IsMale { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
