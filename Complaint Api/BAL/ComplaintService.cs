using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.DAL.Repository;
using System.Collections.Generic;

namespace Complaint_Api.BAL
{
    public class ComplaintService
    {
        ComplaintRepo Complaintrepo;
        public ComplaintService(ComplaintDbContext db)
        {
            Complaintrepo = new ComplaintRepo(db);
        }
        public List<Complaint> GetAllComplaint()
        {
            return Complaintrepo.GetAllComplaints();
        }
    }
}
