using Application.DTOs.ClientDto;
using Application.DTOs.EmployeeDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public ClientController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //[HttpPost("signin")]
        //public async Task<IActionResult> SignIn([FromBody] SignInClient clientdto)
        //{
        //    string defaultPassword = _configuration["DefaultPassword:PasswordClient"];
        //    Client client = new Client()
        //    {
        //        LastName = clientdto.LastName,
        //        FirstName = clientdto.FirstName,
        //        Email = clientdto.Email,
        //        UserName = clientdto.UserName,
        //        PhoneNumber = clientdto.PhoneNumber
        //    };
        //    IdentityResult result = await _userManager.CreateAsync(client, defaultPassword);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    Microsoft.AspNetCore.Identity.SignInResult resultsign = await _signInManager.PasswordSignInAsync(client, defaultPassword, false, false);
        //    if (!resultsign.Succeeded)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}
        //[HttpPost("resetpassword")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordClient clientdto)
        //{
        //    var client = await _userManager.FindByNameAsync(clientdto.UserName);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }
        //    var resettoken = await _userManager.GeneratePasswordResetTokenAsync(client);
        //    var resetResult = await _userManager.ResetPasswordAsync(client, resettoken, clientdto.NewPassword);
        //    if (!resetResult.Succeeded)
        //    {
        //        return BadRequest(resetResult.Errors);
        //    }

        //    return Ok();
        //}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(200, await _unitOfWork.ClientRepository.GetAllAsync(null, "Company"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(id);
            if (client == null)
            {
                return StatusCode(404);
            }
            return Ok(client);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromForm] CreateClient clientdto)
        {
            Client client = new Client()
            {
                UserName = clientdto.UserName,
                CompanyId = clientdto.CompanyId,
                FirstName = clientdto.FirstName,
                LastName = clientdto.LastName,
                Email = clientdto.Email,
                //Password = clientdto.Password,
                //ConfirmPassword = clientdto.ConfirmPassword,
            };
            _unitOfWork.ClientRepository.Create(client);
            await _unitOfWork.Commit();
            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(id);
            if (client == null)
            {
                return StatusCode(404);
            }
            _unitOfWork.ClientRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClient clientdto)
        {
            Client client = _unitOfWork.ClientRepository.Get("Company").FirstOrDefault(i => i.Id == id);
            if (client == null)
            {
                return StatusCode(404);
            }
            client.UserName = clientdto.UserName;
            client.CompanyId = clientdto.CompanyId;
            client.LastName = clientdto.LastName;
            client.FirstName = clientdto.FirstName;
            client.Email = clientdto.Email;
            //client.Password = clientdto.Password;
            //client.ConfirmPassword = clientdto.ConfirmPassword;
            client.PhoneNumber= clientdto.PhoneNumber;
            _unitOfWork.ClientRepository.Update(client, id);
            await _unitOfWork.Commit();
            return Ok(client);
        }

    }
}
