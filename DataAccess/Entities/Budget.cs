using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Budget:BaseEntity
    {
        public Budget()
        {
            ExpectedRevenues=new HashSet<ExpectedRevenues>();   
            ExpectedExpenses=new HashSet<ExpectedExpenses>();
        }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue
        {
            get
            {
                if (ExpectedRevenues != null) return ExpectedRevenues.Sum(e => e.Amount);
                else return 0;
            }
        }
        public decimal TotalExpenses {
            get
            {
                if (ExpectedExpenses != null) return ExpectedExpenses.Sum(e => e.Amount);
                else return 0;
            }
        }
        public decimal Amount { get; set; }
        public ICollection<ExpectedExpenses> ExpectedExpenses { get; set; }
        public ICollection<ExpectedRevenues> ExpectedRevenues { get; set; }
        public decimal Tax { get; set; }
    }
}
