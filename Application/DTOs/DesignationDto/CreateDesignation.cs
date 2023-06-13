using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DesignationDto
{
    public class CreateDesignation
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
