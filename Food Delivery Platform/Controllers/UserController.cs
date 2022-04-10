using Food_Delivery_Platform.BAL;
using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Food_Delivery_Platform.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser Users;
        private string Result;
        public UserController(FoodDbContext _Db)
        {
            Users = new UserService(_Db);
        }
        [HttpGet]
        [Route("allUser")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
           List<User> User= Users.GetUsers();
            if(User.Count!=0)
            {
                return Ok(User);
            }
            return BadRequest("No User Exist");
        }
        [HttpGet]
        [Route("detail/{id}")]
        public ActionResult<User> SpecificUser(int id)
        {
            User User= Users.SpecificUser(id);
            if(User!=null)
                return Ok(User);
            return BadRequest("User Doesn't exist");
        }
        [HttpPost]
        [Route("add")]
        public ActionResult Create([FromBody]User User)
        {
            if (ModelState.IsValid)
            {
                Result=Users.Create(User);
                return Ok(Result);    
            }
            else
            {
                return BadRequest(Result);
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody] User User)
        {
            if (ModelState.IsValid)
            {
                Result = Users.Update(User);
                return Ok(Result); 
            }
            else
               return BadRequest(Result);     
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult DeleteUser(int id)
        {
            Result=Users.DeleteUser(id);
            return Ok(Result);  
        }
        [HttpPost]
        [Route("purchase")]
        public ActionResult PuchaseItem([FromBody] Purchase Purchase)
        {
           Result= Users.Purchase(Purchase.UserId,Purchase.HotelId,Purchase.DishName);
           return Ok(Result);   
        }
        [HttpPost]
        [Route("TopUpWallet/{id}/{money}")]
        public ActionResult TopUpWallet(int id,double money)
        {
            Result=Users.AddMoney(id,money);
            return Ok(Result);
        }
        [HttpGet]
        [Route("getHotelByName/{name}")]
        public ActionResult<Hotel> SpecificHotelByName(string name)
        {
            Hotel Hotel = Users.SpecificHotelByName(name);
            if (Hotel != null)
                return Ok(Hotel);
            else
                return BadRequest("Hotel Doesn't Exist");
        }
        [HttpGet]
        [Route("getOpenHotels/{dateTime}")]
        public ActionResult GetOpenHotel(DateTime DateTime)
        {
            object Names=Users.OpenHotel(DateTime);
            return Ok(Names);
        }
        [HttpGet]
        [Route("getCashBalance/{id}")]
        public ActionResult GetCashBalance(int id)
        {
            object Money = Users.GetCashBalance(id);
            return Ok(Money);
        }

    }
}
