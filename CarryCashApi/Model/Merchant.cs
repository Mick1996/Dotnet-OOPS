using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarryCashApi.Model
{
    public class Merchant
    {
        [Key]
       [Required]
      public Guid Merchant_Id { get; set;} //Merchant_Id Generates automatically
      public string Name { get; set;}
      public string Address { get; set;}
      public string Business_Description { get; set;}
      public string Phone_no { get; set;}
     public string Type_of_business { get; set;}
     public string CorporateStatus { get; set;}
     public decimal Excepted_amount_of_disbursment { get; set;}
     public string Fax { get; set;}
     public decimal Anually_Income { get; set;}
     public string Registration_no { get; set;}
     public DateTime Created { get; set;}
     public DateTime Updated { get; set;}
     public string Created_By { get; set;}
     public string Updated_By { get; set;}
    }
}
