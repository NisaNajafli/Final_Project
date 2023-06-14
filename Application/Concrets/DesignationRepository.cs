using Application.Services.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrets
{
    public class DesignationRepository : Repository<Designation>, IDesignationReposittory
    {
        private readonly ManagementDb _context;

        public DesignationRepository(ManagementDb context) : base(context)
        {
            _context = context;
        }
    }
}
