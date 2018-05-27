using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.ValidationF
{
    public class NumberValidate : ValidationRule
    {
        private string _regex = @"^[0-9]{1,3}$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Поле не должно быть пустым");
            else
            {
                if (!Regex.IsMatch(value.ToString(), _regex))
                    return new ValidationResult(false, "Числовое значение!");
            }
            return ValidationResult.ValidResult;
        }
    }

}
