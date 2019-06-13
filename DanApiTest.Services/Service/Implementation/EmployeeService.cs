using DanApiTest.Data;
using DanApiTest.Data.Models;
using DanApiTest.Data.ViewModel;
using DanApiTest.Services.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanApiTest.Services.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DanApiContext _context;

        public EmployeeService(DanApiContext context)
        {
            _context = context;
        }
        public Employee Add(EmployeeViewModel newEntry)
        {
            try
            {
                if (newEntry == null) { return null; }
                else
                {
                    var newEmployee = new Employee
                    {
                        FullName = newEntry.FullName,
                        Age = newEntry.Age,
                        Department = newEntry.Department,
                        TimeStampRegistered = DateTime.Now.Date
                    };
                    var addedEmployee = _context.Add(newEmployee);
                    if (_context.SaveChanges() > 0) return newEmployee;
                }
                return null;
            }
            catch (Exception)
            {

                //log error 
                return null;
            }
        }

        public string DeleteEmployee(int id,out bool status)
        {
            try
            {
                status = false;
                //get employee
                var emp = GetEmployee(id);
                if (emp != null) {
                    _context.Remove(emp);
                    if (_context.SaveChanges() > 0) {
                        var respObj = "Employee Deleted Successfully!";
                        status = true;
                        return respObj;
                    }
                }
                else
                {
                    var respObj = "No Employee Associated with resource";
                    status = false;
                    return respObj;
                }
              
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetEmployee(int employeeId)
        {
            try
            {
                var employees = GetEmployees(); //to first get every employees
                if (employees != null)
                {
                    var specificEmployee = employees
                                                .Find(emp => emp.Id == employeeId);//finding the requested employee
                    if (specificEmployee != null)
                    {
                        return specificEmployee;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                var employees = new List<Employee>();
                var cemployees = _context.Employee;
                if (cemployees != null)
                {
                    foreach (var emp in cemployees)
                    {
                        employees.Add(emp);
                    }
                }
                return employees;
            }
            catch (Exception)
            {
                //log error here

                return null;
            }
        }

        public Employee Update(int id,EmployeeUpdateViewModel reqObj)
        {
            try
            {
                var reqEmployee = GetEmployee(id);
                if (reqEmployee == null)
                {
                    return null;
                }
                reqEmployee.Age = (reqObj.Age > 0) ? reqObj.Age : reqEmployee.Age;
                reqEmployee.Department = (!string.IsNullOrEmpty(reqObj.Department)) ? reqObj.Department : reqEmployee.Department;
                reqEmployee.FullName = (!string.IsNullOrEmpty(reqObj.FullName)) ? reqObj.FullName : reqEmployee.FullName;

                var updateOp = _context.Update(reqEmployee);
                if (_context.SaveChanges() > 0) {
                    var employee = new Employee {
                       Id = reqEmployee.Id,
                       Age = reqEmployee.Age,
                       Department = reqEmployee.Department,
                       FullName = reqEmployee.FullName,
                       TimeStampRegistered = reqEmployee.TimeStampRegistered
                    };
                    return employee;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
