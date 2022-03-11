using CarryCashApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarryCashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        CarryCashDbContext db;
        public MerchantController(CarryCashDbContext _db)
        {
          db= _db;  
        }
        [HttpGet]
       public ActionResult <IEnumerable<Merchant>>GetAllMerchant()
        {
            var merchant = db.merchant.Select(x=>x).ToList();
            if (merchant.Count == 0)
                return NotFound();
            else
            return merchant;
        }
         [HttpGet]
         [Route("{id:Guid}")]
        public ActionResult<Merchant> GetMerchantById(Guid id)
        {
            var merchant = db.merchant.Where(x=>x.Merchant_Id==id).FirstOrDefault();
            if (merchant == null)
            {
                return NotFound();
            }
            else
                return merchant;
        }
       /* [HttpGet("{name}")] 
        public ActionResult<Merchant> GetMerchantByName(string name)
        {
            var merchant = db.merchant.Where(x=>x.Name==name).Select(x => x);
            if (merchant == null)
                return NotFound();
            else
                return (Merchant)merchant;
        } */
        [HttpPost]
        public ActionResult CreateMerchant(Merchant _merchant)
        {
            if (ModelState.IsValid)
            {
                db.merchant.Add(_merchant);
                db.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }
        [HttpPut]
        public ActionResult UpdateMerchant(Merchant _merchant)
        {
            if (ModelState.IsValid)
            {
                db.merchant.Update(_merchant);
                db.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMerchant(Guid id)
        {
            Merchant mert=db.merchant.Find(id);
            if (mert == null)
            {
                return BadRequest("Not a valid Merchant_Id");
            }
            else
            {
                db.merchant.Remove(mert);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}







