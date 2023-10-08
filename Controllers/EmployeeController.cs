using Karoo_KS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            try
            {
                if(_employeeContext.Employees==null)
                {
                    return NotFound();
                }
                return await _employeeContext.Employees.ToListAsync();

            }catch (Exception ex) 
            { 
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                if (_employeeContext.Employees == null)
                {
                    return NotFound();
                }
                var employee =await _employeeContext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
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
            try
            {
                
                //if (employee?.id == 0)
                //{
                //   return BadRequest();
                //}

                _employeeContext.Employees.Add(employee);
                await _employeeContext.SaveChangesAsync();
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
            try
            {


                if (id != employee?.id)
                {
                    return BadRequest();
                }
               
                else
                {
                    _employeeContext.Entry(employee).State = EntityState.Modified;
                    await _employeeContext.SaveChangesAsync();
                }

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
            if(id == 0)
            {
                return BadRequest();
            }
            var employee = await _employeeContext.Employees.FindAsync(id);

            if(employee == null && _employeeContext.Employees== null)
            {
                return NotFound();
            }
            else
            {
                _employeeContext.Remove(employee);
                await _employeeContext.SaveChangesAsync();  
            }
            return Ok();    
        }
    }
}
