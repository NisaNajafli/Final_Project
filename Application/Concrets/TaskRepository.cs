using Application.Services.Abstracts;
using DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DataAccess.Entities.Task;

namespace Application.Concrets
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private readonly ManagementDb _context;
        public TaskRepository(ManagementDb context) : base(context)
        {
            _context = context;
        }
    }
}
