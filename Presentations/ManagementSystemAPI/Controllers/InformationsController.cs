using Application.DTOs.InformationDto;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        private readonly ManagementDb _context;

        public InformationsController(ManagementDb context)
        {
            _context = context;
        }
        //[HttpPost]
        //public async Task<IActionResult> EmployeeInfo([FromForm] EmployeeInformationDto informationdto)
        //{
            
        //    Information information = new Information()
        //    {
        //        EmployeeId = informationdto.EmployeeId,
        //        Address = informationdto.Address,
        //        Birthday = informationdto.Birthday,
        //        IsMale = informationdto.IsMale,
        //        IsMarried = informationdto.IsMarried,
        //        Nationality= informationdto.Nationality,
        //        Religion= informationdto.Religion,
        //        NoOfChildren= informationdto.NoOfChildren,
        //        EmploymentOfSpouse  =informationdto.EmploymentOfSpouse,
        //    }
        //}
    }
}
