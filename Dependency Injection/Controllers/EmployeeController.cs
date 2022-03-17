using Dependency_Injection.Interface;
using Dependency_Injection.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employee;    //which class injected it hold the reference of that class
        public EmployeeController(IEmployee _employee)
        {
            employee = _employee;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
           List<Employee> emp=employee.GetAll();
            if(emp==null)
            {
                return NotFound("Employee Does not Exist");
            }
            else
            {
                return emp;
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(Guid id)
       {
            Employee emp=employee.GetById(id);
            if (emp == null)
            {
                return NotFound("Employee Does not Exist");
            }
            else
            {
                return emp;
            }
        }
    }
}
