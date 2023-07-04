using Application.DTOs.BudgetDto;
using Application.DTOs.BudgetExpensesDto;
using Application.DTOs.ExpectedExpensesDto;
using Application.Services.Abstracts;
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
    public class BudgetExpensesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAzureFileService _azureFileService;

        public BudgetExpensesController(IUnitOfWork unitOfWork, IAzureFileService azureFileService)
        {
            _unitOfWork = unitOfWork;
            _azureFileService = azureFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BudgetExpenses> budgets = await _unitOfWork.BudgetExpensesRepository.GetAllAsync();
            List<GetDto> budgetsdto = new List<GetDto>();
            foreach (BudgetExpenses budget in budgets)
            {
                budgetsdto.Add(new GetDto()
                {
                    Id = budget.Id,
                    Amount = budget.Amount,
                    CompanyId = budget.CompanyId,
                    ExpenseDate= budget.ExpenseDate,
                    Notes = budget.Notes,
                    FileUrl=budget.FileName
                });
            }
            return Ok(budgetsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            BudgetExpenses budget = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (budget == null) return StatusCode(404);
            GetDto dto = new GetDto()
            {
                Id = budget.Id,
                Amount = budget.Amount,
                CompanyId = budget.CompanyId,
                ExpenseDate = budget.ExpenseDate,
                Notes = budget.Notes,
                FileUrl = budget.FileName,
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] CreateBudgetExpenses expensedto)
        {
            BudgetExpenses expense = new BudgetExpenses()
            {
                Amount = expensedto.Amount,
                ExpenseDate = expensedto.ExpenseDate,
                CompanyId = expensedto.CompanyId,
                Notes = expensedto.Notes,
            };
            
            expense.FileName = await _azureFileService.UploadAsync(expensedto.AttachFile);
            _unitOfWork.BudgetExpensesRepository.Create(expense);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {

            BudgetExpenses expenses = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            _unitOfWork.BudgetExpensesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] int id, [FromForm] UpdateBudgetExpenses expensedto)
        {

            BudgetExpenses expenses = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            if (expensedto.AttachFile != null)
            {
                expenses.FileName = await _azureFileService.UploadAsync(expensedto.AttachFile);
            }
            _unitOfWork.BudgetExpensesRepository.Update(expenses, id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
    }
}
