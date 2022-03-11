using System.ComponentModel.DataAnnotations;

namespace CarryCashApi.Model
{
    public class Payee
    {
        [Key]
        [Required]
        public int Payee_Id { get; set;}
        public string Payee_Name { get; set;}
        public string Address { get; set;}
        public string Phone_no { get; set;}
        public string Email { get; set;}
        public bool IsKyc { get; set;}=false;
        public bool IsKyb { get; set;}=false ;
        public bool Is_Individual { get; set;}=false;    
        public string Occupation { get; set;}
        public DateTime Created { get; set;}
        public DateTime Updated { get; set;}
        public string Created_By { get; set;}
        public string Updated_By { get; set;}
    }
}
