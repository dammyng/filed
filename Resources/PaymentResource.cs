using System;
using System.ComponentModel.DataAnnotations;

namespace filed.Resources
{
    public class PaymentResource
    {
        [Required]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [DateMustNotBePast]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(3)]
        public string SecurityCode { get; set; }

        [Required]
        [Range(0.1, float.MaxValue, ErrorMessage = "Amount should be a positive value")]
        public float Amount { get; set; }
    }

    public class DateMustNotBePastAttribute : ValidationAttribute
    {
        public DateMustNotBePastAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}