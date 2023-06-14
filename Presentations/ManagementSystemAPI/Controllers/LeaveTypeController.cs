using Application.DTOs.DepartmentDto;
using Application.DTOs.LeaveTypeDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.LeaveTypeRepository.GetAllAsync(null));
            }
            catch (Exception ex)
            {
                return  StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            LeaveType type = await _unitOfWork.LeaveTypeRepository.GetById(id);
            if (type == null)
            {
                return StatusCode(404);
            }
            return Ok(type);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLeave([FromForm] CreateLeaveType leavedto)
        {
            LeaveType leave = new LeaveType()
            {
                Type = leavedto.Type,
            };
            _unitOfWork.LeaveTypeRepository.Create(leave);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            LeaveType type= await _unitOfWork.LeaveTypeRepository.GetById(id);
            if (type == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.LeaveTypeRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLeaveType leavedto)
        {
            LeaveType leave = await _unitOfWork.LeaveTypeRepository.GetById(id);
            if (leave == null)
            {
                return StatusCode(404);
            }
            leave.Id = id;
            leave.Type = leavedto.Type;
            _unitOfWork.LeaveTypeRepository.Update(leave, id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
    }
}
