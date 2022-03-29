using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation_Api.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Course { get; set;}
        public string Address { get; set;} 
    }
}
