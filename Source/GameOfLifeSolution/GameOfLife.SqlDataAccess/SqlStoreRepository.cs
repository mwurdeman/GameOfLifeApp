using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.SqlDataAccess
{
    public class SqlStoreRepository : IStoreRepository
    {
        private Database _database;

        public SqlStoreRepository(string connectionString)
        {
            this._database = new SqlDatabase(connectionString);
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
