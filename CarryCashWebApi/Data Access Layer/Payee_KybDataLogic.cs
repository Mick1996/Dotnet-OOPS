using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Data_Access_Layer
{
    public class Payee_KybDataLogic
    {
          CarryCashDbContext db;
         public Payee_KybDataLogic(CarryCashDbContext _db)
        {
           db= _db; 
        }
        public List<Payee_Kyb> RetreiveAllPayee_Kyb()
        {
            return db.payee_kyb.Select(x => x).ToList();
        }
        public Payee_Kyb SpecificPayee_KybById(int id)
        {
            return db.payee_kyb.Where(x => x.Payee_Id == id).FirstOrDefault();
        }
        public int AddPayeeKyb(Payee_Kyb payee_kyb)
        {
            var payee = db.payee.Where(x => x.Payee_Id == payee_kyb.Payee_Id).FirstOrDefault();
            if (payee != null)
            {
                db.payee_kyb.Add(payee_kyb);
                db.SaveChanges();
                UpdatePayee(payee_kyb.Payee_Id);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void UpdatePayee(int id) //this method is only updating for Is_Kyc
        {
            var payeeRecord = db.payee.Where(x => x.Payee_Id == id).FirstOrDefault();
            payeeRecord.IsKyb = true; //it will set true if Paye_Kyc is done.
            db.SaveChanges();
        }
        public void UpdatePayeekybData(Payee_Kyb p)
        {
            db.payee_kyb.Update(p);
            db.SaveChanges();
        }
        public int DeletePayeeKybData(int id)
        {
            var payeekyb = db.payee_kyb.Find(id);
            if (payeekyb != null)
            {
                db.Remove(payeekyb);
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
