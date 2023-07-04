using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ExpectedRevenuesDto
{
    public class GetRevenuesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public int BudgetId { get; set; }
    }
}
