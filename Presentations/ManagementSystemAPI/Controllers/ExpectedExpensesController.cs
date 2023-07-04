using Application.DTOs.ExpectedExpensesDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    public class ExpectedExpensesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpectedExpensesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ExpectedExpenses> expenses =await _unitOfWork.ExpectedExpensesRepository.GetAllAsync(null, "Budget");
            List<GetExpenseDto> expenseDtos = new List<GetExpenseDto>();
            foreach (ExpectedExpenses expense in expenses)
            {
                expenseDtos.Add(new GetExpenseDto()
                {
                    Id = expense.Id,
                    BudgetId = expense.BudgetId,
                    Amount = expense.Amount,
                    Title = expense.Title,
                });
            }
            return Ok(expenseDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            ExpectedExpenses expense = await _unitOfWork.ExpectedExpensesRepository.GetById(id);
            if (expense == null) return StatusCode(404);
            GetExpenseDto expenses = new GetExpenseDto()
            {
                Id = expense.Id,
                BudgetId = expense.BudgetId,
                Amount = expense.Amount,
                Title = expense.Title,
            };
            return Ok(expenses);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] CreateExpectedExpense expensedto)
        {
            ExpectedExpenses expense = new ExpectedExpenses()
            {
                Title = expensedto.Title,
                BudgetId = expensedto.BudgetId,
                Amount = expensedto.Amount,
            };
            _unitOfWork.ExpectedExpensesRepository.Create(expense);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {

            ExpectedExpenses expenses = await _unitOfWork.ExpectedExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            _unitOfWork.ExpectedExpensesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] int id, [FromBody] UpdateExpectedExpense expensedto)
        {

            ExpectedExpenses expenses = await _unitOfWork.ExpectedExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            expenses.Id = id;
            expenses.Title= expensedto.Title;
            expenses.BudgetId = expensedto.BudgetId;
            expenses.Amount= expensedto.Amount;
            _unitOfWork.ExpectedExpensesRepository.Update(expenses, id);
            await _unitOfWork.Commit();
            return StatusCode(200);
        }
    }
}
