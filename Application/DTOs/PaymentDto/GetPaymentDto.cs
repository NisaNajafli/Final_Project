using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.PaymentDto
{
    public class GetPaymentDto
    {
        public int Id { get; set; } 
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal GrossPay { get; set; } 
        public DateTime PaymentPeriodFrom { get; set; } 
        public DateTime PaymentPeriodTo { get; set; } 
        public decimal SocialSecurityTax { get; set; } 
        public decimal NetPay { get; set; } 
        public DateTime CreateDateTime { get; }=DateTime.Now;
    }
}

