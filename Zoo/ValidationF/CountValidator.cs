using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Zoo.ValidationF
{
    public class CountValidate : ValidationRule
    {
        private string _regex = @"^[0-9]{1,3}$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Поле не должно быть пустым");
           
            
            else if (!Regex.IsMatch(value.ToString(), _regex))
            {
                
                    return new ValidationResult(false, "Числовое значение!");
            }
            else if (Convert.ToInt32(value) == 0)
                return new ValidationResult(false, "Не может ровняться 0");
            return ValidationResult.ValidResult;
        }
    }

}
