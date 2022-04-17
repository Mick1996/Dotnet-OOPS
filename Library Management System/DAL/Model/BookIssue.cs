using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library_Management_System.DAL.Model
{
    public class BookIssue
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public int Id { get; set; } 
        [Required]
        [Column("book_id")]
        public int BookId { get; set;}
        [Required]
        [Column("book_title")]
        public string BookTitle { get; set;}
        [Required]
        [Column("member_id")]
        public int MemberId { get; set;}
        [Required]
        [Column("issue_date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set;}
        [Required]
        [Column("due_date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set;}
        [Required]
        [Column("is_return")]
        public bool IsReturn { get; set;}=false;
    }
}
