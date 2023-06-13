using Application.DTOs.TaskDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = DataAccess.Entities.Task;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(200, _unitOfWork.TaskRepository.GetAll("Client").ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( [FromRoute] int id)
        {
            Task task=_unitOfWork.TaskRepository.GetById(id);
            if(task== null)
            {
                return StatusCode(404);
            }
            return Ok(task);

        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromForm]  CreateTask taskDto)
        {
            Task task = new Task
            {
                Content = taskDto.Content
            };
            _unitOfWork.TaskRepository.Create(task);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            Task task = _unitOfWork.TaskRepository.GetById(id);
            if( task== null)
            {
                return StatusCode(404);
            }
            _unitOfWork.TaskRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] UpdateTask taskDto)
        {
            Task task = _unitOfWork.TaskRepository.GetById(id);
            if (task == null)
            {
                return StatusCode(404);
            }
            task.Id = id;
            task.Content= taskDto.Content;
            _unitOfWork.TaskRepository.Update(task, id);
            await _unitOfWork.Commit();
            return Ok(task);
        }

    }
}
