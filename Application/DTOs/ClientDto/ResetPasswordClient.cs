using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ClientDto
{
    public class ResetPasswordClient
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; } 
    }
}
