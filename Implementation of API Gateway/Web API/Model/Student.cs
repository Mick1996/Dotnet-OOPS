using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Model
{
    public class Student
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Column("Name")]
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }

    }
}
