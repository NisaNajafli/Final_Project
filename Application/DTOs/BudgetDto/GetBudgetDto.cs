using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BudgetDto
{
    public class GetBudgetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal? TotalExpenses { get; set; }
        public decimal? TotalRevenues { get; set; }
    }
}
