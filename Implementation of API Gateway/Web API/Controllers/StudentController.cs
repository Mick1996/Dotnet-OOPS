using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_API.Model;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDbContext db;
        public StudentController(StudentDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            List<Student> stud = db.students.Select(x => x).ToList();
            if (stud.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(stud);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            Student st = db.students.Find(id);
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(st);
            }
        }
        [HttpPost]
        public ActionResult CreateNew(Student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public ActionResult UpdateStudent(Student st)
        {
            if (ModelState.IsValid)
            {
                db.students.Update(st);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }
        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            Student stud = db.students.Find(id);
            if (stud == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                db.students.Remove(stud);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
        }
    }
}
