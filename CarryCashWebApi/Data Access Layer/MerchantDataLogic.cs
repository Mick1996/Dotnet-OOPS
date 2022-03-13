using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Data_Access_Layer
{
    public class MerchantDataLogic
    {
        CarryCashDbContext db;
        public MerchantDataLogic(CarryCashDbContext _db)
        {
           db = _db;
        }
        public List<Merchant> RetreiveAllMerchant()
        {
            return db.merchant.Select(x => x).ToList();
        }
        public Merchant MerchantById(Guid id)
        {
            return db.merchant.Where(x => x.Merchant_Id == id).FirstOrDefault();
        }
        public void AddMerchant(Merchant _merchant)
        {
            db.merchant.Add(_merchant);
            db.SaveChanges();
        }
        public void UpdateMerchantData(Merchant merchant)
        {
            db.merchant.Update(merchant);
            db.SaveChanges();
        }
        public int DeleteSpecificMerchant(Guid id)
        {
            var merchant = db.merchant.Find(id);
            if (merchant != null)
            {
                db.merchant.Remove(merchant);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
