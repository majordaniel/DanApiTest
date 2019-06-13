using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DanApiTest.Data.Models
{
    public class Employee
    {
        public long Id { get; set; }
        [Required(AllowEmptyStrings =false)]
        [StringLength(25,MinimumLength =3)]
        public string FullName { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public DateTime? TimeStampRegistered { get; set; }
    }
}
