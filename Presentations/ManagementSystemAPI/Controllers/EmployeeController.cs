using Application.DTOs.AuthDto;
using Application.DTOs.CompanyDto;
using Application.DTOs.EmployeeDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
           string defaultPassword = _configuration["DefaultPassword:PasswordEmployee"];
            //Employee employee1 = new Employee()
            //{
            //    //LastName = employee.LastName,
            //    //FirstName = employee.FirstName,
            //    Email = employee.Email,
            //    UserName = employee.UserName,
            //    JoiningDate = employee.JoiningDate,
            //   // PhoneNumber = employee.Phone
            //};
            User user = await _userManager.FindByNameAsync(employee.UserName);
            if (user==null)
            {
                return BadRequest(new
                {
                    Message = "Username or password incorrect"
                });
            }
            //SignInResult resultsign = await _signInManager.PasswordSignInAsync(user, defaultPassword, false, false);
            //if (!resultsign.Succeeded)
            //{
            //    return BadRequest(new
            //    {
            //        Message = "Username or password incorrect"
            //    });
            //}
           
            bool chechPassword = await _userManager.CheckPasswordAsync(user, employee.Password);
            if (!chechPassword)
            {
                return BadRequest();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
            };
            string privateKey = _configuration["SecurityToken:securityKey"];
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            SigningCredentials signing = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: _configuration["SecurityToken:issuer"],
                audience: _configuration["SecurityToken:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signing
                );
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordEmployee employee)
        {
            Employee employee1 = (Employee)await _userManager.FindByNameAsync(employee.UserName);
            if (employee1 == null)
            {
                return NotFound();
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(employee1);
            var resetResult = await _userManager.ResetPasswordAsync(employee1, resetToken, employee.NewPassword);
            if (!resetResult.Succeeded)
            {
                return BadRequest(resetResult.Errors);
            }
            employee1.Password=employee.NewPassword;
            bool NewUserPassword = await _userManager.CheckPasswordAsync(employee1, employee.NewPassword);
            if (!NewUserPassword)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            string defaultPassword = _configuration["DefaultPassword:PasswordEmployee"];
            List<Employee> employees = await _unitOfWork.EmployeeRepository.GetAllAsync(null, "Designation", "Department", "Company");
            List<GetEmployee> employeedto = new List<GetEmployee>();
            foreach (Employee employee in employees)
            {
                employeedto.Add(new GetEmployee()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    UserName = employee.UserName,
                    Password = defaultPassword,
                    DepartmentId = (int)employee.DepartmentId,
                    DesignationId = (int)employee.DesignationId,
                    CompanyId = (int)employee.CompanyId,
                    JoiningDate = employee.JoiningDate,

                });
            }
            return Ok(employeedto);
            //try
            //{
            //    return StatusCode(200, await _unitOfWork.EmployeeRepository.GetAllAsync(null,"Designation","Department","Company"));
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
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
            string defaultPassword = _configuration["DefaultPassword:PasswordEmployee"];
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
                Password = defaultPassword
                //ConfirmPassword = employeedto.ConfirmPassword,
            };
            IdentityResult result = await _userManager.CreateAsync(employee, employee.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            //employee.CompanyId = employeedto.CompanyId;

            //SignInResult resultsign = await _signInManager.PasswordSignInAsync(employee, defaultPassword, false, false);
            //if (!resultsign.Succeeded)
            //{
            //    return BadRequest();
            //}
            //_unitOfWork.EmployeeRepository.Create(employee);
            //await _unitOfWork.Commit();
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
