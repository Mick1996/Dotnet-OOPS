using CarryCashApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payee_KycController : ControllerBase
    {
        CarryCashDbContext db;
        public Payee_KycController(CarryCashDbContext _db)
        {
               db= _db;   
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee_Kyc>> GetAllPayeeKyc()
        {
            var payeekyc=db.payee_kyc.Select(x => x).ToList();
            if(payeekyc.Count==0)
            {
                return NotFound();
            }
            else
            {
                return Ok(payeekyc);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Payee_Kyc> GetPayeeKycById(int id)
        {
           var payeekyc= db.payee_kyc.Where(x => x.Payee_Id == id).FirstOrDefault();
            if(payeekyc!=null)
            return Ok(payeekyc);
            else
                return NotFound();  
        }
        [HttpPost]
        public ActionResult CreatePayeeKyc(Payee_Kyc p)
        {
            var payeeid = db.payee.Find(p.Payee_Id);
            if (payeeid == null)
            {
                return NotFound("Payee doesn't exist");
            }
            else if (ModelState.IsValid)
            {
                UpdatePayee(p.Payee_Id);//set Is_kyc true if kyc done. 
                db.payee_kyc.Add(p);
                db.SaveChanges();
                return Ok();
            }
            else
            {
              return BadRequest();
            }
        }
        [NonAction]
         public void UpdatePayee(int id) //this method is only updating for Is_Kyb
        {
           var payeeRecord=db.payee.Where(x=>x.Payee_Id==id).FirstOrDefault();
            payeeRecord.IsKyc = true;
            db.SaveChanges();
        }
        [HttpPut]
        public ActionResult UpdatePayeeKyc(Payee_Kyc p)
        {
            if (ModelState.IsValid)
            {
                db.payee_kyc.Update(p);
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
            var payeekyc=db.payee_kyc.Find(id);
            if (payeekyc!= null)
            {
                db.payee_kyc.Remove(payeekyc);
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
