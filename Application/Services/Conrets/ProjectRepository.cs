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
    internal class ProjectRepository:Repository<Project>,IProjectRepository
    {
        private readonly ManagementDb _context;

        public ProjectRepository(ManagementDb context) : base(context)
        {
            _context = context;
        }
    }
}
