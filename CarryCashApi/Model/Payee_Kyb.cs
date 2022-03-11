using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarryCashApi.Model
{
    public class Payee_Kyb
    {
        [Key]
        [Required]
        public string Document_no { get; set;}
        public string Document_type { get; set;}
        public int Payee_Id { get; set;}//belong to payee class
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
    }
}
