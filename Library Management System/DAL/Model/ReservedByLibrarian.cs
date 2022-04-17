using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library_Management_System.DAL.Model
{
    public class ReservedByLibrarian
    {
        [Key]
        [Column("id")]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [Column("book_id")]
        public int BookId { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("author")]
        public string Author { get; set; }
        [Required]
        [Column("rack_no")]
        public int RackNo { get; set; }
        [Required]
        [Column("publication_date")]
        public string PublicationDate { get; set; }
    }
}
