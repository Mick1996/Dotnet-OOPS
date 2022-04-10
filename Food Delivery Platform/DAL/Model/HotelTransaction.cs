using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Platform.DAL.Model
{
    public class HotelTransaction
    {
        [Key]
        [Column("tranx_id")]
        public int TranxId { get; set;}
        [Column("hotel_id")]
        public int HotelId { get; set; }
        [Column("tranx_date")]
        public DateTime TranxDate { get; set;}
        [Column("item_name")]
        public string ItemName { get; set; }
        [Column("tranx_amt")]
        public double TranxAmt { get; set; }    
    }
}
