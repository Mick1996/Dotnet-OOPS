using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarryCashApi.Model
{
    public class Transaction
    {
        [Key]
        public string Tranx_Id { get; set;}
        public string Tranx_Date_Time { get; set;}
        public decimal Tranx_Amt { get; set;}
        public Guid Merchant_Id { get; set;}
        public DateTime Created {get; set;}
        public DateTime Updated {get; set;}
        public string Created_By {get; set;}
        public string Updated_By {get; set;}
    }
}
