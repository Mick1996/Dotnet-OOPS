using Refit;
using Refit_Consumer_Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Refit_Consumer_Service.DataAccess
{
    public interface IGuestData
    {
        [Get(path:"/Guests")] //Guests is controller name and it is endpoint
        Task<List<GuestModel>> GetGuests();  //Refit always return Task or Task<object> 

        [Get(path:"/Guests/{id}")]    //it is endpoint
        Task<GuestModel> GetGuest(int id);

        [Post(path: "/Guests")] //it is endpoint
        Task CreateGuest([Body] GuestModel guest); //when Consumer service or any service call this method then above endpoint will route to required Action Method of Refit Implementation api because it is connected with this service.     

        [Put(path:"/Guests/{id}")]  //it is endpoint 
        Task UpdateGuest(int id,[Body] GuestModel guest);

        [Delete(path: "/Guests/{id}")]   //it is endpoint
        Task DeleteGuest(int id);
    }
}
