using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Food_Delivery_Platform.DAL.Model
{
    public class Hotel
    {
        [Key]
        [Column("hotel_id")]
        public int HotelId { get; set;}
        [Column("hotel_name")]
        public string HotelName { get; set;}
        [Column("contact")]
        public string Contact { get; set;}
        [Column("email")]
        public string Email { get; set;}
        [Column("country")]
        public string Country { get; set;}
        [Column("location")]
        public string Location { get; set; }
        [Column("city")]
        public string City { get; set;}
        [Column("pin_code")]
        public int PinCode { get; set; }
        [Column("cash_balance")]
        [JsonIgnore]
        public double CashBalance { get; set; }

    }
}
