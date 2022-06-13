using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Card.Validation.Web.App.Attributes
{
    public class ValidateCardInfo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
			var input = value as string;

			if (string.IsNullOrWhiteSpace(input))
				return new ValidationResult("Credit Card field cannot be empty");
			IEnumerable<char> rev = input.Reverse();
			int sum = 0, i = 0;
			foreach (char c in rev)
			{
				if (c < '0' || c > '9')
					return new ValidationResult("Not a valid credit card number");
				int tmp = c - '0';
				if ((i & 1) != 0)
				{
					tmp <<= 1;
					if (tmp > 9)
						tmp -= 9;
				}
				sum += tmp;
				i++;
			}
			return ((sum % 10) == 0) 
				? ValidationResult.Success 
				: new ValidationResult("Not a valid credit card number");
        }         
    }
}