using Application.DTOs.BudgetExpensesDto;
using Application.DTOs.BudgetRevenuesDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class BudgetRevenuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BudgetRevenuesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.BudgetRevenuesRepository.GetAllAsync(null, "Company"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            return Ok(revenues);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRevenues([FromForm] CreateBudgetRevenues revenuesdto)
        {
            BudgetRevenues revenues = new BudgetRevenues()
            {
                Amount = revenuesdto.Amount,
                RevenueDate = revenuesdto.RevenueDate,
                CompanyId = revenuesdto.CompanyId,
                Notes = revenuesdto.Notes,
            };
            if (!revenuesdto.AttachFile.CheckSize(2048) && !revenuesdto.AttachFile.CheckType("/image"))
            {
                return BadRequest(new
                {
                    Message = "Size or type incorrect"
                });
            }
            string FileName = await revenuesdto.AttachFile.Upload(_webHostEnvironment.WebRootPath, "img", "files");
            revenues.FileName = FileName;
            _unitOfWork.BudgetRevenuesRepository.Create(revenues);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevenues([FromRoute] int id)
        {

            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", "files", revenues.FileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            _unitOfWork.BudgetRevenuesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRevenues([FromRoute] int id, [FromBody] UpdateBudgetRevenues revenuesdto)
        {

            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            if (revenuesdto.AttachFile != null)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", "files", revenues.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                };
                if (!revenuesdto.AttachFile.CheckSize(2048) && !revenuesdto.AttachFile.CheckType("/image"))
                {
                    return BadRequest(new
                    {
                        Message = "Size or type incorrect"
                    });
                }
                string FileName = await revenuesdto.AttachFile.Upload(_webHostEnvironment.WebRootPath, "img", "files");
                revenues.FileName = FileName;
            }
            _unitOfWork.BudgetRevenuesRepository.Update(revenues, id);
            await _unitOfWork.Commit();
            return StatusCode(200, revenues);
        }
    }
}
