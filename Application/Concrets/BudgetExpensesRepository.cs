using DataAccess.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrets
{
    public class BudgetExpensesRepository:Repository<BudgetExpenses>,IBudgetExpensesRepository
    {
        private readonly ManagementDb _context;

        public BudgetExpensesRepository(ManagementDb context) : base(context)
        {
            _context = context;
        }
    }
}
