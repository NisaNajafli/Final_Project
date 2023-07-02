using Application.DTOs.PaymentDto;
using Application.Services.Abstracts;
using Application.Services.PaymentService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> GetAll()
        {
            List<Payment> payments = await _unitOfWork.PaymentReposıtory.GetAllAsync(null, "Employee");
            List<GetPaymentDto> paymentsdto = new List<GetPaymentDto>();
            foreach (Payment payment in payments)
            {
                paymentsdto.Add(new GetPaymentDto
                {
                    Id = payment.Id,
                    EmployeeName=payment.Employee.UserName,
                    GrossPay=payment.GrossPay,
                    SocialSecurityTax=
                })
            }
        }
    }
}
