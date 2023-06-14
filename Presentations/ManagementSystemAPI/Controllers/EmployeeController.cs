using Application.DTOs.CompanyDto;
using Application.DTOs.EmployeeDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public EmployeeController(IUnitOfWork unitOfWork, IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInemployee employee)
        {
            string defaultPassword = _configuration["DefaultPassword:Password"];
            Employee employee1 = new Employee()
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Email = employee.Email,
                UserName = employee.UserName,
                JoiningDate = employee.JoiningDate,
                PhoneNumber = employee.Phone
            };
            IdentityResult result = await _userManager.CreateAsync(employee1, defaultPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            SignInResult resultsign = await _signInManager.PasswordSignInAsync(employee1, defaultPassword, false, false);
            if (!resultsign.Succeeded)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordEmployee employee)
        {
            var employee1 = await _userManager.FindByNameAsync(employee.UserName);
            if (employee1 == null)
            {
                return NotFound();
            }
            var resettoken = await _userManager.GeneratePasswordResetTokenAsync(employee1);
            var resetResult = await _userManager.ResetPasswordAsync(employee1, resettoken, employee.NewPassword);
            if (!resetResult.Succeeded)
            {
                return BadRequest(resetResult.Errors);
            }

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.EmployeeRepository.GetAllAsync(null,"Designation","Department","Company"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Employee employee =await  _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return StatusCode(404);
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployee employeedto)
        {
            Employee employee = new Employee()
            {
                UserName = employeedto.UserName,
                DesignationId = employeedto.DesignationId,
                DepartmentId = employeedto.DepartmentId,
                CompanyId = employeedto.CompanyId,
                JoiningDate=employeedto.JoiningDate,
                FirstName = employeedto.FirstName,
                LastName = employeedto.LastName,
                Email = employeedto.Email,
                Password = employeedto.Password,
                ConfirmPassword = employeedto.ConfirmPassword,
            };
            _unitOfWork.EmployeeRepository.Create(employee);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            Employee employee =await _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.EmployeeRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployee employeedto)
        {
            Employee employee = _unitOfWork.EmployeeRepository.Get("Designation","Department","Company").FirstOrDefault(i=>i.Id==id);
            if (employee == null)
            {
                return StatusCode(404);
            }
            employee.UserName= employeedto.UserName;
            employee.DepartmentId= employeedto.DepartmentId;
            employee.DesignationId= employeedto.DesignationId;
            employee.CompanyId= employeedto.CompanyId;
            employee.LastName= employeedto.LastName;
            employee.FirstName= employeedto.FirstName;
            employee.Email= employeedto.Email;
            employee.Password= employeedto.Password;
            employee.ConfirmPassword= employeedto.ConfirmPassword;
            employee.JoiningDate= employeedto.JoiningDate;
            _unitOfWork.EmployeeRepository.Update(employee, id);
            await _unitOfWork.Commit();
            return Ok(employee);
        }

    }
}
