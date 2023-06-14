using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ExpectedExpenses:BaseEntity
    {
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
