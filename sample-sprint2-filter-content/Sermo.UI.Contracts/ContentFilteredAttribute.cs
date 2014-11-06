using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.UI.Contracts
{
    public class ContentFilteredAttribute : ValidationAttribute
    {
        private readonly string[] blacklist = new string[] 
        {
            "hefferlump",
            "woozle",
            "jabberwocky",
            "frabjous",
            "bandersnatch"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;

            if (value != null && value is string)
            {
                var valueString = (string)value;
                if(blacklist.Any(inappropriateWord => valueString.ToLowerInvariant().Contains(inappropriateWord.ToLowerInvariant())))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    validationResult = new ValidationResult(errorMessage);
                }
            }

            return validationResult;
        }
    }
}
