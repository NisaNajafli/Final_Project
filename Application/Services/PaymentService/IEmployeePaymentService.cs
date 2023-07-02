using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Application.Services.PaymentService
{
    public interface IEmployeePaymentService
    {
        Task CreatePayment(Payment payment);
        Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(int empId);
        Task<Tuple<decimal, decimal>> GetYtdPay(int empId);
        Task DeletePayment(int id);
    }
    public class EmployeePaymentService : IEmployeePaymentService
    {
        private readonly ManagementDb _context;

        public EmployeePaymentService(ManagementDb context)
        {
            _context = context;
        }

        public async Task DeletePayment(int id)
        {
            var payment= _context.Payments.Find(id);
             _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(int empId)
        {
            return _context.Payments.Where(c=>c.EmployeeId==empId).ToList();
        }

        public async Task<Tuple<decimal, decimal>> GetYtdPay(int empId)
        {
            var payments = await GetAllPaymentsForEmployee(empId);
            var yearPay = payments.Where(c => c.CreateDateTime >= new DateTime(DateTime.Now.Year, 1, 1)).ToList();
            var ytdGross = yearPay.Sum(c => c.GrossPay);
            var ytdNet= yearPay.Sum(c => c.NetPay);
            return new Tuple<decimal,decimal>(ytdGross, ytdNet);
        }

        public async Task CreatePayment(Payment payment)
        {
            payment.CreateDateTime = DateTime.Now;
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }
    }
}
