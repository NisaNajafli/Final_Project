using Application.DTOs.DesignationDto;
using Application.DTOs.ProjectDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(200, _unitOfWork.ProjectRepository.GetAll("Team,User").ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Project project = _unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return StatusCode(404);
            }
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromForm] CreateProject projectdto)
        {
            Project project = new Project()
            {
                Title = projectdto.Title,
                Description = projectdto.Description,
                Deadline = projectdto.Deadline,
            };
            _unitOfWork.ProjectRepository.Create(project);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            Project project = _unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.ProjectRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProject projectdto)
        {
            Project project = _unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return StatusCode(404);
            }
            project.Title= projectdto.Title;
            project.Description= projectdto.Description;
            project.Deadline= projectdto.Deadline;
            _unitOfWork.ProjectRepository.Update(project, id);
            await _unitOfWork.Commit();
            return Ok(project);
        }
    }
}
