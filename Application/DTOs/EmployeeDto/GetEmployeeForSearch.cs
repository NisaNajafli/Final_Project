using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EmployeeDto
{
    public class GetEmployeeForSearch
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal Payments { get; set; }
    }
}
