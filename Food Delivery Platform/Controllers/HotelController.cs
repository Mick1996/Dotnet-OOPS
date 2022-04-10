using Food_Delivery_Platform.BAL;
using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Food_Delivery_Platform.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel IHotel;
        private string Result;
        public HotelController(FoodDbContext db)
        {
          IHotel=new HotelService(db);
        }
        [HttpGet]
        [Route("hotelList")]
        public ActionResult<IEnumerable<Hotel>> GetAllHotel()
        {
            List<Hotel> Hotels=IHotel.GetAllHotel();
            if (Hotels.Count != 0)
                return Ok(Hotels);
            else
                return BadRequest("No Hotel Exist");
        }
        [HttpGet]
        [Route("gethotel/{id}")]
        public ActionResult<Hotel> SpecificHotel(int id)
        {
           Hotel Hotel= IHotel.SpecificHotel(id);
            if(Hotel!=null)
            return Ok(Hotel);
            else
                return BadRequest("Hotel Doesn't Exist");
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Create([FromBody] Hotel Hotel)
        {
            if (ModelState.IsValid)
            {
                Result = IHotel.Create(Hotel);
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody] Hotel Hotel)
        {
            if (ModelState.IsValid)
            {
                Result = IHotel.Update(Hotel);
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
           Result=IHotel.Delete(id);
           return Ok(Result);   
        }
        [HttpGet]
        [Route("getMenu")]
        public ActionResult GetMenu(int id) //item list
        {
            object HotelMenu=IHotel.GetMenu(id); 
            if(HotelMenu!=null)
            {
                return Ok(HotelMenu); 
            }
            else
            {
                return BadRequest("No Item is Available");
            }
        }
        [HttpPost]
        [Route("createMenu")]
        public ActionResult AddMenu([FromBody] HotelMenu Menu)
        {
            if (ModelState.IsValid)
            {
                Result = IHotel.AddMenu(Menu);
                return Ok(Result);
            }
            else
                return BadRequest(Result);
             
        }
        [HttpPut]
        [Route("updateMenu")]
        public ActionResult Update([FromBody] UpdateMenu MenuUpdate)
        {
            if (ModelState.IsValid)
            {
                Result = IHotel.UpdateMenu(MenuUpdate.Id, MenuUpdate.DishName, MenuUpdate.Price);
                return Ok(Result);  
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpPost]
        [Route("addHotelStatus")]
        public ActionResult AddStatus([FromBody] HotelStatus Status)
        {
            if (ModelState.IsValid)
            {
                Result = IHotel.AddStatus(Status);
                return Ok(Result);
            }
            else
                return BadRequest(Result) ;
        }
        [HttpGet]
        [Route("getStatus/{id}")]
        public ActionResult GetStatus(int id)
        {
           object Status= IHotel.GetStatus(id);
            if (Status != null)
            {
                return Ok(Status);
            }
            else
            {
                return BadRequest();     
            }
        }
        [HttpGet]
        [Route("getCashBalance/{id}")]
        public ActionResult GetCashBalance(int id)
        {
           object Money=IHotel.GetCashBalance(id);
           return Ok(Money);
        }
        [HttpGet]
        [Route("getHotelByName/{name}")]
        public ActionResult<Hotel> SpecificHotelByName(string name)
        {
            Hotel Hotel = IHotel.SpecificHotelByName(name);
            if (Hotel != null)
                return Ok(Hotel);
            else
                return BadRequest("Hotel Doesn't Exist");
        }
    }
}
