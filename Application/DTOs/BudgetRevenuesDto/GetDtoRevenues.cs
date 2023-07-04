using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BudgetRevenuesDto
{
    public class GetDtoRevenues
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime RevenueDate { get; set; }
        public int CompanyId { get; set; }
        public string FileUrl { get; set; }
    }
}
