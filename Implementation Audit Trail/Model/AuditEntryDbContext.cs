using Microsoft.EntityFrameworkCore;

namespace Implementation_Audit_Trail.Model
{
    public class AuditEntryDbContext:DbContext
    {
       public AuditEntryDbContext(DbContextOptions<AuditEntryDbContext> Options):base(Options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<AuditEntry> auditentries { get; set; }

    }
}
