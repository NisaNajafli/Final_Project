using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TaxPercentage:BaseEntity
    {
        public string TaxCode { get; set; }
        public decimal Percent { get; set; }
    }
}
