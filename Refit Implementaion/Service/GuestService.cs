using Refit_Implementaion.Data;
using Refit_Implementaion.Model;
using Refit_Implementaion.Repositoty;
using System.Collections.Generic;

namespace Refit_Implementaion.Service
{
    public class GuestService
    {
        private readonly GuestData Guestdata;
        public GuestService(GuestDbContext db)
        {
          Guestdata = new GuestData(db);
        }
        public List<GuestModel> Get()
        {
            List<GuestModel> result=Guestdata.Get();
            return result;
        }
        public GuestModel Get(int id)
        {
           GuestModel result=Guestdata.Get(id);
            return result;
        }
        public void Post(GuestModel value)
        {
            Guestdata.Post(value);  
        }
        public int Put(int id, GuestModel value)
        {
           int result= Guestdata.Put(id, value);
            return result;
        }
        public int Delete(int id)
        {
            int result=Guestdata.Delete(id);
            return result;
        }
    }
}
