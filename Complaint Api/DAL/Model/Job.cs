using System;
using System.ComponentModel.DataAnnotations;

namespace Complaint_Api.DAL.Model
{
    public class Job
    {
        [Key]
        public int Id { get; set;} 
        public string JobTitle { get; set;}
        public double Salary { get; set;}
        public string Status { get; set;}//open or close
        public string JobType { get; set;} 
        public int VendorId { get; set;} 
        public DateTime CreatedOn { get; set;}
    }
}
