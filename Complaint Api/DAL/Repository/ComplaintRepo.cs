using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Complaint_Api.DAL.Repository
{
    public class ComplaintRepo
    {
        ComplaintDbContext db;
        public ComplaintRepo(ComplaintDbContext _db)
        {
            db = _db;
        }
        public List<Complaint> GetAllComplaints()
        {
            return db.complaints.Select(x=>x).ToList();
        }
    }
}
