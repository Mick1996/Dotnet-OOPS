using CarryCashApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi.Controllers
{
    [Route("api/[controller]")]  //or [Route("api/v1/[controller]")] Custom Routing
    [ApiController]
    public class TransactionController : ControllerBase
    {
        CarryCashDbContext db;
         public TransactionController(CarryCashDbContext _db)
        {
            db = _db;  
        }
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransaction()
        {
            var trascation=db.transactions.Select(x=>x).ToList();
            if(trascation.Count==0)
            {
              return NotFound();
            }
            else
            {
               return trascation;
            }
        }
        [HttpGet]
        [Route("{id}")]
         public ActionResult GetTransactionById(string id) //Tranx_Id taken as string
        {
            var Trans=db.transactions.Where(x => x.Tranx_Id == id).Select(x => x).ToList();
            if (Trans.Count == 0)
                return NotFound();
            else
                return Ok(Trans);
        }
        [HttpPost]
        public ActionResult CreateTransaction(Transaction trnx)
        {
            var merchantid = db.merchant.Find(trnx.Merchant_Id);
            if (merchantid == null)
            {
                return NotFound("Merchant doesn't exist");
            }
           else if (ModelState.IsValid)
            {
                db.transactions.Add(trnx);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
 