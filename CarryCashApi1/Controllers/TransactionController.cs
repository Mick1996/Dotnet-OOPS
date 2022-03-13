using CarryCashApi1.Model;
using CarryCashApi1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace CarryCashApi1.Controllers //2 tier architecture
{
    [Route("api/[controller]")]  //or [Route("api/v1/[controller]")] Custom Routing
    [ApiController]
    public class TransactionController : ControllerBase
    {
        TransactionService transactionservice;
         public TransactionController(CarryCashDbContext _db)
        {
            transactionservice =new TransactionService(_db);  
        }
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransaction()
        {
            var trascation=transactionservice.RetreiveAllTransaction();
            if(trascation==null)
            {
              return NotFound();
            }
            else
            {
               return Ok(trascation);
            }
        }
        [HttpGet]
        [Route("{id}")]
         public ActionResult GetTransactionById(string id) //Tranx_Id taken as string
        {
            var Trans = transactionservice.SpecificTransactionById(id);
            if (Trans==null)
                return NotFound();
            else
                return Ok(Trans);
        }
        [HttpPost]
        public ActionResult CreateTransaction(Transaction trnx)
        {
            if (ModelState.IsValid)
            {
                int merchantid = transactionservice.AddTransaction(trnx);
                if (merchantid == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Merchant doesn't exist");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
 