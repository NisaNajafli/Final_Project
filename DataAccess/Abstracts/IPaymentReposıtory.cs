using Application.Services.Abstracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IPaymentReposıtory:IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllPaymentsForEmployee(int empId);
        Task<Tuple<decimal, decimal>> GetYtdPay(int empId);
    }
}
