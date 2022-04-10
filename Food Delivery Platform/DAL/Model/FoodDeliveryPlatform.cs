using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Platform.DAL.Model
{
    [NotMapped]
    public class FoodDeliveryPlatform //it is just for reference
    {
       public List<Hotel> Hotels { get; set;}
       public List<User> Users { get; set;}
    }
}
