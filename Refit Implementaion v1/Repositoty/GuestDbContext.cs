using Microsoft.EntityFrameworkCore;
using Refit_Implementaion.Model;

namespace Refit_Implementaion.Repositoty
{
    public class GuestDbContext:DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options):base(options)
        {

        }
        public DbSet<GuestModel> guests { get; set;}
    }
}
