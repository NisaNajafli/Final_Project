using Application.DTOs.ProjectDto;
using Application.DTOs.TaskDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task = DataAccess.Entities.Task;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Task> tasks = await _unitOfWork.TaskRepository.GetAllAsync(null, "Employees");
            List<GetTaskDto> tasksDto = new List<GetTaskDto>();

            foreach (Task task in tasks)
            {

                tasksDto.Add(new GetTaskDto
                {
                    Id = task.Id,
                    Content = task.Content,
                    EmployeeIds = task.Employees.Select(n => n.Id).ToList(),
                });
            }

            return Ok(tasksDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTaskEmployee taskdto)
        {
            Task task = new()
            {
               Content = taskdto.Content,
               

            };

            foreach (var EmpId in taskdto.EmployeeIds)
            {
                Employee employee = await _unitOfWork.EmployeeRepository.GetAsync(n => n.Id == EmpId);

                task.Employees.Add(employee);
            }


            _unitOfWork.TaskRepository.Create(task);
            await _unitOfWork.Commit();

            GetTaskDto gettask = new()
            {
                Id = task.Id,
                Content = taskdto.Content,
                EmployeeIds = task.Employees.Select(n => n.Id).ToList(),
            };

            return Ok(gettask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Task task = await _unitOfWork.TaskRepository.GetById(id);
            if (task == null) return NotFound();
            _unitOfWork.TaskRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }


    }
}
