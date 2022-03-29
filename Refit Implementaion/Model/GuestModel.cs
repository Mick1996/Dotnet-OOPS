using System.ComponentModel.DataAnnotations;

namespace Refit_Implementaion.Model
{
    public class GuestModel
    {
        [Key]
        public int Id { get; set; } 
        public string FirstName { get; set;}
        public string LastName { get; set;} 
    }
}
