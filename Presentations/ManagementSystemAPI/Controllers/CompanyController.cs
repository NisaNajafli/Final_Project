using Application.DTOs.CompanyDto;
using Application.DTOs.DepartmentDto;
using Application.Services.Abstracts;
using DataAccess.DataContext;
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
            List<Company> companies = await _unitOfWork.CompanyRepository.GetAllAsync();
            List<GetCompanyDto> companyDtos = new List<GetCompanyDto>();
            foreach (Company company in companies)
            {
                companyDtos.Add(new GetCompanyDto()
                {
                    Id = company.Id,
                    Name = company.Name,

                });
            }
            return Ok(companyDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetById(id);
            if (company == null)
            {
                return StatusCode(404);
            }
            GetCompanyDto companydto = new GetCompanyDto()
            {
                Id = company.Id,
                Name = company.Name,
            };
            return Ok(companydto);
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
