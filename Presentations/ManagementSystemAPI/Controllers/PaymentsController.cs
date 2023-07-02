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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Payment> payments = await _unitOfWork.PaymentReposıtory.GetAllAsync(null, "Employee");
            List<GetPaymentDto> paymentsdto = new List<GetPaymentDto>();
            foreach (Payment payment in payments)
            {
                paymentsdto.Add(new GetPaymentDto
                {
                    Id = payment.Id,
                    EmployeeName = payment.Employee.UserName,
                    GrossPay = payment.GrossPay,
                    SocialSecurityTax = payment.SocialSecurityTax,
                    NetPay = payment.NetPay,
                    PaymentPeriodFrom = payment.PaymentPeriodFrom,
                    PaymentPeriodTo = payment.PaymentPeriodTo,
                    EmployeeId = payment.EmployeeId,
                });
            }
            return Ok(paymentsdto);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromForm] CreatePayment paymentdto)
        {
            Payment payment = new Payment()
            {
                EmployeeId = paymentdto.EmployeeId,
                GrossPay = paymentdto.GrossPay,
                PaymentPeriodFrom = paymentdto.PaymentPeriodFrom,
                PaymentPeriodTo = paymentdto.PaymentPeriodTo,
            };
            _unitOfWork.PaymentReposıtory.Create(payment);
            await _unitOfWork.Commit();
            GetPaymentDto getPaymentDto = new GetPaymentDto()
            {
                Id = payment.Id,
                EmployeeName = payment.Employee.UserName,
                GrossPay = payment.GrossPay,
                PaymentPeriodFrom = payment.PaymentPeriodFrom,
                PaymentPeriodTo = payment.PaymentPeriodTo,
                EmployeeId = payment.EmployeeId,
                NetPay = payment.NetPay,
                SocialSecurityTax = payment.SocialSecurityTax,
            };
            return Ok(getPaymentDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            Payment payment = await _unitOfWork.PaymentReposıtory.GetById(id);
            if (payment == null) return NotFound();
            _unitOfWork.PaymentReposıtory.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment([FromBody] UpdatePayment paymentdto, [FromRoute] int id)
        {
            Payment payment =  _unitOfWork.PaymentReposıtory.Get("Employee").FirstOrDefault(c=>c.Id==id);
            if (payment == null) return NotFound(); 
            payment.EmployeeId = paymentdto.EmployeeId;
            payment.GrossPay = paymentdto.GrossPay;
            payment.PaymentPeriodFrom = paymentdto.PaymentPeriodFrom;
            payment.PaymentPeriodTo = paymentdto.PaymentPeriodTo;
            _unitOfWork.PaymentReposıtory.Update(payment, id);
            await _unitOfWork.Commit();
            return Ok();
        }
        [HttpGet("{Employee}/{Payments}")]
        public async Task<IActionResult> GetEmployeeAllPayments([FromRoute] int id)
        {
            Employee employee= await _unitOfWork.EmployeeRepository.GetById(id);
            IEnumerable<Payment> payments = (IEnumerable<Payment>)_unitOfWork.PaymentReposıtory.GetAllPaymentsForEmployee(employee.Id);
            return Ok(payments);
        }
        [HttpGet("{YtdPay}")]
        public async Task<IActionResult> GetYtdPay([FromRoute] int id)
        {
            var payment = _unitOfWork.PaymentReposıtory.GetYtdPay(id);
            return Ok(payment);
        }
    }
}
