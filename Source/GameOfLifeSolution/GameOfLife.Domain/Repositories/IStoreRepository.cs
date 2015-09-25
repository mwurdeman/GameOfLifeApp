using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Domain;

namespace GameOfLife.Domain.Repositories
{
    public interface IStoreRepository
    {
        Store GetStoreByID(int storeID);
        IEnumerable<Store> GetAllStores();
        IEnumerable<StoreLocationViewModel> GetStoreLocationViewModels();
        void AddStore(Store store);
        void DeleteStore(Store store);
        void UpdateStore(Store store);
    }
}
