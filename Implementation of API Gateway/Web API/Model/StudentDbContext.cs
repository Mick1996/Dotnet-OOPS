using Microsoft.EntityFrameworkCore;
namespace Web_API.Model
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> option) : base(option)
        {

        }
        public DbSet<Student> students { get; set; }
        //public DbSet<Course> courses { get; set; }
    }
}
