using Library_Management_System.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.DAL.DbContextRepo
{
    public class LibraryDbContext:DbContext
    {
       public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options)
        {
          
        }
       public DbSet<Book> books { get; set;}
       public DbSet<BookIssue> bookissues { get; set;}
       public DbSet<BookReturn> bookreturns { get; set;}
        public DbSet<Member> members { get; set;}
        public DbSet<ReserveBook> reservebooks { get; set;}
        public DbSet<ReservedByLibrarian> reservedbylibrarians { get; set;}  
       
    }
}
