using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            BudgetExpenses = new HashSet<BudgetExpenses>();
            BudgetRevenues = new HashSet<BudgetRevenues>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BudgetExpenses> BudgetExpenses { get; set; }
        public ICollection<BudgetRevenues> BudgetRevenues { get; set; }
    }
}
