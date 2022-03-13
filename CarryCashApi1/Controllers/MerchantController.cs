using CarryCashApi1.Model;
using CarryCashApi1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi1.Controllers
{
    [Route("api/[controller]")] //remove controller 
    [ApiController]
    public class MerchantController : ControllerBase
    {
          private MerchantService merchantservice;
          public MerchantController(CarryCashDbContext _db)
         {
             merchantservice = new MerchantService(_db); 
         }
        [HttpGet]
       public ActionResult<IEnumerable<Merchant>>GetAllMerchant()
        { 
            var merchant =merchantservice.RetreiveAllMerchant();
            if(merchant==null)
                return NotFound();
            else
            return Ok(merchant);
        }

         [HttpGet]
         [Route("{id:Guid}")]
        public ActionResult<Merchant> GetMerchantById(Guid id)
        {
            var merchant = merchantservice.MerchantById(id);
            if (merchant == null)
            {
                return NotFound();
            }
            else
                return Ok(merchant);
        }
        [HttpPost]
        public ActionResult CreateMerchant(Merchant _merchant)
        {
            if (ModelState.IsValid)
            {
                 merchantservice.AddMerchant(_merchant);
                return Ok();
            }
            else
            {
                return BadRequest("model state is not Valid");
            }
        }
        [HttpPut]
        public ActionResult UpdateMerchant(Merchant _merchant)
        {
            if (ModelState.IsValid)
            {
                merchantservice.UpdateMerchantData(_merchant);
                return Ok();
            }
            else
                return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMerchant(Guid id)
        {
            var mert=merchantservice.DeleteSpecificMerchant(id);   
            if (mert == 0)
            {
                return BadRequest("Not a valid Merchant_Id");
            }
            else
            {
                return Ok();
            }
        }
    }
}







