using DanApiTest.Data.Models;
using DanApiTest.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanApiTest.Services.Service.Abstract
{
    public interface IEmployeeService
    {
        Employee Add(EmployeeViewModel newEmployee);
        
        Employee Update(int id,EmployeeUpdateViewModel reqObj);
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        string DeleteEmployee(int id,out bool status);
    }
}
