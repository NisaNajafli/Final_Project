using System;
using System.Collections.Generic;
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
            Projects = new HashSet<Project>();
            Tickets=new HashSet<Ticket>();
        }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public ICollection<EmployeeAttedance> Attedances { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
