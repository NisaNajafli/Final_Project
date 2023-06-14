using Application.DTOs.DesignationDto;
using Application.DTOs.ProjectDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        return StatusCode(200, await _unitOfWork.ProjectRepository.GetAsync(null,"Team","User"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    Project project = await _unitOfWork.ProjectRepository.GetById(id);
        //    if (project == null)
        //    {
        //        return StatusCode(404);
        //    }
        //    return Ok(project);
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateProject([FromForm] CreateProject projectdto)
        //{
        //    List<DataAccess.Entities.Task> tasks= await _unitOfWork.TaskRepository.GetAllAsync(c=>projectdto.TaskIds.Contains(c.Id));
        //    if(projectdto.TaskIds.Count()!=tasks.Count) throw new NullReferenceException(nameof(projectdto.TaskIds));
        //    Project project = new Project()
        //    {
        //        Title = projectdto.Title,
        //        Description = projectdto.Description,
        //        Deadline = projectdto.Deadline,
        //        Tasks= tasks.ToList(),
        //        TeamId=projectdto.TeamId,
        //        TeamleaderId=projectdto.TeamLeaderId
        //    };
        //    _unitOfWork.ProjectRepository.Create(project);
        //    await _unitOfWork.Commit();
        //    return StatusCode(201);
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProject([FromRoute] int id)
        //{
        //    Project project = await _unitOfWork.ProjectRepository.GetById(id);
        //    if (project == null)
        //    {
        //        return StatusCode(404);
        //    }
        //    _unitOfWork.ProjectRepository.Delete(id);
        //    await _unitOfWork.Commit();
        //    return NoContent();
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProject projectdto)
        //{
        //    List<DataAccess.Entities.Task> tasks = await _unitOfWork.TaskRepository.GetAllAsync(c => projectdto.TaskIds.Contains(c.Id));
        //    Project project = await _unitOfWork.ProjectRepository.GetById(id);
        //    if (project == null)
        //    {
        //        return StatusCode(404);
        //    }
        //    project.Description= projectdto.Description;
        //    project.Deadline= projectdto.Deadline;
        //    project.Tasks = tasks.ToList();
        //    project.TeamId = projectdto.TeamId;
        //    project.TeamleaderId = projectdto.TeamLeaderId;
        //    _unitOfWork.ProjectRepository.Update(project, id);
        //    await _unitOfWork.Commit();
        //    return Ok(project);
        //}
    }
}
