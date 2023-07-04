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
        public string ImageUrl { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Job { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Project> Projects { get; set; }
       
        [NotMapped]
        public IFormFile Image { get; set; }
        
    }
}
