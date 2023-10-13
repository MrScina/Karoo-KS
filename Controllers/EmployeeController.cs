using Karoo_KS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Collections;
using Karoo_KS.Service;
using Karoo_KS.Repo;

namespace Karoo_KS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeContext _employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
       
        [HttpGet]
        public async Task<ActionResult> GellEmployee()
        {
            var EmployeeService = new EmployeeService(_employeeContext);
            try
            {
                var allemp = EmployeeService.GetAllEmployee().Result.Value;

                return Ok(allemp);
               
            }
            catch (Exception ex) 
            { 
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var EmployeeService = new EmployeeService(_employeeContext);
            try
            {
                var employee = await EmployeeService.GetEmployee(id);

                return  employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var EmployeeService = new EmployeeService(_employeeContext);
            try
            {
                var person = await EmployeeService.AddEmployee(employee);
                
                return CreatedAtAction(nameof(AddEmployee), new { id = employee.id }, employee);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditEmployee(int id, Employee employee)
        {
            var EmployeeService = new EmployeeService(_employeeContext);
            try
            {

                var person = await EmployeeService.EditEmployee(id ,employee);
                return Ok();//status of 200
            }
            catch (Exception ex)
            {
                throw;
            }     
        }
        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteEmployee(int id)
        {
            var EmployeeService = new EmployeeService(_employeeContext);
            if (id == 0)
            {
                return BadRequest();
            }
            var employee = await EmployeeService.DeleteEmployee(id);
            return Ok();    
        }
    }
}
