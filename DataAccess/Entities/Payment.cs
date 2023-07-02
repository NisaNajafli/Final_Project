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
        public decimal SocialSecurityTax
        {
            get
            {
                    return SocialSecurityTax;
            }
            set
            {
                value = (GrossPay * 10) / 100;
                SocialSecurityTax = value;
            }
        }
        public decimal NetPay
        {
            get
            {
                return NetPay;
            }
            set
            {
                value = GrossPay - SocialSecurityTax;
                NetPay = value;

            }
        } 
        public DateTime CreateDateTime { get; }=DateTime.Now;
    }
}
