using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using GameOfLife.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameOfLife.WebApi.Controllers
{
    public class StoreLocationController : ApiController
    {
        private readonly StoreLocationService _storeLocationService;

        public StoreLocationController(IStoreRepository storeRepository)
        {
            this._storeLocationService = new StoreLocationService(storeRepository);
        }

        // GET: api/StoreLocation
        [Route("")]
        public IEnumerable<StoreLocationViewModel> Get()
        {
            IEnumerable<StoreLocationViewModel> storeLocations = _storeLocationService.GetAllStoreLocationViewModel();

            if (storeLocations == null && storeLocations.Count() == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)); 
            }

            return storeLocations;
        }

        // GET: api/StoreLocation/Monday
        [Route("{dayOfWeek}")]
        public IEnumerable<StoreLocationViewModel> Get(string dayOfWeek)
        {
            IEnumerable<StoreLocationViewModel> storeLocations = _storeLocationService.GetStoreLocationViewModelByDay(dayOfWeek);

            if (storeLocations == null && storeLocations.Count() == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return storeLocations;
        }

        // POST: api/StoreLocation
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // PUT: api/StoreLocation/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // DELETE: api/StoreLocation/5
        public void Delete(int id)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }
    }
}
