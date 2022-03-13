using CarryCashWebApi.Data_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Services
{
    public class Payee_KycService
    {
        Payee_KycDataLogic payeedatalogic;  
        public Payee_KycService(CarryCashDbContext _db)
        {
            payeedatalogic = new Payee_KycDataLogic(_db); 
        }
        public List<Payee_Kyc> RetreiveAllPayee_Kyc()
        {
            return payeedatalogic.RetreiveAllPayee_Kyc();
        }
        public Payee_Kyc SpecificPayee_KycById(int id)
        {
            return payeedatalogic.SpecificPayee_KycById(id);  
        }
        public int AddPayeeKyc(Payee_Kyc payee_kyc)
        {
            var payee= payeedatalogic.AddPayeeKyc(payee_kyc);
            if (payee==1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public void UpdatePayeekycData(Payee_Kyc p)
        {
            payeedatalogic.UpdatePayeekycData(p);
        }
        public int DeletePayeeKycData(int id)
        {
            var payeekyc= payeedatalogic.DeletePayeeKycData(id);
            if (payeekyc==1)
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




