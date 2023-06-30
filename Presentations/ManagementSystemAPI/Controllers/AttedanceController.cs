using Application.DTOs.AttedanceDto;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin",AuthenticationSchemes ="Bearer")]
    [Authorize(Roles = "Admin,Employee", AuthenticationSchemes = "Bearer")]
    public class AttedanceController : ControllerBase
    {
        private readonly ManagementDb _context;

        public AttedanceController(ManagementDb context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CheckPunch([FromForm] EmployeeAttedanceDto employedto)
        {
            EmployeeAttedance employee = new EmployeeAttedance()
            {
                EmployeeId = employedto.EmployeeID,
                IsPunch = employedto.IsPunch,
                Date=DateTime.Now,
            };
            _context.EmployeesAttedances.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
