using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Company:BaseEntity
    {
        public Company()
        {
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
            BudgetExpenses = new HashSet<BudgetExpenses>();
            BudgetRevenues = new HashSet<BudgetRevenues>();
        }
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<BudgetExpenses> BudgetExpenses { get; set; }
        public ICollection<BudgetRevenues> BudgetRevenues { get; set; }
    }
}
