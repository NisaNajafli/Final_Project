using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Policy:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PolicyFileName { get; set; }
        [NotMapped]
        public IFormFile PolicyFile { get; set; }
    }
}
