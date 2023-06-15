using Application.DTOs.BudgetDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(200, await _unitOfWork.BudgetRepository.GetAllAsync(null, "ExpectedExpenses", "ExpectedRevenues"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Budget budget = await _unitOfWork.BudgetRepository.GetById(id);
            if (budget == null) return NotFound();
            return Ok(budget);
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

                //ExpectedExpenses = budgetdto.ExpectedExpenses.Select(c => new ExpectedExpenses { Amount = c.Amount }).ToList(),
                //ExpectedRevenues = budgetdto.ExpectedRevenues.Select(c => new ExpectedRevenues { Amount = c.Amount }).ToList(),
            };
            _unitOfWork.BudgetRepository.Create(budget);
            await _unitOfWork.Commit();
            return StatusCode(200, budget);
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
    }
}
