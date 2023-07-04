using Application.Services.Abstracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IPaymentRepository:IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(int empId, string include = null);
        Task<Tuple<decimal, decimal>> GetYtdPay(int empId);
    }
}
