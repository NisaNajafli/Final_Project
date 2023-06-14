using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DataAccess.Entities.Task;

namespace Application.Services.Abstracts
{
    public interface ITaskRepository:IRepository<Task>
    {
    }
}
