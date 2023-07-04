using Application.DTOs.ClientDto;
using Application.DTOs.DepartmentDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Department> departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            List<GetDepartmentDto> departmentsdto = new List<GetDepartmentDto>();
            foreach (Department department in departments)
            {
                departmentsdto.Add(new GetDepartmentDto()
                {
                    Id = department.Id,
                    Name = department.Name,

                });
            }
            return Ok(departmentsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return StatusCode(404);
            }
            GetDepartmentDto departmentDto = new GetDepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
            };
            return Ok(departmentDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromForm] CreateDepartment departmentdto)
        {
            Department department = new Department()
            {
                Name = departmentdto.Name,
            };
            _unitOfWork.DepartmentRepository.Create(department);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.DepartmentRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDepartment departmentdto)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return StatusCode(404);
            }
            department.Id = id;
            department.Name = departmentdto.Name;
            _unitOfWork.DepartmentRepository.Update(department, id);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }

    }
}
