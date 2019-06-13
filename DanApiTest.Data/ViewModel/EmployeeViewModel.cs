using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DanApiTest.Data.ViewModel
{
    public class EmployeeViewModel
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
    }
    public class EmployeesListingViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
    }
    public class EmployeeDetailViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public DateTime? TimeStampRegistered { get; set; }
    }
    public class EmployeeUpdateViewModel
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        
    }
}
