using Application.Services.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Conrets
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        private readonly ManagementDb _context;

        public CompanyRepository(ManagementDb context):base(context)
        {
            _context = context;
        }
    }
}
