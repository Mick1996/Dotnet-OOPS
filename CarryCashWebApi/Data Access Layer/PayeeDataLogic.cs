using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Data_Access_Layer
{
    public class PayeeDataLogic
    {
        CarryCashDbContext db;
        public PayeeDataLogic(CarryCashDbContext _db)
        {
            db = _db;
        }
        public List<Payee> RetreiveAllPayee()
        {
            return db.payee.Select(x => x).ToList();
        }
        public Payee RetreivePayeeById(int id)
        {
            return db.payee.Where(x => x.Payee_Id == id).FirstOrDefault();
        }
        public void AddPayee(Payee payee)
        {
            db.payee.Add(payee);
            db.SaveChanges();
        }
        public void UpdatePayeeData(Payee payee)
        {
            db.payee.Update(payee);
            db.SaveChanges();
        }
        public int DeletePayeeData(int id)
        {
            var payee = db.payee.Find(id);
            if (payee != null)
            {
                db.payee.Remove(payee);
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
