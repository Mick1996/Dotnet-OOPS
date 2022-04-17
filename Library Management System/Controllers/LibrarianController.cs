using Library_Management_System.DAL.Model;
using Library_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library_Management_System.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService LibrarianService;
        public LibrarianController(ILibrarianService _LibrarianService)
        {
            LibrarianService = _LibrarianService;
        }
        [HttpGet]
        [Route("getAllBooks")]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
             List<Book> ListOfBooks=LibrarianService.GetAllBooks();
              if(ListOfBooks.Count!=0)
                   return Ok(ListOfBooks); 
              else
                 return NotFound();
        }
        [HttpPost]
        [Route("addBook")]
        public ActionResult AddBook([FromBody] Book Book)
        {
            if (ModelState.IsValid)
            {
                string Status = LibrarianService.AddBook(Book);
                return Ok(Status);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("getBook/{id}")]
        public ActionResult<Book> GetBook(int id)
        { 
          Book Book=LibrarianService.GetBook(id);
            if (Book != null)
                return Ok(Book);
            else
                return NotFound();
        }
        [HttpPut]
        [Route("updateBook")]
        public ActionResult UpdateBook([FromBody] Book Book)
        {
            if (ModelState.IsValid)
            {
                string Status = LibrarianService.UpdateBook(Book);
                return Ok(Status);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("deleteBook/{id}")]
        public ActionResult DeleteBook(int id)
        {
          string Status=LibrarianService.DeleteBook(id);
            return Ok(Status);

        }
        [HttpPost]
        [Route("issueBook")]
        public ActionResult IssueBook([FromBody] BookIssue BookIssue)
        {
          if(ModelState.IsValid)
            {
                string Status=LibrarianService.IssueBook(BookIssue);
                return Ok(Status);
            }
            return BadRequest();
        }
         [HttpPost]
         [Route("reservedByLibrarian")]
         public ActionResult ReservedByLibrarian([FromBody] ReservedByLibrarian ReservedByLibrarian)
        {
           string Status=LibrarianService.ReservedByLibrarian(ReservedByLibrarian);
            return Ok(Status);
        }
        [HttpGet]
        [Route("~/api/v1/user/getAllUsers")]
        public ActionResult<IEnumerable<Member>> GetAllUsers()
        {
           List<Member> ListOfUsers= LibrarianService.GetAllUsers();
           return Ok(ListOfUsers);  
        }
        [HttpPost]
        [Route("~/api/v1/user/getUser/{id}")]
        public ActionResult<Member> GetUser(int id)
        {
         Member Member= LibrarianService.GetUser(id);
            if(Member!=null)
                 return Ok(Member);
            else
                return NotFound();
        }
        [HttpPost]
        [Route("~/api/v1/user/addUser")]
        public ActionResult AddUser([FromBody] Member Member)
        {
            if (ModelState.IsValid)
            {
                string Status = LibrarianService.AddUser(Member);
                return Ok(Status);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("~/api/v1/user/updateUser")]
        public ActionResult UpdateUser([FromBody] Member Member)
        {
            if(ModelState.IsValid)
            {
                string Status=LibrarianService.UpdateUser(Member);
                return Ok(Status);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("~/api/v1/user/deleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
          string Status=LibrarianService.DeleteUser(id);
            return Ok(Status);
        }
        [HttpGet]
        [Route("bookIssuedByMember")]
        public ActionResult<IEnumerable<BookIssue>> GetIssuedBookByMember(int MemberId)
        {
            List<BookIssue> IssuedBook=LibrarianService.IssuedBookByMember(MemberId);
            if(IssuedBook.Count!=0)
            return Ok(IssuedBook);
            return NotFound("No book Issued to this member");
        }
        [HttpGet]
        [Route("bookIssuedToMember")]
        public ActionResult<Member> BookIssuedToMember(int BookId)
        {
            Member Member=LibrarianService.BookIssuedToMember(BookId);
            if(Member!=null)
                 return Ok(Member);
            return NotFound();
        }
    }
}
