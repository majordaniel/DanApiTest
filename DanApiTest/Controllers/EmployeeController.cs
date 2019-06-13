using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanApiTest.Data.Models;
using DanApiTest.Data.ViewModel;
using DanApiTest.Services.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanApiTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employeeList = _employeeService.GetEmployees();
                if (employeeList != null)
                {
                    return Ok(employeeList);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var employee = _employeeService.GetEmployee(id);
                    if (employee != null)
                    {
                        var respObj = new EmployeeDetailViewModel
                        {
                            Id = employee.Id,
                            FullName = employee.FullName,
                            Department = employee.Department,
                            Age = employee.Age,
                            TimeStampRegistered = employee.TimeStampRegistered
                        };
                        return Ok(respObj);
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody]EmployeeViewModel newEntry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (newEntry != null)
                    {
                        var added = _employeeService.Add(newEntry);
                        var employee = new EmployeeDetailViewModel
                        {
                            Id = added.Id,
                            FullName = added.FullName,
                            Age = added.Age,
                            Department = added.Department,
                            TimeStampRegistered = added.TimeStampRegistered
                        };
                        return Ok(employee);
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EmployeeUpdateViewModel reqObj)
        {
            try
            {
                if (id < 1) return BadRequest("Employee Id Is Required!");

                if (reqObj != null)
                {
                    Employee updatedEmployee = _employeeService.Update(id, reqObj);

                    if (updatedEmployee != null)
                    {
                        EmployeeDetailViewModel respObj = new EmployeeDetailViewModel
                        {
                            Age = updatedEmployee.Age,
                            FullName = updatedEmployee.FullName,
                            Department = updatedEmployee.Department,
                            Id = updatedEmployee.Id,
                            TimeStampRegistered = updatedEmployee.TimeStampRegistered
                        };

                        return Ok(respObj);
                    }
                }
                return BadRequest("Request Object Required!");
            }
            catch (Exception)
            {

                return BadRequest("Oops Something went wrong!");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 1) {
                    var deleteResponse = _employeeService.DeleteEmployee(id,out bool status);
                    if (string.IsNullOrEmpty(deleteResponse)) { return BadRequest("Something Went Wrong!"); }
                    if (status)
                    {
                        return Ok(deleteResponse);
                    }
                    else {
                        return BadRequest(deleteResponse);
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest("Something Went Wrong!");
            }
        }
    }
}
