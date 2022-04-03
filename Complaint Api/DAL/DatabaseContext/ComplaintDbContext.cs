using Complaint_Api.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Complaint_Api.DAL.DatabaseContext
{
    public class ComplaintDbContext:DbContext
    {
        public ComplaintDbContext(DbContextOptions<ComplaintDbContext> options):base(options)
        {

        }
        public DbSet<Complaint> complaints { get; set; }
        public DbSet<Employee>employees { get; set; }   
        public DbSet<Job> jobs { get; set; }
        public DbSet<Vendor> vendors { get; set; }

    }
}
