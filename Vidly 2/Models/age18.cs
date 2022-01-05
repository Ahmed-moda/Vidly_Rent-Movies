using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly_2.tmp;
namespace Vidly_2.Models
{
    public class age18:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cus=(tmpcustomer)validationContext.ObjectInstance;

            if (cus.Membershipid == 1 || cus.Membershipid == 0)
                return ValidationResult.Success;
            if (cus.BirthDate == null)
                return new ValidationResult("Birthdate is Required");
            var age = DateTime.Today.Year - cus.BirthDate.Year;

            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer Should be 18 Years Old To Select This Membership");
        }
    }
}