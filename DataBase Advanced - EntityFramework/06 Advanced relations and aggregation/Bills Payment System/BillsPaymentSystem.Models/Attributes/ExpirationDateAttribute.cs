namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentDate = DateTime.Now;
            var expirationDate = (DateTime)value;

            if (currentDate > expirationDate)
            {
                return new ValidationResult("The card has expired!");
            }

            return ValidationResult.Success;
        }
    }
}
