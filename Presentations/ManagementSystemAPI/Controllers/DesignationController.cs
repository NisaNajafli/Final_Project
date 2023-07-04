using Application.DTOs.DepartmentDto;
using Application.DTOs.DesignationDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
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
            List<Designation> designations = await _unitOfWork.DesignationReposittory.GetAllAsync(null, "Department");
            List<GetDesignationDto> designationsdto = new List<GetDesignationDto>();
            foreach (Designation designation in designations)
            {
                designationsdto.Add(new GetDesignationDto()
                {
                    Id=designation.Id,
                    Name= designation.Name,
                    DepartmentName=designation.Department.Name,
                    DepartmentId=designation.Department.Id,
                });
            }
            return Ok(designationsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Designation designation = _unitOfWork.DesignationReposittory.Get("Department").FirstOrDefault(c=>c.Id==id);
            if (designation == null)
            {
                return StatusCode(404);
            }
            GetDesignationDto designationDto = new GetDesignationDto()
            {
                Id = designation.Id,
                Name = designation.Name,
                DepartmentName = designation.Department.Name,
                DepartmentId = designation.Department.Id,
            };
            return Ok(designationDto);
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
            Designation designation = await _unitOfWork.DesignationReposittory.GetById(id);
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
            Designation designation = await _unitOfWork.DesignationReposittory.GetAsync(null,"Department");
            if (designation == null)
            {
                return StatusCode(404);
            }
            designation.Name = designationdto.Name;
            designation.DepartmentId = designationdto.DepartmentId;
            _unitOfWork.DesignationReposittory.Update(designation, id);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }

    }
}
