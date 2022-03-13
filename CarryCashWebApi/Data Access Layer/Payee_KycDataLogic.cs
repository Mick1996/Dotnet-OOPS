using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Data_Access_Layer
{
    public class Payee_KycDataLogic
    {
        CarryCashDbContext db;
        public Payee_KycDataLogic(CarryCashDbContext _db)
        {
           db= _db; 
        }
        public List<Payee_Kyc> RetreiveAllPayee_Kyc()
        {
            return db.payee_kyc.Select(x => x).ToList();
        }
        public Payee_Kyc SpecificPayee_KycById(int id)
        {
            return db.payee_kyc.Where(x => x.Payee_Id == id).FirstOrDefault();
        }
        public int AddPayeeKyc(Payee_Kyc payee_kyc)
        {
            var payee = db.payee.Where(x => x.Payee_Id == payee_kyc.Payee_Id).FirstOrDefault();
            if (payee != null)
            {
                db.payee_kyc.Add(payee_kyc);
                db.SaveChanges();
                UpdatePayee(payee_kyc.Payee_Id);
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
            payeeRecord.IsKyc = true; //it will set true if Paye_Kyc is done.
            db.SaveChanges();
        }
        public void UpdatePayeekycData(Payee_Kyc p)
        {
            db.payee_kyc.Update(p);
            db.SaveChanges();
        }
        public int DeletePayeeKycData(int id)
        {
            var payeekyc = db.payee_kyc.Find(id);
            if (payeekyc != null)
            {
                db.Remove(payeekyc);
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
