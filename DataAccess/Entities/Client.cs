using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Client:User
    {
        public Client()
        {
            Tasks=new HashSet<Task>();  
            Projects=new HashSet<Project>();
        }
        public enum Genders
        {
            Male,
            Female
        }
        public string ImageUrl { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Job { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Genders Gender { get; set; }
        public DateTime Brithday { get; set; }
        public string Address { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Project> Projects { get; set; }
       
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
