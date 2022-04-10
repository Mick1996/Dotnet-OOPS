using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Food_Delivery_Platform.DAL.Model
{
    public class HotelStatus
    {
        [Key]
        [Column("id")]
        [JsonIgnore]
        public int Id { get; set;}   //just to add primary key in this table
        [Column("hotel_id")]
        public int HotelId { get; set;}
        [Column("hotel_name")]
        public string HotelName { get; set;}
        [Column("date_time")]
        public DateTime DateTime { get; set; }= DateTime.Now;
        [Column("status")]
        public string Status { get; set; }
    }
}
