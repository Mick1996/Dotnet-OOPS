using CarryCashApi1.Model;
using CarryCashApi1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payee_KycController : ControllerBase
    {
        Payee_KycService payee_kycservice;
        public Payee_KycController(CarryCashDbContext _db)
        {
            payee_kycservice =new Payee_KycService(_db);   
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee_Kyc>> GetAllPayeeKyc()
        {
            var payeekyc=payee_kycservice.RetreiveAllPayee_Kyc();
            if(payeekyc==null)
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
           var payeekyc=payee_kycservice.SpecificPayee_KycById(id);
            if(payeekyc!=null)
            return Ok(payeekyc);
            else
                return NotFound();  
        }
        [HttpPost]
        public ActionResult CreatePayeeKyc(Payee_Kyc p)
        {
              int Value=payee_kycservice.AddPayeeKyc(p);
               if(Value==1)
            {
                return Ok();
            }
              else
            {
               return BadRequest(); 
            }
           
        }
        
        [HttpPut]
        public ActionResult UpdatePayeeKyc(Payee_Kyc p)
        {
            if (ModelState.IsValid)
            {
                payee_kycservice.UpdatePayeekycData(p);
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
            int payeekyc=payee_kycservice.DeletePayeeKycData(id);
            if (payeekyc==1)
            { 
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
