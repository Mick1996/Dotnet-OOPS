using Dependency_Injection.Model;
namespace Dependency_Injection.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetAll();
        public Employee GetById(Guid id);
    }
}
