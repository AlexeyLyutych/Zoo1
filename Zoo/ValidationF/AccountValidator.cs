using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.ValidationF
{
    public class AccountValidate : ValidationRule
    {
        private string _regex = @"^[A-Z][A-Z]\d{7}[A-Z][A-Z]$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Поле не должно быть пустым");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _regex))
                    return new ValidationResult(false, " Пример: AB1234567BY");
            }
            return ValidationResult.ValidResult;
        }
    }

}
