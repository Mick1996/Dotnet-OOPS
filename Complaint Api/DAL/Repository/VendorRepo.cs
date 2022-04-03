using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Complaint_Api.DAL.Repository
{
    public class VendorRepo
    {
        private readonly ComplaintDbContext db;
        public VendorRepo(ComplaintDbContext _db)
        {
           db= _db;
        }
        public string Create(Vendor vendor)
        {
            db.vendors.Add(vendor);
            db.SaveChanges();
            return "Vendor added Successfully";
        }

        public string Remove(int id)
        {
            var vendor=db.vendors.Find(id);
            db.vendors.Remove(vendor);
            db.SaveChanges();
            return "Vendor has removed";
        }
        public List<Job> GetOpenJobs()
        {
            List<Job> jobs=db.jobs.Where(x=>x.Status=="open").ToList(); 
            return jobs;
        }
        public List<Job> VendorOpenJobs(int id)
        {
         var jobs=db.jobs.Where(x=>x.VendorId==id && x.Status=="open").ToList();
          return jobs;
        }
    }
}
