using Dependency_Injection.Interface;
using Dependency_Injection.Model;

namespace Dependency_Injection.Data
{
    public class EmployeeData : IEmployee  //fetch data from existing Database
    {                              //for this i didn't add migration 
        EmployeeDbContext db;
        public EmployeeData(EmployeeDbContext _db)
        {
            db = _db;
        }
        public List<Employee> GetAll()
        {
            return db.employees.Select(x => x).ToList(); ;
        }

        public Employee GetById(Guid id)
        {
            Employee emp = db.employees.Find(id);
            return emp;
        }
    }
}
