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
    public class StoreController : ApiController
    {
        private readonly StoreService _storeService;

        public StoreController(IStoreRepository storeRepository)
        {
            this._storeService = new StoreService(storeRepository);
        }

        // GET: api/Store
        public IEnumerable<Store> Get()
        {
            return this._storeService.GetAllStores();
        }

        // GET: api/Store/5
        public Store Get(int id)
        {
            Store store;
            store = this._storeService.GetStoreByID(id);

            if(store == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return store;
        }

        // POST: api/Store
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Store/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Store/5
        public void Delete(int id)
        {
        }
    }
}
