using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using System.Linq;

namespace Complaint_Api.DAL.Repository
{
    public class EmployeeRepo
    {

        ComplaintDbContext db;
        public EmployeeRepo(ComplaintDbContext _db)
        {
            db= _db;    
        }
        public string Create(Employee employee)
        {
          db.employees.Add(employee);
            db.SaveChanges();
            return "Employee Registerd Successfully";
        }

        public string Update(Employee employee)
        {
            Employee emp = db.employees.Find(employee.Email);
            db.employees.Update(emp);
            db.SaveChanges();
            return "Employee Updated Successfully";
        }
        public string JobStatus(string email)
        {
            return db.employees.Find(email).JobStatus;
        }
        public string Complaint(JobTypeComplaint Jobtypecomplaint) //to file complaint employee must be registerd
        {
            var emp = db.employees.Where(x=>x.Email==Jobtypecomplaint.Email).FirstOrDefault();
            if (emp == null)
            {
                return "Employee is not Registed";
            }
            else
            {
                Complaint cmp = new Complaint();
                cmp.Email = Jobtypecomplaint.Email;
                cmp.HandelledBy = "none";
                cmp.UpdatedOn = System.DateTime.Now;
                cmp.CreatedOn = System.DateTime.Now;
                cmp.Description = Jobtypecomplaint.Description;
                cmp.Reopened = 0;
                db.complaints.Add(cmp);
                db.SaveChanges();
                Vendor vendor = new Vendor();
                var specificvendor = db.vendors.Where(x => x.JobType == Jobtypecomplaint.JobType).FirstOrDefault();
                specificvendor.ComplaintBox = Jobtypecomplaint.Description;//put complaint in vendor complaintbox of specific jobtype
                db.SaveChanges();
                return "Complaint registerd Successfully";
            }
        }
    }
}




