using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EmployeeDto
{
    public class SignInemployee
    {

        public string UserName { get; set; }

        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
       // public string Phone { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
