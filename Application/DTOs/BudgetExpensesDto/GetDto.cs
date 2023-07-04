using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BudgetExpensesDto
{
    public class GetDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CompanyId { get; set; }
        public string FileUrl { get; set; }
    }
}
