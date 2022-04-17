using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library_Management_System.DAL.Model
{
    public class ReserveBook
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public int Id { get; set; } 
        [Column("book_id")]
        public int BookId { get; set;}
        [Required]
        [Column("book_title")]
        public string BookTitle { get; set;}    
        [Required]
        [Column("member_id")]
        public int MemberId { get; set;}
        [Required]
        [Column("beginning_date")]
        [DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }
        [Required]
        [Column("ending_date")]
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }

    }
}
