using CarryCashApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeeController : ControllerBase
    {
        CarryCashDbContext db;
          public PayeeController(CarryCashDbContext _db)
        {
            db= _db;    
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee>> GetAllPayee()
        {
            var payee=db.payee.Select(x=>x).ToList();
            if(payee.Count==0)
                return NotFound();  
            else
                return Ok(payee);   
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Payee> GetPayeeById(int id)
        {
            var payee = db.payee.Where(x => x.Payee_Id == id).FirstOrDefault();
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
                db.payee.Add(payee);
                db.SaveChanges();
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
                db.payee.Update(payee);
                db.SaveChanges();
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
           Payee p= db.payee.Find(id);
            if (p != null)
            {
                db.payee.Remove(p);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("id does not exist");
            }
        }
    }
}





