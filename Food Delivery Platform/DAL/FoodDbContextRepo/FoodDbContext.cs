using Food_Delivery_Platform.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_Platform.DAL.FoodDbContextRepo
{
    public class FoodDbContext:DbContext
    {
       
       public FoodDbContext(DbContextOptions<FoodDbContext> options):base(options)
        {

        }
        public DbSet<Hotel> hotels { get; set;}
        public DbSet<HotelMenu> hotelmenus { get; set;}
        public DbSet<HotelStatus> hotelstatus { get; set;}
        public DbSet<HotelTransaction> hoteltransactions { get; set;}
        public DbSet<User> users { get; set;}
        public DbSet<UserTranxHistory> usertranxhistory { get; set;}

    }
}
