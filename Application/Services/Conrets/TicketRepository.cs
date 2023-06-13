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
    public class TicketRepository:Repository<Ticket>,ITicketRepository
    {
        private readonly ManagementDb _context;

        public TicketRepository(ManagementDb context):base(context)
        {
            _context = context;
        }
    }
}
