using Karoo_KS.Models;
using Karoo_KS.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Karoo_KS.Repo;

namespace Karoo_KS.Service
{
    
    public class EmployeeService : ControllerBase, IRepository
    {
        
            private EmployeeContext _employeeContext;
            public EmployeeService(EmployeeContext employeeContext) 
            {
                _employeeContext = employeeContext;
            }

         public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            try
            {
                
                if (_employeeContext.Employees == null)
                {
                    return NotFound();
                }
                var emp=  _employeeContext.Employees.ToListAsync().GetAwaiter().GetResult();

                return emp;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
   
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                
                if (_employeeContext.Employees == null)
                {
                    return NotFound();
                }
                var employee = await _employeeContext.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return employee;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
       public  async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            { 
                _employeeContext.Employees.Add(employee);
                await _employeeContext.SaveChangesAsync();
               
                return employee;
                    
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       
       public  async Task<ActionResult<Employee>> EditEmployee(int id, Employee employee)
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

                return Ok(employee);//status of 200
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var employee = await _employeeContext.Employees.FindAsync(id);

            if (employee == null && _employeeContext.Employees == null)
            {
                return NotFound();
            }
            else
            {
                _employeeContext.Remove(employee);
                await _employeeContext.SaveChangesAsync();
                
            }
            return Ok(employee);
          
        }
    }
}
