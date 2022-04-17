using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;

namespace Library_Management_System.BAL
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository MemberRepository;  
        public MemberService(IMemberRepository _MemberRepository)
        {
          MemberRepository = _MemberRepository;
        }

        public object SearchByAuthor(string Author)
        {
            return MemberRepository.SearchByAuthor(Author);

        }
        public object SearchByPublicationDate(string PublicationDate)
        {
            return MemberRepository.SearchByPublicationDate(PublicationDate);
        }

        public object SearchBySubjectCategory(string Category)
        {
            return MemberRepository.SearchBySubjectCategory(Category);
        }
        public Book SearchByTitle(string Title)
        {
            return MemberRepository.SearchByTitle(Title);
        }
        public string ReturnBook(BookReturn BookReturn)
        {
            return MemberRepository.ReturnBook(BookReturn);    
        }
        public string BookReservedByMember(ReserveBook ReserveBook)
        {
            string Status=MemberRepository.BookReservedByMember(ReserveBook);
            return Status;
        }
        public string RenewBook(BookIssue BookIssue)
        {
          string Status=MemberRepository.RenewBook(BookIssue);
            return Status;  

        }
    }
}
