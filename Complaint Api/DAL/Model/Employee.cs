using System.ComponentModel.DataAnnotations;

namespace Complaint_Api.DAL.Model
{
    public class Employee
    {
        [Key]
        public string Email { get; set;}
        public string Name { get; set;} 
        public string Contact { get; set;}  
        public string JobStatus { get; set;}    

    }
}
