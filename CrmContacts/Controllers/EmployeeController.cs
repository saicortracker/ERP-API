using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ERPContext _crmContext;

        public EmployeeController(ERPContext crmContext)
        {
            _crmContext = crmContext;

        }

        //Get All Contacts
        [HttpGet]
        [Route("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            var employeeDetails = await _crmContext.Employees.ToListAsync();
            return Ok(employeeDetails);
        }
        // Get gender details for drodown
        [HttpGet]
        [Route("GetGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _crmContext.Genders.ToListAsync();
            return Ok(genders);
        }

        // Get gender details for drodown
        [HttpGet]
        [Route("GetLocation")]
        public async Task<IActionResult> GetLocation()
        {
            var location = await _crmContext.Locations.ToListAsync();
            return Ok(location);
        }



        // Get Employee By Id
        [HttpGet]
        [Route("GetEmployeesbyid")]
        public async Task<IActionResult> GetAllEmployees(int? Id)
        {
            var employees = await _crmContext.Employees.Where(x => x.Id == Id).FirstOrDefaultAsync();

            return Ok(employees);
        }



        // Add Employee
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<Employee> AddEmployee([FromBody] Employee objEmployee)
        {
            _crmContext.Employees.Add(objEmployee);
            await _crmContext.SaveChangesAsync();
            return objEmployee;
        }



        // Update/Edit Employee
        [HttpPut]
        [Route("UpdateEmployees")]

        public async Task<IActionResult> EditEmployee([FromBody] Employee employee)
        {
            var x = await _crmContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (x != null)
            {
                x.EmployeeNo = employee.EmployeeNo;
                x.EmployeeName = employee.EmployeeName;
                x.DateOfBirth = employee.DateOfBirth;
                x.JoiningDate = employee.JoiningDate;
                x.Status = employee.Status;
                x.Gender = employee.Gender;
                x.Department = employee.Department;
                x.PhoneNumber = employee.PhoneNumber;
                x.Email = employee.Email;
                x.ExtensionNumber = employee.ExtensionNumber;
                x.Location = employee.Location;
                x.Address = employee.Address;
                x.PinCode = employee.PinCode;
                await _crmContext.SaveChangesAsync();
                return Ok(x);
            }
            return NotFound("Employee is not found");
        }






        //Delete Employees
        [HttpDelete]
        [Route("DeleteEmployees/{id}")]

        public async Task<IActionResult> DeleteEmployees(int id)
        {
            var existingEmployee = await _crmContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmployee != null)
            {
                _crmContext.Remove(existingEmployee);
                await _crmContext.SaveChangesAsync();
                return Ok(existingEmployee);
            }
            return NotFound("Employee is not found");
        }
    }
}
