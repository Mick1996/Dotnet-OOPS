using CarryCashWebApi.Business_Access_Layer;
using CarryCashWebApi.Model;
using CarryCashWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payee_KybController : ControllerBase
    {
        Payee_KybService payee_kybservice;
        public Payee_KybController(CarryCashDbContext _db)
        {
            payee_kybservice = new Payee_KybService(_db);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Payee_Kyb>> GetAllPayeeKyb()
        {
            var payeekyb = payee_kybservice.RetreiveAllPayee_Kyb();
            if (payeekyb == null)
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
            var payeekyb = payee_kybservice.SpecificPayee_KybById(id);
            if (payeekyb != null)
                return Ok(payeekyb);
            else
                return NotFound();
        }
        [HttpPost]
        public ActionResult CreatePayeeKyb(Payee_Kyb p)
        {
            if (ModelState.IsValid)
            {
                int payeeid = payee_kybservice.AddPayeeKyb(p);
                if (payeeid == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Payee doesn't exist");
                }

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult UpdatePayeeKyb(Payee_Kyb p)
        {
            if (ModelState.IsValid)
            {
                payee_kybservice.UpdatePayeekybData(p);
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
            int payeekyb = payee_kybservice.DeletePayeeKybData(id);
            if (payeekyb == 1)
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
