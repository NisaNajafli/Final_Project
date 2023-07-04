using Application.DTOs.ExpectedExpensesDto;
using Application.DTOs.ExpectedRevenuesDto;
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
    public class ExpectedRevenuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpectedRevenuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ExpectedRevenues> revenues = await _unitOfWork.ExpectedRevenuesRepository.GetAllAsync(null, "Budget");
            List<GetRevenuesDto> revenuesDtos = new List<GetRevenuesDto>();
            foreach (ExpectedRevenues revenue in revenues)
            {
                revenuesDtos.Add(new GetRevenuesDto()
                {
                    Id = revenue.Id,
                    BudgetId = revenue.BudgetId,
                    Amount = revenue.Amount,
                    Title = revenue.Title,
                });
            }
            return Ok(revenuesDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            ExpectedRevenues revenue = await _unitOfWork.ExpectedRevenuesRepository.GetById(id);
            if (revenue == null) return StatusCode(404);
            GetRevenuesDto getRevenuesDtos = new GetRevenuesDto()
            {
                Id = revenue.Id,
                BudgetId = revenue.BudgetId,
                Amount = revenue.Amount,
                Title = revenue.Title,
            };
            return Ok(getRevenuesDtos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] CreateExpectedRevenues revenuedto)
        {
            ExpectedRevenues revenues = new ExpectedRevenues()
            {
                Title = revenuedto.Title,
                BudgetId = revenuedto.BudgetId,
                Amount = revenuedto.Amount,
            };
            _unitOfWork.ExpectedRevenuesRepository.Create(revenues);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevenue([FromRoute] int id)
        {

            ExpectedRevenues revenues = await _unitOfWork.ExpectedRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            _unitOfWork.ExpectedRevenuesRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRevenue([FromRoute] int id, [FromBody] UpdateExpectedRevenues revenuesdto)
        {

            ExpectedRevenues revenues = await _unitOfWork.ExpectedRevenuesRepository.GetById(id);
            if (revenues == null) return StatusCode(404);
            revenues.Id = id;
            revenues.Title = revenuesdto.Title;
            revenues.BudgetId = revenuesdto.BudgetId;
            revenues.Amount = revenuesdto.Amount;
            _unitOfWork.ExpectedRevenuesRepository.Update(revenues, id);
            await _unitOfWork.Commit();
            return StatusCode(200, revenues);
        }
    }
}
