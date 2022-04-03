using System;
using System.ComponentModel.DataAnnotations;

namespace Complaint_Api.DAL.Model
{
    public class Complaint
    { 
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } //who complaint
        public string HandelledBy { get; set;} //which vendor
        public DateTime UpdatedOn { get; set;}
        public DateTime CreatedOn { get; set;}
        public string Description { get; set;}
        public int Reopened { get; set; }
    }
}
