using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BudgetDto
{
    public class UpdateBudget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TaxAmount { get; set; }
        public List<ExpectedExpenses>? ExpectedExpenses { get; set; }
        public List<ExpectedRevenues>? ExpectedRevenues { get; set; }
        public decimal? TotalRevenues
        {
            get
            {
                if (ExpectedRevenues != null) return ExpectedRevenues.Sum(e => e.Amount);
                else return 0;
            }
        }
        public decimal? TotalExpenses
        {
            get
            {
                if (ExpectedExpenses != null) return ExpectedExpenses.Sum(e => e.Amount);
                else return 0;
            }
        }
    }
}
