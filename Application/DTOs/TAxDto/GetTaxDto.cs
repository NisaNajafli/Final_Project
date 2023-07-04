using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Entities.Tax;

namespace Application.DTOs.TAxDto
{
    public class GetTaxDto
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public double Percentange { get; set; }
        public StatusType Status { get; set; }
    }
}
