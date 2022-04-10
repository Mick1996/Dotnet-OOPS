using Food_Delivery_Platform.BAL;
using Food_Delivery_Platform.DAL.FoodDbContextRepo;
using Food_Delivery_Platform.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Delivery_Platform.DAL.Repository
{
    public class UserRepo : IUser
    {
        UserRepo Repo = new UserRepo();
        private readonly FoodDbContext Db;
        public UserRepo(FoodDbContext _Db)
        {
           Db=_Db;
           
        }
        public UserRepo() { }
        public string UserNotExist()
        {
            return "User Doesn't exist";
        }
        public string AddMoney(int id,double Money)
        {
            User User=Db.users.Find(id);
            if(User!=null)
            {
               User.CashBalance=User.CashBalance+Money;
                Db.SaveChanges();
                return "Wallet TopUp Successfully";
            }
            return UserNotExist();
        }

        public string Create(User User)
        {
            Db.users.Add(User);
            Db.SaveChanges();
            return "User Registered Successfully";
        }

        public string DeleteUser(int id)
        {
            User User = Db.users.Find(id);
            if (User != null)
            {
                Db.users.Remove(User);
                Db.SaveChanges();
                return "User Deleted Successfully";
            }
            return UserNotExist();
        }

        public List<User> GetUsers()
        {
           return Db.users.Select(x=>x).ToList();
        }

        public string Purchase(int UserId,int Hotelid, string DishName) //id is hotelid
        {
           
           Hotel Hotel= Db.hotels.Where(x => x.HotelId == Hotelid).FirstOrDefault();
           if(Hotel!=null)
            {
               HotelMenu Menu= Db.hotelmenus.Where(x => x.HotelId == Hotelid && x.DishName == DishName).Select(x => x).FirstOrDefault();
                if (Menu != null)
                {
                    double ItemPrice = Menu.Price;
                    if(Db.users.Find(UserId).CashBalance>ItemPrice)
                    {
                       User User= Db.users.Find(UserId);
                        User.CashBalance = User.CashBalance - ItemPrice;
                        Hotel.CashBalance = Hotel.CashBalance+ItemPrice;
                        Db.SaveChanges();//update hotel cashbalance and user cashbalance
                        Repo.UpdateTransaction(ItemPrice,Hotel.HotelId,DishName,User.UserId);
                        return "Item Purchased Successfully";
                    }
                    return "Balance is InSufficient";
                }
                else
                    return "Dish is Not Available";
            }
            return "Hotel Doesn't exist";
        }

        public User SpecificUser(int id)
        {
            User User=Db.users.Find(id);
            return User;
        }

        public string Update(User User)
        {
            var Users = Db.users.Find(User.UserId);
            if (Users == null)
                return UserNotExist();
            else
            {
                Db.users.Remove(Users);
                Db.users.Add(User);
                Db.SaveChanges();
                return "User Updated Successfully";
            }
        }
        public Hotel SpecificHotelByName(string name)
        {
            Hotel Hotel = Db.hotels.Where(x => x.HotelName == name).FirstOrDefault();
            return Hotel;
        }
        public object OpenHotel(DateTime DateTime) //hotels open at given time
        {
          object HotelsName=Db.hotelstatus.Where(x => x.DateTime == DateTime && x.Status=="open").Select(n => new {n.HotelName}).ToList();
            return HotelsName;
        }
        public double GetCashBalance(int id)
        {
            User Users = Db.users.Where(x => x.UserId == id).Select(x => x).FirstOrDefault(); ;
            return Users.CashBalance;
        }
        public  void UpdateTransaction(double ItemPrice,int HotelId,string DishName,int UserId)
        {
            Random rnd = new Random();
            HotelTransaction HotelTransaction = new HotelTransaction();
            HotelTransaction.HotelId = HotelId;
            HotelTransaction.TranxId = rnd.Next(100,500);
            HotelTransaction.TranxDate = DateTime.Now;
            HotelTransaction.TranxAmt = ItemPrice;
            HotelTransaction.ItemName= DishName;
            UserTranxHistory UserTrax = new UserTranxHistory();
            UserTrax.UserId = UserId;
            UserTrax.TranxId= rnd.Next(100, 500);
            UserTrax.TranxAmt= ItemPrice;
            UserTrax.Item= DishName;
            UserTrax.TranxDateTime= DateTime.Now;
            Db.SaveChanges();

        }

    }
}
