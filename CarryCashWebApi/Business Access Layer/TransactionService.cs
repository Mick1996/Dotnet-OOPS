using CarryCashWebApi.Data_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;
namespace CarryCashWebApi.Business_Access_Layer
{
    public class TransactionService
    {
        TransactionDataLogic transactiondatalogic;
         public TransactionService(CarryCashDbContext _db)
        {
            transactiondatalogic = new TransactionDataLogic(_db);
        }
        public List<Transaction> RetreiveAllTransaction()
        {
            return transactiondatalogic.RetreiveAllTransaction();
        }
        public Transaction SpecificTransactionById(string id)
        {
            return transactiondatalogic.SpecificTransactionById(id);
        }
        public int AddTransaction(Transaction trans)
        {
            var merchant = transactiondatalogic.AddTransaction(trans);
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
