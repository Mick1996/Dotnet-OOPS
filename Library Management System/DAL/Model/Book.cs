using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.DAL.Model
{
    public class Book
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set;}
        [Required]
        [Column("title")]
        public string Title { get; set;}
        [Required]
        [Column("author")]
        public string Author { get; set; }
        [Required]
        [Column("rack_no")]
        public int RackNo { get; set; }
        [Required]
        [Column("category")]
        public string Category { get; set; }    
        [Required]
        [Column("publication_date")]
        public string PublicationDate { get; set; }

    }
}
