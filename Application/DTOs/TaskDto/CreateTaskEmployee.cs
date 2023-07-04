using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TaskDto
{
    public class CreateTaskEmployee
    {
        public string Content { get; set; }
        public List<int>? EmployeeIds { get; set; }

    }
}
