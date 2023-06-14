using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaveController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200,await _unitOfWork.LeaveRepository.GetAllAsync(null));
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Leave leave = await _unitOfWork.LeaveRepository.GetById(id);
            if(leave == null)
            {
                return StatusCode(404);
            }
            return Ok(leave);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLeave([FromForm] CreateLeave leaveDto)
        {
            Leave leave = new Leave()
            {
                LeaveTypeId = leaveDto.LeaveTypeId,
                From = leaveDto.From,
                To = leaveDto.To,
                Reason = leaveDto.Reason,
                Status = leaveDto.Status,
                NoOfDays = leaveDto.NoOfDays,
            };
            _unitOfWork.LeaveRepository.Create(leave);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave([FromRoute] int id)
        {
            Leave leave = await _unitOfWork.LeaveRepository.GetById(id);
            if (leave == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.LeaveRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLeave leavedto)
        {
            Leave leave = await _unitOfWork.LeaveRepository.GetById(id);
            if (leave == null)
            {
                return StatusCode(404);
            }
            leave.Id = id;
            leave.LeaveTypeId = leavedto.LeaveTypeId;
            leave.From= leavedto.From;
            leave.To= leavedto.To;
            leave.Reason= leavedto.Reason;
            leave.Status= leavedto.Status;
            leave.NoOfDays= leavedto.NoOfDays;
            _unitOfWork.LeaveRepository.Update(leave, id);
            await _unitOfWork.Commit();
            return Ok(leave);
        }

    }
}
