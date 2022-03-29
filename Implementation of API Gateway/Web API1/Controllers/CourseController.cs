using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_API1.Model;

namespace Web_API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        StudentDbContext db;
        public CourseController(StudentDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourse()
        {
            List<Course> courses = db.courses.Select(x => x).ToList();
            if(courses.Count==0)
            {
                return NotFound(); 
            }
            else
            {
                return Ok(courses);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
           Course course= db.courses.Find(id);
            if(course==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(course);
            }
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
           if(ModelState.IsValid)
            {
                db.courses.Add(course);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpPut]
        public ActionResult UpdateCourse(Course course)
        {
            if(ModelState.IsValid)
            {
                db.courses.Update(course);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK); 
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpDelete]
        public ActionResult DeleteCourse(int id)
        {
            Course course=db.courses.Find(id);
            if(course==null)
            {
                return NotFound();
            }
            else
            {
              db.courses.Remove(course);    
              db.SaveChanges();
                return Ok();
            }
        }

    }
}








