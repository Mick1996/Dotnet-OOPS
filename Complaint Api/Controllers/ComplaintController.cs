using Complaint_Api.BAL;
using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Complaint_Api.Controllers
{
    [Route("api/complaint")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly ComplaintService Complaintservice;
          public ComplaintController(ComplaintDbContext _db)
        {
            Complaintservice=new ComplaintService(_db);
        }
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<Complaint>> GetAll()
        {
            return Complaintservice.GetAllComplaint(); 
        }
    }
}
