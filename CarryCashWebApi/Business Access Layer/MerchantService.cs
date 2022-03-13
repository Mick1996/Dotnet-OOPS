using CarryCashWebApi.Data_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Business_Access_Layer
{
    public class MerchantService
    {
        MerchantDataLogic merchantdatalogic;
        public MerchantService(CarryCashDbContext _db) 
        {
           merchantdatalogic= new MerchantDataLogic(_db);
        }
        public List<Merchant> RetreiveAllMerchant()
        {
            return merchantdatalogic.RetreiveAllMerchant();
        }
        public Merchant MerchantById(Guid id)
        {
            return merchantdatalogic.MerchantById(id);
        }
        public void AddMerchant(Merchant merchant) 
        {
            merchantdatalogic.AddMerchant(merchant);
        }
        public void UpdateMerchantData(Merchant merchant)
        {
            merchantdatalogic.UpdateMerchantData(merchant);
        }
        public int DeleteSpecificMerchant(Guid id)
        {
            var merchant = merchantdatalogic.DeleteSpecificMerchant(id);
            if (merchant==1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

