using Food_Delivery_Platform.DAL.Model;
using System.Collections.Generic;

namespace Food_Delivery_Platform.BAL
{
    public interface IHotel
    {
        public List<Hotel> GetAllHotel();
        public Hotel SpecificHotel(int id);
        public string Create(Hotel Hotel);
        public string Update(Hotel Hotel);
        public string Delete(int id);
        public object GetMenu(int id);
        public string AddMenu(HotelMenu Menu);
        public string UpdateMenu(int id,string DishName,int Price);
        public string AddStatus(HotelStatus Status);
        public object GetStatus(int id);
        public object GetCashBalance(int id);
        public Hotel SpecificHotelByName(string name);

    }
}
