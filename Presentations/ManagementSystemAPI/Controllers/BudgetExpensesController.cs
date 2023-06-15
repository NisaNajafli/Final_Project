using Application.DTOs.BudgetExpensesDto;
using Application.DTOs.ExpectedExpensesDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetExpensesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BudgetExpensesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.BudgetExpensesRepository.GetAllAsync(null, "Company"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            BudgetExpenses expenses = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            return Ok(expenses);
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
            if (!expensedto.AttachFile.CheckSize(2048) && !expensedto.AttachFile.CheckType("/image"))
            {
                return BadRequest(new
                {
                    Message = "Size or type incorrect"
                });
            }
            string FileName = await expensedto.AttachFile.Upload(_webHostEnvironment.WebRootPath, "img", "files");
            expense.FileName = FileName;
            _unitOfWork.BudgetExpensesRepository.Create(expense);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {

            BudgetExpenses expenses = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", "files", expenses.FileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
            _unitOfWork.BudgetExpensesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense([FromRoute] int id, [FromBody] UpdateBudgetExpenses expensedto)
        {

            BudgetExpenses expenses = await _unitOfWork.BudgetExpensesRepository.GetById(id);
            if (expenses == null) return StatusCode(404);
            if (expensedto.AttachFile != null)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", "files", expenses.FileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                };
                if (!expensedto.AttachFile.CheckSize(2048) && !expensedto.AttachFile.CheckType("/image"))
                {
                    return BadRequest(new
                    {
                        Message = "Size or type incorrect"
                    });
                }
                string FileName = await expensedto.AttachFile.Upload(_webHostEnvironment.WebRootPath, "img", "files");
                expenses.FileName = FileName;
            }
            _unitOfWork.BudgetExpensesRepository.Update(expenses, id);
            await _unitOfWork.Commit();
            return StatusCode(200, expenses);
        }
    }
}
