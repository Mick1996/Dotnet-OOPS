using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Food_Delivery_Platform.DAL.Model
{
    public class User
    { 
        [Key]
        [Column("user_id")]
        public int UserId { get; set;}  
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("contact")]
        public string Contact { get; set;}
        [Column("email")]
        public string Email { get; set; }
        [Column("country")]
        public string Country { get; set;}
        [Column("city")]
        public string City { get; set;}
        [Column("locality")]
        public string Locality { get; set; }
        [Column("pin_code")]
        public int PinCode { get; set;}
        [Column("cash_balance")]
        [JsonIgnore]
        public double CashBalance { get; set;}
    }
}
