namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string xorTargetAttribute;

        public XorAttribute(string xorTargetAttribute)
        {
            this.xorTargetAttribute = xorTargetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                .GetProperty(xorTargetAttribute)
                .GetValue(validationContext.ObjectInstance);

            if (xorTargetAttribute == null && value != null || xorTargetAttribute != null && value == null)
            {
                return ValidationResult.Success;
            }

            string errorMessage = "The two propperties must have opposite values!";

            return new ValidationResult(errorMessage);
        }
    }
}
