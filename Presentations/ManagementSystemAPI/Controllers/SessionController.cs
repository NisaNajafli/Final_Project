using Application.DTOs.ProjectDto;
using Application.DTOs.SessionDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, _unitOfWork.SessionRepository.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Session session = _unitOfWork.SessionRepository.GetById(id);
            if (session == null)
            {
                return StatusCode(404);
            }
            return Ok(session);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromForm] CreateSession sessiondto)
        {
            Session session = new Session()
            {
                Name= sessiondto.Name,
                PuchIn=sessiondto.PuchIn,
                PuchOut=sessiondto.PuchOut,
            };
            _unitOfWork.SessionRepository.Create(session);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] int id)
        {
            Session session = _unitOfWork.SessionRepository.GetById(id);
            if (session == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.SessionRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSession sessiondto)
        {
            Session session = _unitOfWork.SessionRepository.GetById(id);
            if (session == null)
            {
                return StatusCode(404);
            }
            session.Name=sessiondto.Name;
            session.PuchIn = sessiondto.PuchIn;
            session.PuchOut = sessiondto.PuchOut;
            _unitOfWork.SessionRepository.Update(session, id);
            await _unitOfWork.Commit();
            return Ok(session);
        }
    }
}
