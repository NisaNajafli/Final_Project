using Application.DTOs.InformationDto;
using DataAccess.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee", AuthenticationSchemes = "Bearer")]
    public class InformationsController : ControllerBase
    {
        private readonly ManagementDb _context;
        private readonly IAzureFileService _fileService;
        public InformationsController(ManagementDb context, IAzureFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        
        [HttpPost]
        public async Task<IActionResult> EmployeeInfo([FromForm] EmployeeInformationDto informationdto)
        {

            Information information = new Information()
            {
                EmployeeId = informationdto.EmployeeId,
                Address = informationdto.Address,
                Birthday = informationdto.Birthday,
                IsMale = informationdto.IsMale,
                IsMarried = informationdto.IsMarried,
                Nationality = informationdto.Nationality,
                Religion = informationdto.Religion,
                NoOfChildren = informationdto.NoOfChildren,
                EmploymentOfSpouse = informationdto.EmploymentOfSpouse,
            };

            information.ImageName = await _fileService.UploadAsync(informationdto.Image);
            _context.Informations.Add(information);
            await _context.SaveChangesAsync();
            return Ok(information);
        }
    }
}
