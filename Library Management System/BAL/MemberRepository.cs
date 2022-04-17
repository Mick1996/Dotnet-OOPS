using Library_Management_System.DAL.DbContextRepo;
using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;
using System;
using System.Linq;

namespace Library_Management_System.BAL
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryDbContext Db; 
        public MemberRepository(LibraryDbContext _Db)
        {
           Db=_Db;  
        }
        public object SearchByAuthor(string Author)
        {
            return Db.books.Where(x => x.Author == Author).Select(x => x).ToList();
        }

        public object SearchByPublicationDate(string PublicationDate)
        {
            return Db.books.Where(x => x.PublicationDate == PublicationDate).Select(x => x).ToList();
        }
        public object SearchBySubjectCategory(string Category)
        {
            return Db.books.Where(x => x.Category == Category).Select(x => x).ToList();
        }
        public Book SearchByTitle(string Title)
        {
            return Db.books.Where(x => x.Title == Title).Select(x => x).FirstOrDefault();
        }
        public string ReturnBook(BookReturn BookReturn)
        {
            int TotalFine=0;
            BookIssue BookIssued = Db.bookissues.Where(x => x.BookId == BookReturn.BookId && x.MemberId == BookReturn.MemberId).Select(x => x).FirstOrDefault(); ;
            if (BookIssued.DueDate.Date < BookReturn.ReturnDate.Date)
            {
                int Days = (BookReturn.ReturnDate.Date - BookIssued.DueDate.Date).Days;
                TotalFine = Days * 5;
                if (BookReturn.Fine == TotalFine)
                {
                    BookReturning(BookReturn);
                    BookIssued.IsReturn = true;//set true if book returned
                    return "Book return Successfully";
                }
                return $"You need to Pay {TotalFine}Rs Fine";
            }
            else
            {
                BookReturning(BookReturn);
                BookIssued.IsReturn = true; //set true if book returned
                return "Book return Successfully";
            }
        }
        public void BookReturning(BookReturn BookReturn)
        {
          Db.bookreturns.Add(BookReturn);
            Db.SaveChanges();
        }
        public string BookReservedByMember(ReserveBook ReserveBook)
        {
             Db.reservebooks.Add(ReserveBook); 
              Db.SaveChanges();
               return "Book Reserved Successfully";
        }
        public string RenewBook(BookIssue BookIssue)
        {
            Db.bookissues.Add(BookIssue);  
            Db.SaveChanges();
            return "Book renew successfully";
        }
    }
}
