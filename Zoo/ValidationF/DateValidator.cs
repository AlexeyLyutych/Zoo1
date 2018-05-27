using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zoo.ValidationF
{
    public class DatetValidate : ValidationRule
    {
        

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else if (!DateTime.TryParse(value.ToString(), out DateTime id))
            {
               
            }
            else if(Convert.ToDateTime(value)<DateTime.Today)
                return new ValidationResult(false, "");
            return ValidationResult.ValidResult;
        }
    }

}
