using Library_Management_System.DAL.Model;
using System.Collections.Generic;

namespace Library_Management_System.IRepository
{
    public interface ILibrarianRepository
    {
        public List<Book> GetAllBooks();
        public string AddBook(Book Book);
        public Book GetBook(int id);
        public string UpdateBook(Book Book);
        public string DeleteBook(int id);
        public string IssueBook(BookIssue BookIssue);
        public string ReservedByLibrarian(ReservedByLibrarian ReservedByLibrarian);
        public List<Member> GetAllUsers();
        public Member GetUser(int id);
        public string AddUser(Member Member);
        public string UpdateUser(Member Member);
        public string DeleteUser(int id);
        public List<BookIssue> IssuedBookByMember(int Memberid);
        public Member BookIssuedToMember(int BookId);

    }
}
