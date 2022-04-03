using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Complaint_Api.Utilities
{
    public class FilterJobs  //comman functionality for all
    {
        ComplaintDbContext db;
        public FilterJobs(ComplaintDbContext _db)
        {
           db = _db;
        }
        
        public List<Job> getjobs(string jobtype,string createdtime,string status)
        {
           return db.jobs.Where(x => x.Status == status || x.CreatedOn.Equals(createdtime) || x.JobType == jobtype).ToList();
        }
    }
}
