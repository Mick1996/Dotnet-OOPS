using Microsoft.AspNetCore.Mvc;
using Refit_Consumer_Service.DataAccess;
using Refit_Consumer_Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Refit_Consumer_Service.Controllers   //Consumer service will consume api 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        IGuestData iguestdata;
        public ConsumerController(IGuestData _iguestdata)
        {
             iguestdata = _iguestdata;
        }
        // GET: api/<ConsumerController>
        [HttpGet]
        public Task<List<GuestModel>> Get()
        {
            return iguestdata.GetGuests();
        }

        // GET api/<ConsumerController>/5
        [HttpGet("{id}")]
        public Task<GuestModel> Get(int id)
        {
            return iguestdata.GetGuest(id);
        }

        // POST api/<ConsumerController>
        [HttpPost]
        public void Post([FromBody] GuestModel value)
        {
            iguestdata.CreateGuest(value);
        }

        // PUT api/<ConsumerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel value)
        {
            iguestdata.UpdateGuest(id,value);
        }

        // DELETE api/<ConsumerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            iguestdata.DeleteGuest(id);
        }
    }
}
