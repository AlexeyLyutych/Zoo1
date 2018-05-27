using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.ValidationF
{
    public class HourValidate : ValidationRule
    {
        private string _regex = @"^\d[0-23]$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _regex))
                    return new ValidationResult(false, "");
            }
            return ValidationResult.ValidResult;
        }
    }

}
