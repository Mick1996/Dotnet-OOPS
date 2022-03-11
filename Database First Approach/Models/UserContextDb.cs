using Microsoft.EntityFrameworkCore;

namespace Database_First_Approach.Models
{
    public class UserContextDb : DbContext
    {
        public UserContextDb(DbContextOptions<UserContextDb> options) : base(options) 
        {
           
        }
        public DbSet<User> Users { get; set; }
    }
    
}
