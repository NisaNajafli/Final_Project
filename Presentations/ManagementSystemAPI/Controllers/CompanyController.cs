using Application.DTOs.CompanyDto;
using Application.DTOs.DepartmentDto;
using Application.Services.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.CompanyRepository.GetAllAsync(null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetById(id);
            if (company == null)
            {
                return StatusCode(404);
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompany companydto)
        {
            Company company = new Company()
            {
                Name = companydto.Name,
            };

            _unitOfWork.CompanyRepository.Create(company);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetById(id);
            if (company == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.CompanyRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompany companydto)
        {
            Company company = await _unitOfWork.CompanyRepository.GetById(id);
            if (company == null)
            {
                return StatusCode(404);
            }
            company.Name = companydto.Name;
            _unitOfWork.CompanyRepository.Update(company, id);
            await _unitOfWork.Commit();
            return Ok(company);
        }
    }
}
