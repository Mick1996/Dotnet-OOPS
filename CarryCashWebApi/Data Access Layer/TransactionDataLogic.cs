using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;

namespace CarryCashWebApi.Data_Access_Layer
{
    public class TransactionDataLogic
    {
        CarryCashDbContext db;
        public TransactionDataLogic(CarryCashDbContext _db)
        {
          db= _db;  
        }
        public List<Transaction> RetreiveAllTransaction()
        {
            return db.transactions.Select(x => x).ToList();
        }
        public Transaction SpecificTransactionById(string id)
        {
            return db.transactions.Where(x => x.Tranx_Id == id).Select(x => x).FirstOrDefault();
        }
        public int AddTransaction(Transaction trans)
        {
            var merchant = db.merchant.Find(trans.Merchant_Id);
            if (merchant != null)
            {
                db.transactions.Add(trans);
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
