using Application.DTOs.DepartmentDto;
using Application.DTOs.DesignationDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DesignationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, _unitOfWork.DesignationReposittory.GetAll("Department").ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Designation designation = _unitOfWork.DesignationReposittory.GetById(id);
            if (designation == null)
            {
                return StatusCode(404);
            }
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDesignation([FromForm] CreateDesignation designationdto)
        {
            Designation designation = new Designation()
            {
                Name = designationdto.Name,
                DepartmentId=designationdto.DepartmentId
            };
            _unitOfWork.DesignationReposittory.Create(designation);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            Designation designation = _unitOfWork.DesignationReposittory.GetById(id);
            if (designation == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.DesignationReposittory.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDesignation designationdto)
        {
            Designation designation = _unitOfWork.DesignationReposittory.GetAll("Department").FirstOrDefault(i => i.Id == id);
            if (designation == null)
            {
                return StatusCode(404);
            }
            designation.Name = designationdto.Name;
            designation.DepartmentId = designationdto.DepartmentId;
            _unitOfWork.DesignationReposittory.Update(designation, id);
            await _unitOfWork.Commit();
            return Ok(designation);
        }

    }
}
