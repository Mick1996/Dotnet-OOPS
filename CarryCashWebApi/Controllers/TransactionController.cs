using CarryCashWebApi.Business_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        TransactionService transactionservice;
       public TransactionController(CarryCashDbContext _db)
        {
            transactionservice = new TransactionService(_db);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransaction()
        {
            var trascation = transactionservice.RetreiveAllTransaction();
            if (trascation == null)
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
            if (Trans == null)
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
