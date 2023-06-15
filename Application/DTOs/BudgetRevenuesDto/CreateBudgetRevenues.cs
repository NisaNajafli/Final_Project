using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BudgetRevenuesDto
{
    public class CreateBudgetRevenues
    {
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime RevenueDate { get; set; }
        public int CompanyId { get; set; }
        public IFormFile AttachFile { get; set; }
    }
}
