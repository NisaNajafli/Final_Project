using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ProjectDto
{
    public class CreateProject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int TeamId { get; set; }
        public int TeamLeaderId { get; set; }
    }
}
