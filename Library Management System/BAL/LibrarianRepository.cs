using Library_Management_System.DAL.DbContextRepo;
using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System.BAL
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly LibraryDbContext Db;
        public LibrarianRepository(LibraryDbContext _Db)
        {
          Db = _Db;
        }
        public string AddBook(Book Book)
        {
            Db.books.Add(Book);
            Db.SaveChanges();
            return "Book added Successfully";
        }

        public string AddUser(Member Member)
        {
            Db.members.Add(Member);
            Db.SaveChanges();
            return "User added successfully";
        }

        public string DeleteBook(int id)
        {
            Book Book = Db.books.Find(id);
            if(Book!=null)
            {
                Db.books.Remove(Book);
                Db.SaveChanges();
                return "Book deleted Successfully"; 
            }
            return "Book is not available";
        }

        public string DeleteUser(int id)
        {
            Member Member = Db.members.Find(id);
            if(Member!=null)
            {
                Db.members.Remove(Member);
                Db.SaveChanges();
                return "User deleted Successfully";
            }
            return "User not Found";
        }

        public List<Book> GetAllBooks()
        {
            List<Book> ListOfBooks = Db.books.Select(x => x).ToList();
            return ListOfBooks;
        }

        public List<Member> GetAllUsers()
        {
            List<Member> ListOfMembers = Db.members.Select(x => x).ToList();
            return ListOfMembers;
        }

        public Book GetBook(int id)
        {
            Book Book = Db.books.Find(id);
             return Book;
        }

        public Member GetUser(int id)
        {
            Member Member = Db.members.Find(id);
            return Member;
        }

        public string IssueBook(BookIssue BookIssue)
        {
            var Member = Db.members.Find(BookIssue.MemberId);
            if (Member == null)
            {
                return "Member does not Found";
            }
            List<BookIssue> ListOfBooks = Db.bookissues.Where(x => x.MemberId == BookIssue.MemberId).Select(x => x).ToList();
            if (ListOfBooks.Count > 5)
            {
                return "You Can't issue more books";
            }   
            else
            {
                Db.bookissues.Add(BookIssue);
                Db.SaveChanges();
                return "Book Issued Successfully";
            }
        }

        public string ReservedByLibrarian(ReservedByLibrarian ReservedByLibrarian)
        {
            Db.reservedbylibrarians.Add(ReservedByLibrarian);
            Db.SaveChanges();
            return "Book Reserved";
        }

        public string UpdateBook(Book Book)
        {
            Db.books.Update(Book);
            Db.SaveChanges();
            return "Book Updated Successfully";
        }
        public string UpdateUser(Member Member)
        {
            Db.members.Update(Member);
            Db.SaveChanges();
            return "User Updated successfully";
        }
        public List<BookIssue> IssuedBookByMember(int MemberId)
        {
            return Db.bookissues.Where(x => x.MemberId == MemberId).Select(x => x).ToList();
        }
        public Member BookIssuedToMember(int BookId)
        {
            int MemberId = Db.bookissues.Where(x => x.BookId == BookId).Select(x => x.MemberId).FirstOrDefault();
            return Db.members.Where(x => x.Id == MemberId).Select(x => x).FirstOrDefault();
        }
    }
}
