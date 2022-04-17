using Library_Management_System.DAL.Model;

namespace Library_Management_System.IRepository
{
    public interface IMemberService
    {
        public Book SearchByTitle(string Title);
        public object SearchByAuthor(string Author);
        public object SearchBySubjectCategory(string Category);
        public object SearchByPublicationDate(string PublicationDate);
        public string ReturnBook(BookReturn BookReturn);
        public string BookReservedByMember(ReserveBook ReserveBook);
        public string RenewBook(BookIssue BookIssue);
    }
}
