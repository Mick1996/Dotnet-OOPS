using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;
using System.Collections.Generic;

namespace Library_Management_System.BAL
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository LibrarianRepo;
         public LibrarianService(ILibrarianRepository _LibrarianRepo)
        {
          LibrarianRepo = _LibrarianRepo;
        }
        public string AddBook(Book Book)
        {
            string Status = LibrarianRepo.AddBook(Book);
            return Status;
        }

        public string AddUser(Member Member)
        {
            string Status = LibrarianRepo.AddUser(Member);
            return Status;
        }

        public string DeleteBook(int id)
        {
            string Status = LibrarianRepo.DeleteBook(id);
            return Status;
        }

        public string DeleteUser(int id)
        {
            string Status = LibrarianRepo.DeleteUser(id);
            return Status;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> ListOfBooks = LibrarianRepo.GetAllBooks();
            return ListOfBooks;
        }

        public List<Member> GetAllUsers()
        {
            List<Member> ListOfUsers = LibrarianRepo.GetAllUsers();
            return ListOfUsers;
        }

        public Book GetBook(int id)
        {
            Book Book = LibrarianRepo.GetBook(id);
            return Book;
        }

        public Member GetUser(int id)
        {
            Member Member = LibrarianRepo.GetUser(id);
            return Member;
        }

        public string IssueBook(BookIssue BookIssue)
        {
            string Status = LibrarianRepo.IssueBook(BookIssue);
            return Status;
        }

        public string ReservedByLibrarian(ReservedByLibrarian ReservedByLibrarian)
        {
            string Status = LibrarianRepo.ReservedByLibrarian(ReservedByLibrarian);
            return Status;
        }

        public string UpdateBook(Book Book)
        {
            string Status = LibrarianRepo.UpdateBook(Book);
            return Status;
        }
        public string UpdateUser(Member Member)
        {
            string Status = LibrarianRepo.UpdateUser(Member);
            return Status;
        }
        public List<BookIssue> IssuedBookByMember(int MemberId)
        {
           return LibrarianRepo.IssuedBookByMember(MemberId);
        }
        public Member BookIssuedToMember(int BookId)
        {
           return LibrarianRepo.BookIssuedToMember(BookId);
        }
    }
}
