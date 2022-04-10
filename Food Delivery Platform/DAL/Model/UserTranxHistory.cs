using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Platform.DAL.Model
{
    public class UserTranxHistory
    {
       [Key]
      [Column("tranx_id")]
      public int TranxId { get; set;} 
      [Column("tranx_date_time")]
      public DateTime TranxDateTime { get; set; }
      [Column("item")]
      public string Item { get; set;}
      [Column("tranx_amt")]
      public double TranxAmt { get; set;}
       [Column("user_id")]
       public int UserId { get; set;}
    }
}