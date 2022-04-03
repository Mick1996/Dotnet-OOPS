using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.DAL.Repository;
using System.Collections.Generic;

namespace Complaint_Api.BAL
{
    public class VendorService
    {
        private readonly VendorRepo Vendorrepo;
        string result;
        public VendorService(ComplaintDbContext db)
        {
            Vendorrepo = new VendorRepo(db);
        }
        public string Create(Vendor vendor)
        {
           result= Vendorrepo.Create(vendor);
            return result;  
        }
        
        public string Remove(int id)
        {
            result=Vendorrepo.Remove(id);
            return result;
        }
        public List<Job> GetOpenJobs()
        {
            List<Job> jobs = Vendorrepo.GetOpenJobs();
            return jobs;
        }
        public List<Job> VendorOpenJob(int id)
        {
            return Vendorrepo.VendorOpenJobs(id);
        }
    }
}
