using Food_Delivery_Platform.BAL;
using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Food_Delivery_Platform.DAL.Repository
{
    public class HotelRepo :IHotel
    {
        private readonly FoodDbContext Db;
        public HotelRepo(FoodDbContext _Db)
        {
          Db= _Db;
        }
        public string HotelNotExist()
        {
            return "Hotel Doesn't Exist";
        }
        public List<Hotel> GetAllHotel()
        {
            List<Hotel> HotelList = Db.hotels.Select(x => x).ToList();
            return HotelList;
        }
        public string Create(Hotel Hotel)
        {
          Db.hotels.Add(Hotel);
          Db.SaveChanges();
           return "Hotel Registered Successfully";
        }
        public Hotel SpecificHotel(int id) 
        {
           Hotel Hotel=Db.hotels.Where(x => x.HotelId == id).FirstOrDefault();
            return Hotel;
        }
        public string Update(Hotel Hotel)
        {
            var Hotels = Db.hotels.Find(Hotel.HotelId);
            if (Hotels == null)
                return HotelNotExist();
            else
            {
                Db.hotels.Remove(Hotels);
                Db.hotels.Add(Hotel);
                Db.SaveChanges();
                return "Hotel Updated Successfully";
            }
        }
        public string Delete(int id)
        {
            var Hotel=Db.hotels.Where(x=>x.HotelId==id).FirstOrDefault();
            if (Hotel != null)
            {
                Db.hotels.Remove(Hotel);
                Db.SaveChanges();
                return "Hotel Deleted Successfully";
            }
            else
            {
                return HotelNotExist();
            }
        }    
        public string AddMenu(HotelMenu Menu)
        {
          var Result=Db.hotels.Where(x=>x.HotelId==Menu.HotelId).FirstOrDefault();
            if (Result != null)
            {
                Db.hotelmenus.Add(Menu);
                Db.SaveChanges();
                return "item is Added";
            }
            else
                return HotelNotExist();
        }
        public object GetMenu(int id) //list of item
        {
            object Item = Db.hotelmenus.Where(x => x.HotelId == id).Select(n => new { n.DishName, n.Price, });
             return Item; 
        }
        public string UpdateMenu(int id,string DishName,int Price) //update price of item
        {
            HotelMenu HotelExist = Db.hotelmenus.Where(x => x.HotelId == id).Select(x => x).FirstOrDefault();
            if (HotelExist != null)
            {
                HotelMenu Result = Db.hotelmenus.Where(x => x.HotelId == id && x.DishName == DishName).Select(x => x).FirstOrDefault();
                if (Result != null)
                {
                    Result.Price = Price;
                    Db.SaveChanges();
                    return "Item Updated";
                }
                else
                    return "This Dish is not Available in your Menu";
            }
            return HotelNotExist();
        }
        public string AddStatus(HotelStatus Status)
        {
           Hotel Hotel = Db.hotels.Where(x => x.HotelId == Status.HotelId).Select(x=>x).FirstOrDefault();
            if (Hotel != null)
            {
                Db.hotelstatus.Add(Status);
                Db.SaveChanges();
                return "Status Added Successfully";
            }
            return HotelNotExist();
        }
        public object GetStatus(int id)
        {
            object Item = Db.hotelstatus.Where(x => x.HotelId == id).Select(n => new {n.DateTime,n.HotelName,n.Status});
            return Item; 
        }
        public object GetCashBalance(int id)
        {
            object Money=Db.hotels.Where(x=>x.HotelId==id).Select(n=>new {n.CashBalance});
            return Money;
        }
        public Hotel SpecificHotelByName(string name)
        {
            Hotel Hotel = Db.hotels.Where(x => x.HotelName == name).FirstOrDefault();
            return Hotel;
        }
    }
}
