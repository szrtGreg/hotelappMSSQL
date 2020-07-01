using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapp.Web.Models
{
    public class DateNotInPastValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateValue = value as DateTime? ?? new DateTime();


            if (dateValue.Date < DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Date value should not be in the past";
        }

    }
}
