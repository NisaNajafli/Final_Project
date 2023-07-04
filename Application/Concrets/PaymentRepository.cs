using DataAccess.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrets
{
    public class PaymentRepository:Repository<Payment>,IPaymentRepository
    {
        private readonly ManagementDb _context;

        public PaymentRepository(ManagementDb context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(int empId,string include)
        {
            return _context.Payments.Where(c => c.EmployeeId == empId).Include(include).ToList();
        }

        public async Task<Tuple<decimal, decimal>> GetYtdPay(int empId)
        {
            var payments = await GetAllPaymentsForEmployee(empId,"Employee");
            var yearPay = payments.Where(c => c.CreateDateTime >= new DateTime(DateTime.Now.Year, 1, 1)).ToList();
            var ytdGross = yearPay.Sum(c => c.GrossPay);
            var ytdNet = yearPay.Sum(c => c.NetPay);
            return new Tuple<decimal, decimal>(ytdGross, ytdNet);
        }

    }
}
