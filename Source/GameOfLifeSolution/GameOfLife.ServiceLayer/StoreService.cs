using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ServiceLayer
{
    public class StoreService
    {
        private IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        public Store GetStoreByID(int storeID)
        {
            Store store = this._storeRepository.GetStoreByID(storeID);
            return store;
        }

        public IEnumerable<Store> GetAllStores()
        {
            return this._storeRepository.GetAllStores();
        }

        public void SaveStore(Store store)
        {
            //TODO: Add Store Validation information

            if (store.StoreID == 0)
            {
                this._storeRepository.AddStore(store);
            }
            else
            {
                this._storeRepository.UpdateStore(store);
            }
        }

        public void DeleteStore(Store store)
        {
            this._storeRepository.DeleteStore(store);
        }
    }
}
