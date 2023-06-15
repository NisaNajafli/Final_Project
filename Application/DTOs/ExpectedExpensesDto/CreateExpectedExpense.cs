using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpectedExpensesDto
{
    public class CreateExpectedExpense
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int BudgetId { get; set; }
    }
}
