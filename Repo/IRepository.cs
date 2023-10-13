using Karoo_KS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel;

namespace Karoo_KS.Repo
{
    public interface IRepository
    {
        [OperationContract]
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();
        [OperationContract]
        Task<ActionResult<Employee>> GetEmployee(int id);
        [OperationContract]
        Task<ActionResult<Employee>> AddEmployee(Employee employee);
        [OperationContract]
        Task<ActionResult<Employee>> EditEmployee(int id, Employee employee);
        [OperationContract]
        Task<ActionResult<Employee>> DeleteEmployee(int id);
    }
}
