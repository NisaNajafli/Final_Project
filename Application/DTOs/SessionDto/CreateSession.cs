using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SessionDto
{
    public class CreateSession
    {
        public string Name { get; set; }
        public DateTime PuchIn { get; set; }
        public DateTime PuchOut { get; set; }
    }
}
