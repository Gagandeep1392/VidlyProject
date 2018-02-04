using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyNew.Models;

namespace VidlyNew.Models
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age > 18 ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years of age");

        }
    }

    public class NumberofStockValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock == null)
                return new ValidationResult("Number of Stock is required.");

            bool bValid = true;

            if (movie.NumberInStock >= 1 && movie.NumberInStock <= 20)
                bValid = true;
            else
                bValid = false;

            return bValid ? ValidationResult.Success : new ValidationResult("Number of stock should be between 1 to 20.");

        }
    }
}