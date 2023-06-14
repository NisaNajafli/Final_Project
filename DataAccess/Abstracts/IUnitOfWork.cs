﻿using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstracts
{
    public interface IUnitOfWork
    {
        public IClientRepository ClientRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IDesignationReposittory DesignationReposittory { get; }
        public IProjectRepository ProjectRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ILeaveRepository LeaveRepository { get; }
        public ISessionRepository SessionRepository { get; }
        public ITicketRepository TicketRepository { get; }
        public ILeaveTypeRepository LeaveTypeRepository { get; }
        public IBudgetRepository BudgetRepository { get; }
        Task Commit();
    }
}