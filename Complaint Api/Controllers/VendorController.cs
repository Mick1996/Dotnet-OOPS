using Complaint_Api.BAL;
using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Complaint_Api.Controllers
{
    [Route("api/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        FilterJobs filterjob;
        VendorService Vendorservice;
        public VendorController(ComplaintDbContext db)
        {
            Vendorservice=new VendorService(db);
            filterjob = new FilterJobs(db);
        }
      [HttpGet]
      [Route("vendorjobs/{id}")]
         public ActionResult<IEnumerable<Job>> GetVendorJobs(int id) 
        {
            return Ok(Vendorservice.VendorOpenJob(id));    
        }
        [HttpGet]
        [Route("filterjob/{jobtype}/{time}/status")]
        public ActionResult<IEnumerable<Job>> GetFilteedJob(string jobtype, string time, string status)
        {
            return filterjob.getjobs(jobtype, time, status);

        }

    }
}
