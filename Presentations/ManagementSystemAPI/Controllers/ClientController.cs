using Application.DTOs.ClientDto;
using Application.DTOs.EmployeeDto;
using Application.DTOs.LeaveDto;
using Application.Services.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin,Employee", AuthenticationSchemes = "Bearer")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAzureFileService _azureFileService;
        public ClientController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager,IAzureFileService azureFileService)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _azureFileService = azureFileService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Client> clients = await _unitOfWork.ClientRepository.GetAllAsync(null, "Company");
            List<GetClient> clientsdto = new List<GetClient>();
            foreach (Client client in clients)
            {
                clientsdto.Add(new GetClient()
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    UserName = client.UserName,
                    CompanyId = (int)client.CompanyId,
                    ImageUrl = client.ImageUrl,

                });
            }
            return Ok(clientsdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(id);
            if (client == null)
            {
                return StatusCode(404);
            }
            GetClient clientdto = new GetClient()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                UserName = client.UserName,
                CompanyId = (int)client.CompanyId,
                PhoneNumber = client.PhoneNumber,
            };
            return Ok(clientdto);
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
                PhoneNumber = clientdto.PhoneNumber
            };
            client.ImageUrl = await _azureFileService.UploadAsync(clientdto.Image);
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
            client.PhoneNumber= clientdto.PhoneNumber;
            client.ImageUrl = await _azureFileService.UploadAsync(clientdto.Image);
            _unitOfWork.ClientRepository.Update(client, id);
            await _unitOfWork.Commit();
            return Ok(client);
        }

    }
}
