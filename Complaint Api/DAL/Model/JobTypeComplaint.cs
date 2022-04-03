using System.ComponentModel.DataAnnotations.Schema;

namespace Complaint_Api.DAL.Model
{
    [NotMapped]
    public class JobTypeComplaint //it is just for employee who will file Complaint
    {
      public string Email { get; set;}
      public string JobType { get; set;}
      public string Description { get; set;}
    }
}
