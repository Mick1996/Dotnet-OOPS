using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library_Management_System.DAL.Model
{
    public class BookReturn
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public int Id { get; set; } 
        [Column("book_id")]
        [Required]
        public int BookId { get; set;}
        [Required]
        [Column("member_id")]
        public int MemberId { get; set; }
        [Required]
        [Column("book_title")]
        public string BookTitle { get; set;}
        [Required]
        [Column("return_date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set;}
        [Required]
        [Column("fine")]
        public int Fine { get; set;}

    }
}
