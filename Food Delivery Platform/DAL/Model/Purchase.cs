using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Platform.DAL.Model
{
    [NotMapped]
    public class Purchase
    {
        public int UserId { get; set;}
        public int HotelId { get; set;}
        public string DishName { get; set;}
    }
}
