using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using Food_Delivery_Platform.DAL.Repository;
using System.Collections.Generic;
namespace Food_Delivery_Platform.BAL
{
    public class HotelService : IHotel
    {
        private readonly IHotel IHotel;
        private string Result;
        public HotelService(FoodDbContext _Db)
        {
            IHotel = new HotelRepo(_Db);
        }
        public List<Hotel> GetAllHotel()
        {
          List<Hotel> Hotel=IHotel.GetAllHotel();
           return Hotel;
        }
        public string Create(Hotel Hotel)
        {
          Result=IHotel.Create(Hotel);
            return Result;
        }
        public Hotel SpecificHotel(int id)
        {
           Hotel Hotel=IHotel.SpecificHotel(id);
            return Hotel;
        }
        public string Update(Hotel Hotel)
        {
          Result = IHotel.Update(Hotel);    
           return Result;
        }
        public string Delete(int id)
        {
         Result=IHotel.Delete(id);
            return Result;
        }
        public string AddMenu(HotelMenu Menu)
        {
            Result = IHotel.AddMenu(Menu); 
            return Result;
        }
        public object GetMenu(int id)
        {
            var Item=IHotel.GetMenu(id); 
            return Item;
        }
        public string UpdateMenu(int id,string DishName,int Price)
        {
           Result=IHotel.UpdateMenu(id,DishName,Price);
            return Result;
        }
        public string AddStatus(HotelStatus Status)
        {
            Result = IHotel.AddStatus(Status);
            return Result;  
        }
        public object GetStatus(int id)
        {
         object Item=IHotel.GetStatus(id);
            return Item;
        }
        public object GetCashBalance(int id)
        {
            object Money=IHotel.GetCashBalance(id);
            return Money;
        }
        public Hotel SpecificHotelByName(string name)
        {
            Hotel Hotel=IHotel.SpecificHotelByName(name);
            return Hotel;
        }
    }
}
