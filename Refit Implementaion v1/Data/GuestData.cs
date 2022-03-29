using Refit_Implementaion.Model;
using Refit_Implementaion.Repositoty;
using System.Collections.Generic;
using System.Linq;

namespace Refit_Implementaion.Data
{
    public class GuestData
    {
        private readonly GuestDbContext db;
        public GuestData(GuestDbContext _db)
        {
          db= _db;  
        }
        public List<GuestModel> Get()
        {
            return db.guests.ToList();
        }
        public GuestModel Get(int id)
        {
            return db.guests.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Post(GuestModel value)
        {
            db.guests.Add(value);
            db.SaveChanges();
        }
        public int Put(int id,GuestModel value)
        {
            GuestModel guestmodel = db.guests.Where(x => x.Id == id).FirstOrDefault();
            if (guestmodel != null)
            {
                db.guests.Remove(guestmodel);
                db.guests.Add(value);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
        public int Delete(int id)
        {
            GuestModel guestmodel = db.guests.Where(x => x.Id == id).FirstOrDefault();
            if (guestmodel != null)
            {
                db.guests.Remove(guestmodel);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;

        }
    }
}
