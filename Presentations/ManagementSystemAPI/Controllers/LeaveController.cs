using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee", AuthenticationSchemes = "Bearer")]
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
            List<Leave> leaves = await _unitOfWork.LeaveRepository.GetAllAsync(null, "LeaveType");
            List<GetLeave> leavesdto = new List<GetLeave>();
            foreach (Leave leave in leaves)
            {
                leavesdto.Add(new GetLeave
                {
                    Id = leave.Id,
                    LeaveTypeId = leave.LeaveTypeId,
                    From = leave.From,
                    To = leave.To,
                    Reason = leave.Reason,
                    Status = leave.Status,
                    NoOfDays = leave.NoOfDays,
                    EmployeeId = leave.EmployeeId,
                });
            }
            return Ok(leavesdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Leave leave = await _unitOfWork.LeaveRepository.GetById(id);
            if(leave == null)
            {
                return StatusCode(404);
            }
            GetLeave leavedto = new GetLeave()
            {
                Id = leave.Id,
                LeaveTypeId = leave.LeaveTypeId,
                From = leave.From,
                To = leave.To,
                Reason = leave.Reason,
                Status = leave.Status,
                NoOfDays = leave.NoOfDays,
                EmployeeId = leave.EmployeeId,
                
            };
            return Ok(leavedto);
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
                EmployeeId = leaveDto.EmployeeId,
                
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
            leave.EmployeeId= leavedto.EmployeeId;
            _unitOfWork.LeaveRepository.Update(leave, id);
            await _unitOfWork.Commit();
            return Ok(leave);
        }

    }
}
