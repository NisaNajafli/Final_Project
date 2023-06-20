using DataAccess.Entities;
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
    public class CreateClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        //public string Job { get; set; }
        public int CompanyId { get; set; }
        //public Genders Gender { get; set; }
       // public DateTime Brithday { get; set; }
        //public string Address { get; set; }
       // public ICollection<int>? ProjectIds { get; set; }
        //public ICollection<int>? TaskIds { get; set; }
        //public IFormFile? Image { get; set; }
    }
}
