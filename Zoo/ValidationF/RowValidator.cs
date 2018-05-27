using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Zoo.Models;
using System.Text.RegularExpressions;
namespace Zoo.ValidationF
{
    public class RowDataInfoValidationRule : ValidationRule
    {
        private string _regex = @"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
        private string _regex1 = @"^[\sа-яА-ЯёЁa-zA-Z]+$";
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            
            BindingGroup group = (BindingGroup)value;

            ZooContex db = new ZooContex();
            db.Employess.Load();
            foreach (Models.Employees item in group.Items)
            {

                IEnumerable<Models.Employees> res = db.Employess.Local.Where(n => n.IDOfCertification == item.IDOfCertification);
                IEnumerable<Models.Employees> res1 = db.Employess.Local.Where(n => n.Name == item.Name);
                if(item.IDOfCertification==0 || res.Count() != 0)
                {
                   
                    return new ValidationResult(false, " Поле ID совпадает с другим ID либо равно нулю");
                }
                if(item.Name==null || res1.Count() != 0 ||!Regex.IsMatch(item.Name, _regex1))
                {
                    return new ValidationResult(false, " Поле ФИО нулевое либо совпадает с другим ФИО");
                }
                if (item.Position == null || !Regex.IsMatch(item.Position, _regex1))
                {
                    return new ValidationResult(false, "Поле Должность нулевое или содержит цифры");
                }
                if (item.Experience < 0 )
                {
                    return new ValidationResult(false, "Стаж не может быть меньше нуля");
                }
                if (item.BDAY > DateTime.Now.AddYears(-16))
                {
                    return new ValidationResult(false, "Работник не может быть младше 16 лет");
                }
                if (item.PhoneNumber==null||!Regex.IsMatch(item.PhoneNumber, _regex))
                    return new ValidationResult(false, "Шаблоны телефона +375ххххххххх или 80ххххххххх");
            }
            return ValidationResult.ValidResult;

        }
    }
}
