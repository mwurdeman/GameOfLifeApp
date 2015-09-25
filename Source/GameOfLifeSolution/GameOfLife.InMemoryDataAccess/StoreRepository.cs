using GameOfLife.Domain.Repositories;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.InMemoryDataAccess
{
    public class StoreRepository : IStoreRepository
    {
        private List<Store> _stores;

        public StoreRepository()
        {
            this._stores = new List<Store>();
        }

        public StoreRepository(List<Store> stores)
        {
            this._stores = stores;
        }

        public Store GetStoreByID(int storeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAllStores()
        {
            throw new NotImplementedException();
        }

        public void AddStore(Store store)
        {
            throw new NotImplementedException();
        }

        public void DeleteStore(Store store)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
