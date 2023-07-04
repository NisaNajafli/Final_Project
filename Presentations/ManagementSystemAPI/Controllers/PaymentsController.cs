using Application.DTOs.EmployeeDto;
using Application.DTOs.PaymentDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            List<Payment> payments = await _unitOfWork.PaymentRepository.GetAllAsync(null, "Employee");
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
            Payment payment = new Payment(paymentdto.EmployeeId, paymentdto.GrossPay, paymentdto.PaymentPeriodFrom, paymentdto.PaymentPeriodTo);
            _unitOfWork.PaymentRepository.Create(payment);
            await _unitOfWork.Commit();
            GetPaymentDto getPaymentDto = new GetPaymentDto()
            {
                Id = payment.Id,
                EmployeeName = (await _unitOfWork.EmployeeRepository.GetById(payment.EmployeeId)).UserName,
                GrossPay = payment.GrossPay,
                PaymentPeriodFrom = payment.PaymentPeriodFrom,
                PaymentPeriodTo = payment.PaymentPeriodTo,
                EmployeeId = payment.EmployeeId,
                SocialSecurityTax=payment.SocialSecurityTax,
                NetPay = payment.NetPay,
            };
            return Ok(getPaymentDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            Payment payment = await _unitOfWork.PaymentRepository.GetById(id);
            if (payment == null) return NotFound();
            _unitOfWork.PaymentRepository.Delete(id);
            await _unitOfWork.Commit();
            return NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeAllPayments([FromRoute] int id)
        {
            Employee employee= await _unitOfWork.EmployeeRepository.GetById(id);
            GetEmployeeForSearch employeedto = new GetEmployeeForSearch()
            {
                Id = employee.Id,
                Username = employee.UserName,
                Email = employee.Email,
                Payments = employee.Payments.Sum(c => c.NetPay),
            };
            IEnumerable<Payment> payments = await _unitOfWork.PaymentRepository.GetAllPaymentsForEmployee(employeedto.Id,"Employee");
            return Ok(payments.Select(c=> new GetEmployeeForSearch()
            {
                Id = c.Id,
                Email = c.Employee.Email,
                Username= c.Employee.UserName,
                Payments = c.Employee.Payments.Sum(c => c.NetPay),
            }));
        }
        [HttpGet("/api/[controller]/[action]/{Empid:int}")]
        public async Task<IActionResult> GetYtdPay([FromRoute] int Empid)
        {
            var payment = await _unitOfWork.PaymentRepository.GetYtdPay(Empid);
            return Ok(payment);
        }
    }
}
