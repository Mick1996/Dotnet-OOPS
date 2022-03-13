﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarryCashWebApi.Model    //3 Teir Architecture web Api
{
    public class Merchant
    {
        [Key]
        [Required]
        public Guid Merchant_Id { get; set; } //Merchant_Id Generates automatically
        public int Owner_Id { get; set; } //owner of Merchant(Business)
        [ForeignKey("Owner_Id")]
        public virtual Owner owner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Business_Description { get; set; }
        public string Phone_no { get; set; }
        public string Type_of_business { get; set; }
        public string CorporateStatus { get; set; }
        public decimal Excepted_amount_of_disbursment { get; set; }
        public string Fax { get; set;}
        public decimal Anually_Income { get; set; }
        public string Registration_no { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
    }
}
