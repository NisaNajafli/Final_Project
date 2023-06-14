using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BudgetExpenses:BaseEntity
    {
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public IFormFile AttachFile { get; set; }
    }
}
