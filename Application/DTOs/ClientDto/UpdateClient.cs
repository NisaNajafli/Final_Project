using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Entities.Client;
using Task = DataAccess.Entities.Task;

namespace Application.DTOs.ClientDto
{
    public class UpdateClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public IFormFile Image { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //public string? password { get; set; }
        //public string confirmpassword { get; set; }
        public string PhoneNumber { get; set; }
        //public string Job { get; set; }
        public int CompanyId { get; set; }
    }
}
