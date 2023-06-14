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
            BudgetExpenses=new HashSet<BudgetExpenses>();
            BudgetRevenues=new HashSet<BudgetRevenues>();
            ExpectedRevenues=new HashSet<ExpectedRevenues>();   
            ExpectedExpenses=new HashSet<ExpectedExpenses>();
        }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalRevenue { get; set; }  
        public decimal TotalExpenses { get; set; }
        public decimal Amount { get; set; }
        public ICollection<ExpectedExpenses> ExpectedExpenses { get; set; }
        public ICollection<ExpectedRevenues> ExpectedRevenues { get; set; }
        public ICollection<BudgetExpenses> BudgetExpenses { get; set; }
        public ICollection<BudgetRevenues> BudgetRevenues { get; set; }
        public decimal Tax { get; set; }
    }
}
