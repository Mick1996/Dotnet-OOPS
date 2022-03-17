using Dependency_Injection.Interface;
using Dependency_Injection.Model;

namespace Dependency_Injection.Data
{
    public class LocalEmployeeData : IEmployee   //This Employee data exist locally
    {
        List<Employee> Emp = new List<Employee>()
          {
           new Employee()
           {
               Id =new Guid(), Name = "Abhi", Address ="Okhla", Department ="IT"
           },
           new Employee
           {
              Id=new Guid(),Name="Sam",Address ="Janakpuri",Department ="Management"
           },
           new Employee
           {
              Id=new Guid(),Name="Sam",Address ="Janakpuri",Department ="Management"
           }
         };
        public List<Employee> GetAll()
        {
            return Emp.Select(x => x).ToList(); 
        }

        public Employee GetById(Guid id)
        {
            return Emp.Where(x=>x.Id==id).Select(x=>x).FirstOrDefault();  
        }
    }
}
