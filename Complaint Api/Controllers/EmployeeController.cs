using Complaint_Api.BAL;
using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Complaint_Api.Controllers
{
    [Route("api/v1/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       private readonly EmployeeService Employeeservice;
        private string result;
        FilterJobs filterjob;
        public EmployeeController(ComplaintDbContext db)
        {
            Employeeservice = new EmployeeService(db);
            filterjob=new FilterJobs(db);//passing ComplaintDbContext instance
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                result=Employeeservice.Create(employee);
                return Ok(result);
            }
            return BadRequest();  

        }
        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                result = Employeeservice.Update(employee);
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Complaint")]
        public ActionResult Complaint([FromBody] JobTypeComplaint Jobtypecomplaint)
        {
            if (ModelState.IsValid)
            {
                result = Employeeservice.Complaint(Jobtypecomplaint);
                return Ok(result);

            }
            return BadRequest();
        }
        [HttpGet]
        [Route("jobstatus/{email}")]  //employee will get his job status
        public ActionResult JobStatus(string email)
        {
            result=Employeeservice.JobStatus(email);
            return Ok(result);
        }
        [HttpGet]
        [Route("filterjob/{jobtype}/{time}/status")]
        public ActionResult<IEnumerable<Job>> GetFilteedJob(string jobtype,string time,string status)
        {
            return filterjob.getjobs(jobtype, time, status);

        }
    }
}




