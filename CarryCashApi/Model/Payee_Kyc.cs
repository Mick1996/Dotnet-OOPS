using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarryCashApi.Model
{
    public class Payee_Kyc
    {
        [Key]
        [Required]
        public string Document_no{ get; set;}
        public string Document_type{ get; set;} 
        public int Payee_Id { get; set;} //belong to payee
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
    }
}
