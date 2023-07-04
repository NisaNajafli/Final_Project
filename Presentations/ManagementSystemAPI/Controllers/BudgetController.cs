using Application.DTOs.BudgetDto;
using Application.DTOs.ClientDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin",AuthenticationSchemes ="Bearer")]
    public class BudgetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BudgetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Budget> budgets = await _unitOfWork.BudgetRepository.GetAllAsync(null, "ExpectedExpenses", "ExpectedRevenues");
            List<GetBudgetDto> budgetsdto = new List<GetBudgetDto>();
            foreach (Budget budget in budgets)
            {
                budgetsdto.Add(new GetBudgetDto()
                {
                    Id = budget.Id,
                    Title = budget.Title,
                    TaxAmount=budget.Tax,
                    StartDate=budget.StartDate,
                    EndDate=budget.EndDate,
                    TotalExpenses=budget.ExpectedExpenses.Sum(c=>c.Amount),
                    TotalRevenues=budget.ExpectedRevenues.Sum(c=>c.Amount),
                });
            }
            return Ok(budgetsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Budget budget = await _unitOfWork.BudgetRepository.GetById(id);
            if (budget == null) return NotFound();
            GetBudgetDto dto = new GetBudgetDto()
            {
                Id = budget.Id,
                Title = budget.Title,
                TaxAmount = budget.Tax,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                TotalExpenses = budget.ExpectedExpenses.Sum(c => c.Amount),
                TotalRevenues = budget.ExpectedRevenues.Sum(c => c.Amount),
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromForm] CreateBudget budgetdto)
        {
            Budget budget = new Budget()
            {
                Title = budgetdto.Title,
                StartDate = budgetdto.StartDate,
                EndDate = budgetdto.EndDate,
                Tax = budgetdto.TaxAmount,
                //ExpectedExpenses = budgetdto.ExpectedExpenses.Select(c => new ExpectedExpenses { Amount = c.Amount }).ToList(),nnnnnn
                //ExpectedRevenues = budgetdto.ExpectedRevenues.Select(c => new ExpectedRevenues { Amount = c.Amount }).ToList(),
            };
            _unitOfWork.BudgetRepository.Create(budget);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget([FromRoute] int id, [FromBody] UpdateBudget budgetdto)
        {
            Budget budget = await _unitOfWork.BudgetRepository.GetById(id);
            if (budget == null) return NotFound();
            budget.Title = budgetdto.Title;
            budget.StartDate = budgetdto.StartDate;
            budget.EndDate = budgetdto.EndDate;
            //if (budgetdto.ExpectedRevenues != null)
            //{
            //    budget.ExpectedRevenues = budgetdto.ExpectedRevenues
            //        .Select(er => new ExpectedRevenues { Amount = er.Amount })
            //        .ToList();
            //}
            //budget.TotalRevenue = budget.ExpectedRevenues.Sum(er => er.Amount);
            //if (budgetdto.ExpectedExpenses != null)
            //{
            //    budget.ExpectedExpenses = budgetdto.ExpectedExpenses
            //        .Select(er => new ExpectedExpenses { Amount = er.Amount })
            //        .ToList();
            //}
            //budget.TotalExpenses = budget.ExpectedRevenues.Sum(er => er.Amount);
            _unitOfWork.BudgetRepository.Update(budget, id);
            await _unitOfWork.Commit();
            return Ok(budget);
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget([FromRoute] int id)
        {
            Budget budget = await _unitOfWork.BudgetRepository.GetById(id);
            if (budget == null) return NotFound();
            _unitOfWork.BudgetRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
    }
}
