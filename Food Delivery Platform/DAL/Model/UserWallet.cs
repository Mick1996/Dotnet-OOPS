using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Platform.DAL.Model
{
    [NotMapped]
    public class UserWallet
    {
        public double CashBalance {get; set;}
    }
}
