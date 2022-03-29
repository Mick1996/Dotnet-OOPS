using CRUD_Operation_Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_Operation_Api.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> students = new List<Student>()
        {
           new Student(){Id=1,Name="Micky",Address="Okhla",Course="Mca" },
           new Student(){Id=2,Name="Rahul",Address="noida",Course="Mba" },
           new Student{Id=3,Name="Sam",Address="dwarka",Course="BBA"}
        };
        public StudentController()
        {

        }
        [HttpGet]
        public List<Student> GetAll()
        {
            return students.Select(x => x).ToList();
        }
        [HttpPost]
        public Student Create(Student student)
        {
                students.Add(student);
                return student;  
        }
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            var st=students.Where(x => x.Id == id).FirstOrDefault();
            return st.Name;
        }
        [HttpPut]
        public Student UpdateStudent(Student student)
        {
            students.Add(student);
            return student;
        }
        [HttpDelete("{id}")]
        public string DeleteStudent(int id)
        {
            Student stud=students.Where(x => x.Id == id).FirstOrDefault();
              students.Remove(stud);
               return stud.Name;
            
        }
    }
}



