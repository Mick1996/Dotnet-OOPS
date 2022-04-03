using Complaint_Api.BAL;
using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Complaint_Api.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        FilterJobs filterjob;
         private readonly VendorService Vendorservice;
        string result;
         public AdminController(ComplaintDbContext db)
        {
            Vendorservice = new VendorService(db);
            filterjob = new FilterJobs(db);
        }
        [HttpPost]
        [Route("AddVendor")]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                result=Vendorservice.Create(vendor);
                return Ok(result);
            }
            else
                return BadRequest();    
        }
        [HttpDelete]
        [Route("RemoveVendor")]
        public ActionResult Remove(int id)
        {
            if (ModelState.IsValid)
            {
                result=Vendorservice.Remove(id);
                return Ok(result);
            }
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("alljobs")]
        public ActionResult<IEnumerable<Job>> GetOpenJobs()
        {
            List<Job> jobs= Vendorservice.GetOpenJobs();
            return Ok(jobs);
        }
        [HttpGet]
        [Route("filterjob/{jobtype}/{time}/status")]
        public ActionResult<IEnumerable<Job>> GetFilteedJob(string jobtype,string time,string status)
        {
            return filterjob.getjobs(jobtype,time,status);

        }


    }
}
