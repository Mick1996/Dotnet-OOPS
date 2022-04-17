using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService MemberService;
        public MemberController(IMemberService _MemberService)
        {
            MemberService = _MemberService;
        }
        [HttpGet]
        [Route("byTitle")]
        public ActionResult<Book> SearchBookByTitle(string Title)
        {
            Book Book=MemberService.SearchByTitle(Title);
            if (Book != null)
                return Ok(Book);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("byAuthor")]
        public ActionResult<Book> SearchByAuthor(string Author)
        {
            object Book= MemberService.SearchByAuthor(Author);
            if (Book != null)
                return Ok(Book);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("bySubjectCategory")]
        public ActionResult<Book> SearchBySubjectCategory(string Category)
        {
            object Book=MemberService.SearchBySubjectCategory(Category);
                if (Book != null)
                return Ok(Book);
            else
                return NotFound();
        }
        [HttpGet]
        [Route("byPublicationDate")]
        public ActionResult<Book> SearchByPublicationDate(string PublicationDate)
        {
            object Book = MemberService.SearchByPublicationDate(PublicationDate);
                if (Book != null)
                return Ok(Book);
            else
                return NotFound();
        }
        [HttpPost]
        [Route("return")]
        public ActionResult ReturnBook([FromBody] BookReturn BookReturn)
        {
            if (ModelState.IsValid)
            {
                string Status = MemberService.ReturnBook(BookReturn);
                return Ok(Status);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("bookReservedByMember")]
        public ActionResult BookReservedByMember([FromBody] ReserveBook ReserveBook)
        {
           if(ModelState.IsValid)
            {
               string Status= MemberService.BookReservedByMember(ReserveBook);
                return Ok(Status);  
            }
            return BadRequest();   
        }
        [HttpPost]
        [Route("renewBook")]
        public ActionResult RenewBook([FromBody]BookIssue BookIssue)
        {
            string Status=MemberService.RenewBook(BookIssue);
            return Ok(Status);  
        }
    }
}
