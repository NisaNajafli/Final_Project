using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Payment:BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public decimal GrossPay { get; set; } //Vergisiz odenilen mebleg
        public DateTime PaymentPeriodFrom { get; set; } //Ne vaxtdan
        public DateTime PaymentPeriodTo { get; set; } //Ne vaxta
        public decimal SocialSecurityTax { get; set; }
        public decimal NetPay { get; set; }
        public DateTime CreateDateTime { get; }=DateTime.Now;

        public Payment(int employeeId,decimal grossPay, DateTime paymentPeriodFrom, DateTime paymentPeriodTo)
        {
            EmployeeId = employeeId;
            GrossPay = grossPay;
            PaymentPeriodFrom = paymentPeriodFrom;
            PaymentPeriodTo = paymentPeriodTo;
            SocialSecurityTax = (GrossPay * 10) / 100; ;
            NetPay = GrossPay - SocialSecurityTax; 
        }
    }
}
