using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Food_Delivery_Platform.DAL.Model
{
    public class HotelMenu
    {
       [Key]
       [JsonIgnore]
       [Column("id")] //it is just for primary key 
       public int Id { get; set;}
       [Column("hotel_id")]
       public int HotelId { get; set;}
       [Column("dish_name")]
       public string DishName { get; set;}
       [Column("price")]
       public int Price { get; set;}
    }
}
