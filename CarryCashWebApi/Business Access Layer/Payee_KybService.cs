using CarryCashWebApi.Data_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Business_Access_Layer
{
    public class Payee_KybService
    {
        Payee_KybDataLogic payee_kybdatalogic;
        public Payee_KybService(CarryCashDbContext _db)
        {
            payee_kybdatalogic=new Payee_KybDataLogic(_db);
        }
        public List<Payee_Kyb> RetreiveAllPayee_Kyb()
        {
            return payee_kybdatalogic.RetreiveAllPayee_Kyb();
        }
        public Payee_Kyb SpecificPayee_KybById(int id)
        {
            return payee_kybdatalogic.SpecificPayee_KybById(id);
        }
        public int AddPayeeKyb(Payee_Kyb payee_kyb)
        {
            var payee = payee_kybdatalogic.AddPayeeKyb(payee_kyb);
            if (payee==1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void UpdatePayeekybData(Payee_Kyb p)
        {
            payee_kybdatalogic.UpdatePayeekybData(p);
        }
        public int DeletePayeeKybData(int id)
        {
            var payeekyb = payee_kybdatalogic.DeletePayeeKybData(id);
            if (payeekyb==1)
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
