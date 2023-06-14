using Application.Services.Abstracts;
using DataAccess.Abstracts;
using DataAccess.DataContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrets
{

    public class UnitOfWork : IUnitOfWork
    {
        readonly ManagementDb _context;
        readonly IConfiguration _configuration;


        public UnitOfWork(ManagementDb context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        private IClientRepository? _clientRepository;
        private ICompanyRepository? _companyRepository;
        private IDepartmentRepository? _departmentRepository;
        private IDesignationReposittory? _designationRepository;
        private IEmployeeRepository? _employeeRepository;
        private IProjectRepository? _projectRepository;
        private ITaskRepository? _taskRepository;
        private ILeaveRepository? _leaveRepository;
        private ISessionRepository? _sessionRepository;
        private ITicketRepository? _ticketRepository;
        private ILeaveTypeRepository? _leaveTypeRepository;
        private IBudgetRepository? _budgetReposıtory;


        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);
        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(_context);
        public IDesignationReposittory DesignationReposittory => _designationRepository ??= new DesignationRepository(_context);
        public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_context);
        public IProjectRepository ProjectRepository => _projectRepository ??= new ProjectRepository(_context);
        public ITaskRepository TaskRepository => _taskRepository ??= new TaskRepository(_context);
        public ILeaveRepository LeaveRepository => _leaveRepository ??= new LeaveRepository(_context);
        public ISessionRepository SessionRepository => _sessionRepository ??= new SessionRepository(_context);
        public ITicketRepository TicketRepository => _ticketRepository ??= new TicketRepository(_context);
        public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_context);
        public IBudgetRepository BudgetRepository => _budgetReposıtory ??= new BudgetRepository(_context);

       // public IBudgetRepository BudgetReposıtory => throw new NotImplementedException();

        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }
    }
}
