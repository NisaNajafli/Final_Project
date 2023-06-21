using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Employee:User
    {
        public Employee()
        {
            Attedances = new HashSet<EmployeeAttedance>();
            Tasks = new HashSet<Task>();
            Tickets=new HashSet<Ticket>();
            Leaves=new HashSet<Leave>();
        }
       // public string? LastName { get; set; }
       // public string? FirstName { get; set; }

        public int? DesignationId { get; set; }
        public Designation? Designation { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public ICollection<EmployeeAttedance>? Attedances { get; set; }
        public ICollection<Task>? Tasks { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Leave>? Leaves { get; set; }
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        public int InformationId { get; set; }
        public Information Information { get; set; }

    }
}
