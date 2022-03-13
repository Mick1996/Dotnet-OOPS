using CarryCashWebApi.Business_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeeController : ControllerBase
    {
        PayeeService payeeservice;
        public PayeeController(CarryCashDbContext _db)
        {
           payeeservice= new PayeeService(_db);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee>> GetAllPayee()
        {
            var payee = payeeservice.RetreiveAllPayee();
            if (payee == null)
                return NotFound();
            else
                return Ok(payee);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Payee> GetPayeeById(int id)
        {
            var payee = payeeservice.RetreivePayeeById(id);
            if (payee == null)
            {
                return NotFound();
            }
            else
                return Ok(payee);
        }
        [HttpPost]
        public ActionResult CreatePayee(Payee payee)
        {
            if (ModelState.IsValid)
            {
                payeeservice.AddPayee(payee);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult UpdatePayee(Payee payee)
        {
            if (ModelState.IsValid)
            {
                payeeservice.UpdatePayeeData(payee);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletePayee(int id)
        {
            int p = payeeservice.DeletePayeeData(id);
            if (p == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("id does not exist");
            }
        }
    }
}
