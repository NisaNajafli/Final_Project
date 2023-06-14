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
    public class BudgetRepository:Repository<Budget>,IBudgetRepository
    {
        private readonly ManagementDb _context;

        public BudgetRepository(ManagementDb context):base(context)
        {
            _context = context;
        }
    }
}
