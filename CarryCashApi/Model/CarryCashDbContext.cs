using Microsoft.EntityFrameworkCore;
namespace CarryCashApi.Model
{
    public class CarryCashDbContext : DbContext
    {
        public CarryCashDbContext(DbContextOptions<CarryCashDbContext> options):base(options)
        {
                  
        }
        public DbSet<Merchant> merchant { get; set;}
        public DbSet<Owner> owner { get; set;}  
        public DbSet<Payee> payee { get; set;}  
        public DbSet<Payee_Kyc> payee_kyc { get; set;}  
        public DbSet<Payee_Kyb> payee_kyb { get; set;}
        public DbSet<Transaction> transactions { get; set;}
    }
}

