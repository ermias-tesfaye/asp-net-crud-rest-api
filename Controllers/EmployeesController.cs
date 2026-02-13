using asp.net_crud.Context;
using asp.net_crud.Models;
using asp.net_crud.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_crud.Controllers
{
    // localhost:port/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var EmployeesData = dbContext.Employees.ToList();
            return Ok(EmployeesData);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return StatusCode(201, employeeEntity);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllEmployeeById(Guid id)
        {
            var EmployeeData = dbContext.Employees.Find(id);

            if (EmployeeData == null)
                return NotFound();

            return Ok(EmployeeData);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {

            var employee = dbContext.Employees.Find(id);

            if (employee == null)
                return NotFound();


            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;


            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
                return NotFound();

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
