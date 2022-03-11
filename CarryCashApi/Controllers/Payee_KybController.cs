using CarryCashApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payee_KybController : ControllerBase
    {
        CarryCashDbContext db;
        public Payee_KybController(CarryCashDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee_Kyb>> GetAllPayeeKyb()
        {
            var payeekyb = db.payee_kyb.Select(x => x).ToList();
            if (payeekyb.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(payeekyb);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Payee_Kyb> GetPayeeKybById(int id)
        {
            var payeekyb = db.payee_kyb.Where(x => x.Payee_Id == id).FirstOrDefault();
            if (payeekyb != null)
                return Ok(payeekyb);
            else
                return NotFound();
        }
        [HttpPost]
        public ActionResult CreatePayeeKyb(Payee_Kyb p)
        {
            var payeeid = db.payee.Find(p.Payee_Id);
            if(payeeid==null)
            {
                return NotFound("Payee doesn't exist");
            }
            else if (ModelState.IsValid)
            {
                UpdatePayee(p.Payee_Id); //set Payee Kyb true if Kyb done
                db.payee_kyb.Add(p);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [NonAction]  //this method is only updating for Is_Kyb
        public void UpdatePayee(int id) //it will update Is Kyb True if kyb done
        {
            var payeeRecord = db.payee.Where(x => x.Payee_Id == id).FirstOrDefault();
            payeeRecord.IsKyb = true;
            db.SaveChanges();
        }
        [HttpPut]
        public ActionResult UpdatePayeeKyb(Payee_Kyb p)
        {
            if (ModelState.IsValid)
            {
                db.payee_kyb.Update(p);
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
            var payeekyb = db.payee_kyb.Find(id);
            if (payeekyb != null)
            {
                db.Remove(payeekyb);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
