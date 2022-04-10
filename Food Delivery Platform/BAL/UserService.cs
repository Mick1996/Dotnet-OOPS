using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using Food_Delivery_Platform.DAL.Repository;
using System;
using System.Collections.Generic;

namespace Food_Delivery_Platform.BAL
{
    public class UserService : IUser
    {
        private readonly IUser Users;
        private string Result;
        public UserService(FoodDbContext Db)
        {
            Users = new UserRepo(Db);
        }
        public string AddMoney(int id,double Money)
        {
            Result=Users.AddMoney(id,Money);
            return Result;
        }

        public string Create(User User)
        {
             Result=Users.Create(User);
             return Result;
        }

        public string DeleteUser(int id)
        {
            Result=Users.DeleteUser(id);
            return Result;
        }

        public List<User> GetUsers()
        {
            return Users.GetUsers();
        }

        public string Purchase(int UserId, int id, string DishName)
        {
            Result = Users.Purchase(UserId, id, DishName);  
            return Result;  
        }

        public User SpecificUser(int id)
        {
            return Users.SpecificUser(id);
        }

        public string Update(User User)
        {
            Result=Users.Update(User);
            return Result;  
        }
        public Hotel SpecificHotelByName(string name)
        {
            Hotel Hotel = Users.SpecificHotelByName(name);
            return Hotel;
        }
        public object OpenHotel(DateTime DateTime) //hotels open at given time
        {
            List<object> HotelsName = (List<object>)Users.OpenHotel(DateTime);
            return HotelsName;
        }
        public double GetCashBalance(int id)
        {
           double Cash= Users.GetCashBalance(id);
           return Cash;
        }
    }
}
