using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Tax:BaseEntity
    {
        public enum StatusType
        {
            Pending,
            Approved
        }
        public string TaxName { get; set; }
        public double Percentange { get; set; }
        public StatusType Status { get; set; }
    }
}
