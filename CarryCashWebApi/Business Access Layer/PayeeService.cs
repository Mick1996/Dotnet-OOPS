using CarryCashWebApi.Data_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Business_Access_Layer
{
    public class PayeeService
    {
        PayeeDataLogic payeedatalogic;
        public PayeeService(CarryCashDbContext _db)
        {
            payeedatalogic=new PayeeDataLogic(_db);
        }
        public List<Payee> RetreiveAllPayee()
        {
            return payeedatalogic.RetreiveAllPayee();
        }
        public Payee RetreivePayeeById(int id)
        {
            return payeedatalogic.RetreivePayeeById(id);
        }
        public void AddPayee(Payee payee)
        {
            payeedatalogic.AddPayee(payee);
        }
        public void UpdatePayeeData(Payee payee)
        {
            payeedatalogic.UpdatePayeeData(payee);
        }
        public int DeletePayeeData(int id)
        {
            var payee = payeedatalogic.DeletePayeeData(id);
            if (payee==1)
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
