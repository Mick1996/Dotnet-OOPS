using Complaint_Api.DAL.DatabaseContext;
using Complaint_Api.DAL.Model;
using Complaint_Api.DAL.Repository;

namespace Complaint_Api.BAL
{
    public class EmployeeService
    {
        private readonly EmployeeRepo Employeerepo;
        private string result;
        public EmployeeService(ComplaintDbContext db)
        {
            Employeerepo = new EmployeeRepo(db);
        }
        public string Create(Employee employee)
        {
            result=Employeerepo.Create(employee);
            return result;
        }
        
        public string Update(Employee employee)
        {
            result = Employeerepo.Update(employee);
            return result;
        }
        
        public string Complaint(JobTypeComplaint Jobtypecomplaint)
        {
            result = Employeerepo.Complaint(Jobtypecomplaint);
            return result;
        }
        public string JobStatus(string email)
        {
            result=Employeerepo.JobStatus(email);
            return result;
        }
    }
}
