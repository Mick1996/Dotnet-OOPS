using System.ComponentModel.DataAnnotations;

namespace CarryCashApi.Model
{
    public class Owner
    {
        [Key]
        [Required]
        public int Owner_Id { get; set;}
        public string Name { get; set;}
        public string Phone_no { get; set;}
        public string Email { get; set;}
        public string Address { get; set;}

    }
}
