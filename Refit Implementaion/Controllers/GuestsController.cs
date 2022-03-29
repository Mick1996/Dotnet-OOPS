using Microsoft.AspNetCore.Mvc;
using Refit_Implementaion.Model;
using Refit_Implementaion.Repositoty;
using Refit_Implementaion.Service;
using System.Collections.Generic;
using System.Linq;


namespace Refit_Implementaion.Controllers //this is our service running on https://localhost:44395/
{                                        //this service will consume by consumer service.
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly GuestService Guestservice;
          public GuestsController(GuestDbContext _db)
        {
            Guestservice = new GuestService(_db);
        }
        // GET: api/<GuestsController>
        [HttpGet]
        public ActionResult<List<GuestModel>> Get()
        {
            List<GuestModel> result=Guestservice.Get();
            if (result.Count != 0)
                return Ok(result);
            else
                return NotFound();
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public ActionResult<GuestModel> Get(int id)
        {
           var result= Guestservice.Get(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        // POST api/<GuestsController>
        [HttpPost]
        public ActionResult Post([FromBody] GuestModel value)
        {
            if (ModelState.IsValid)
            {
                Guestservice.Post(value);
            }
            return BadRequest();
        }

        // PUT api/<GuestsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GuestModel value)
        {
            if (ModelState.IsValid)
            {
                int result=Guestservice.Put(id, value);
                if (result == 1)
                    return Ok();
                else
                    return NotFound();
            }
            else
                return BadRequest(); 
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           int result= Guestservice.Delete(id);
           if(result==1)
            return Ok();
           else
                return NotFound();
            
        }
    }
}
