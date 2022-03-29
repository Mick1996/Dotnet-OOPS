using Microsoft.AspNetCore.Mvc;
using Refit_Implementaion.Model;
using System.Collections.Generic;
using System.Linq;


namespace Refit_Implementaion.Controllers //this is our service running on https://localhost:44395/
{                                        //this service will consume by consumer service.
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        public static List<GuestModel> guest=new List<GuestModel>()
        {
            new GuestModel()
            {
              Id=1,FirstName ="Sam",LastName="John"
            },
            new GuestModel()
            {
                Id=2,FirstName ="John",LastName ="Polo"
            },
            new GuestModel()
            {
              Id=3,FirstName ="Sameer",LastName="Saini"
            },
            new GuestModel()
            {
                Id=4,FirstName ="Aamir",LastName ="Kumar"
            },
         };


        // GET: api/<GuestsController>
        [HttpGet]
        public List<GuestModel> Get()
        {
            return guest;   
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public GuestModel Get(int id)
        {
            return guest.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<GuestsController>
        [HttpPost]
        public void Post([FromBody] GuestModel value)
        {
            guest.Add(value);
        }

        // PUT api/<GuestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel value)
        {
            GuestModel guestmodel=guest.Where(x=>x.Id==id).FirstOrDefault();
            guest.Remove(guestmodel);
            guest.Add(value);
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GuestModel guestmodel = guest.Where(x => x.Id == id).FirstOrDefault();
            guest.Remove(guestmodel);
        }
    }
}
