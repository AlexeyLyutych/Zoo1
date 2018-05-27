using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Zoo.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOfCertification {get;set;}
        public string Name { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public DateTime BDAY { get; set; }
        public string PhoneNumber { get; set; }

    }
}
