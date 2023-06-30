using Application.DTOs.DesignationDto;
using Application.DTOs.EmployeeDto;
using Application.DTOs.ProjectDto;
using Application.Services.Abstracts;
using DataAccess.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using static DataAccess.Enums.AllEnums;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Project> projects = await _unitOfWork.ProjectRepository.GetAllAsync(null, "Employees");
            List<GetProject> projectdto = new List<GetProject>();
            
            foreach (Project project in projects)
            {

                projectdto.Add(new GetProject
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    RateAmount = project.RateAmount,
                    RateType = project.Rate,
                    PriorityType = project.Priority,
                    TeamLeaderId = project.TeamleaderId,
                    ClientId = project.ClientId,
                    EmployeesId = project.Employees.Select(n => n.Id).ToList(),
                });
            }

            return Ok(projectdto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProject createProject)
        {
            Project project = new()
            {
                Name = createProject.Title,
                Description = createProject.Description,
                StartDate = createProject.StartDate,
                EndDate = createProject.EndDate,
                RateAmount = createProject.RateAmount,
                Rate = createProject.RateType,
                Priority = createProject.PriorityType,
                TeamleaderId = createProject.TeamLeaderId,
                ClientId = createProject.ClientId,
                
            };

            foreach (var EmpId in createProject.EmployeeIds)
            {
                Employee employee = await _unitOfWork.EmployeeRepository.GetAsync(n => n.Id == EmpId);

                project.Employees.Add(employee);
            }


            _unitOfWork.ProjectRepository.Create(project);
            await _unitOfWork.Commit();

            GetProject getProject = new()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                RateAmount = project.RateAmount,
                PriorityType = project.Priority,
                RateType = project.Rate,
                ClientId = project.ClientId,
                EmployeesId = project.Employees.Select(n => n.Id).ToList(),
                TeamLeaderId = project.TeamleaderId
            };

            return Ok(getProject);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Project project = await _unitOfWork.ProjectRepository.GetById(id);
            if(project == null) return NotFound();
            _unitOfWork.ProjectRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProject projectdto)
        {
            Project project = await _unitOfWork.ProjectRepository.GetAsync(n => n.Id == id, "Employees");
            if (project == null) return NotFound();
            project.StartDate = projectdto.StartDate;
            project.EndDate = projectdto.EndDate;
            project.ClientId = projectdto.ClientId;
            project.TeamleaderId = projectdto.TeamLeaderId;
            project.Name = projectdto.Name;
            project.Description = projectdto.Description;
            project.RateAmount = projectdto.RateAmount;
            project.Priority = projectdto.PriorityType;
            project.Rate = projectdto.RateType;
            project.ClientId=projectdto.ClientId;


            List<Employee> employees = new();
            foreach (var EmpId in projectdto.EmployeeIds)
            {
                Employee employee = await _unitOfWork.EmployeeRepository.GetAsync(n => n.Id == EmpId, "Projects");
                if (employee != null)
                {
                    employees.Add(employee);
                }
            }

            project.Employees = employees;
            _unitOfWork.ProjectRepository.Update(project, id);
            await _unitOfWork.Commit();
            GetProject getProject = new()
            {
                Id = id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                RateAmount = project.RateAmount,
                PriorityType = project.Priority,
                RateType = project.Rate,
                ClientId = project.ClientId,
                EmployeesId = project.Employees.Select(n => n.Id).ToList(),
                TeamLeaderId = project.TeamleaderId
            };

            return Ok(getProject);
        }
    }
}
