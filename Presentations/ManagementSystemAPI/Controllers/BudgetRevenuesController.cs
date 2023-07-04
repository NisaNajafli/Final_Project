using Application.DTOs.BudgetExpensesDto;
using Application.DTOs.BudgetRevenuesDto;
using Application.Services.Abstracts;
using Application.Services.FileServices;
using DataAccess.Abstracts;
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
   // [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class BudgetRevenuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAzureFileService _fileService;

        public BudgetRevenuesController(IUnitOfWork unitOfWork, IAzureFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BudgetRevenues> budgets = await _unitOfWork.BudgetRevenuesRepository.GetAllAsync();
            List<GetDtoRevenues> budgetsdto = new List<GetDtoRevenues>();
            foreach (BudgetRevenues budget in budgets)
            {
                budgetsdto.Add(new GetDtoRevenues()
                {
                    Id = budget.Id,
                    Amount = budget.Amount,
                    CompanyId = budget.CompanyId,
                    RevenueDate = budget.RevenueDate,
                    Notes = budget.Notes,
                    FileUrl = budget.FileName
                });
            }
            return Ok(budgetsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            GetDtoRevenues dto = new GetDtoRevenues()
            {
                Id = revenues.Id,
                Amount = revenues.Amount,
                CompanyId = revenues.CompanyId,
                RevenueDate = revenues.RevenueDate,
                Notes = revenues.Notes,
                FileUrl = revenues.FileName,
            };
            return Ok(dto);
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
           
            revenues.FileName = await _fileService.UploadAsync(revenuesdto.AttachFile);
            _unitOfWork.BudgetRevenuesRepository.Create(revenues);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevenues([FromRoute] int id)
        {

            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            await _fileService.DeleteAsync(revenues.FileName);
            _unitOfWork.BudgetRevenuesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRevenues([FromRoute] int id, [FromForm] UpdateBudgetRevenues revenuesdto)
        {

            BudgetRevenues revenues = await _unitOfWork.BudgetRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            if (revenuesdto.AttachFile != null)
            {
                await _fileService.DeleteAsync(revenuesdto.AttachFile.FileName);
                await _unitOfWork.Commit();
                revenues.FileName = await _fileService.UploadAsync(revenuesdto.AttachFile);
            }
            _unitOfWork.BudgetRevenuesRepository.Update(revenues, id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
    }
}
