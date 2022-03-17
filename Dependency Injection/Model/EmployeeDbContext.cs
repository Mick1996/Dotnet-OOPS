using Microsoft.EntityFrameworkCore;

namespace Dependency_Injection.Model
{
    public class EmployeeDbContext :DbContext
    {
       public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
}
