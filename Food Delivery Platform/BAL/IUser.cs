using Food_Delivery_Platform.DAL.Model;
using System;
using System.Collections.Generic;

namespace Food_Delivery_Platform.BAL
{
    public interface IUser
    {
        public List<User> GetUsers();
        public User SpecificUser(int id);
        public string Create(User User);
        public string Update(User User);
        public string DeleteUser(int id);
        public string Purchase(int UserId,int Hotelid,string DishName);
        public string AddMoney(int id,double Money);
        public Hotel SpecificHotelByName(string name);
        public object OpenHotel(DateTime DateTime);
        public double GetCashBalance(int id);
    }
}
