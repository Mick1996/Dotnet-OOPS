using Implementation_Audit_Trail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Implementation_Audit_Trail.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AuditEntryDbContext db;
        public EmployeeController(AuditEntryDbContext _db)
        {
            db = _db;
        }
        [HttpGet] 
        public ActionResult<IEnumerable<Employee>> GetAllEmployee()
        {
            List<Employee> employee = db.employees.Select(x => x).ToList();
            if(employee!=null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound("No Employee Exists");
            }
        }
        [HttpPost] 
        public ActionResult CreateNewEmployee(Employee employee)
        {
          if(ModelState.IsValid)
            {
                db.employees.Add(employee); 
                db.SaveChanges();
                Audit(employee.Id,"Employee"," Created", DateTime.Now);
                return Ok("Successful Created");
            }
            else
            {
                return BadRequest("Model is Not valid");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            Employee employee = db.employees.Find(id);
             if(employee!=null)
            {
                return Ok(employee);
            }
            else
            {
                return NotFound("Employee does not Exits");
            }
        }
        [HttpPut] 
        public ActionResult UpdateEmployee(Employee emp)
        {
          if(ModelState.IsValid)
            {
                db.employees.Update(emp);
                db.SaveChanges();
                Audit(emp.Id, "Employee", "Updated", DateTime.Now);
                return Ok();
            }
            else
            {
                return BadRequest("Model is not Valid");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteById(Guid id)
        {
            Employee emp = db.employees.Find(id);
            if(emp!=null)
            {
                db.employees.Remove(emp);
                db.SaveChanges();
                Audit(id, "Employee", "Deleted", DateTime.Now);
                return Ok();
            }
            else 
            {
                return NotFound();  
            }
        }
        [NonAction]
        public void Audit(Guid id,string tblname,string action,DateTime dateTime)
        {
            var auditentry = new AuditEntry();
            auditentry.EmployeeId = id;
            auditentry.TableName = tblname;
            auditentry.Action = action;
            auditentry.TimeStamp = dateTime;
            db.auditentries.Add(auditentry);
            db.SaveChanges();
        }
        
    }
}
