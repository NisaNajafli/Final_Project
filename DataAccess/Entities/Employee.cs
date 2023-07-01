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
            Attendances = new HashSet<EmployeeAttedance>();
            Tasks = new HashSet<Task>();
            Tickets = new HashSet<Ticket>();
            Leaves = new HashSet<Leave>();
            Projects = new HashSet<Project>();
        }

        public int? DesignationId { get; set; }
        public Designation Designation { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;

        public ICollection<EmployeeAttedance> Attendances { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<Project> Projects { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public string State { get; set; }
        //public string SSN { get; set; } //Sosyal guvenlik numarasi
        //public DateTime CreateDateTime { get; set; }

        public ICollection<Payment> Payments { get; set; }

    }
}
