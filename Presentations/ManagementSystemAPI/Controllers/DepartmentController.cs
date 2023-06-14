using Application.DTOs.DepartmentDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(200,await _unitOfWork.DepartmentRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetById(id);
            if (department == null)
            {
                return StatusCode(404);
            }
            return Ok(department);
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
            department.Name = departmentdto.Name;
            _unitOfWork.DepartmentRepository.Update(department, id);
            await _unitOfWork.Commit();
            return Ok(department);
        }

    }
}
