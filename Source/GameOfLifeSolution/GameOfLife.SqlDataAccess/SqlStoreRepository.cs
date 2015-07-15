using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            Store store = null;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT StoreID as StoreID, Name as Name FROM Store ");
            sql.Append("WHERE StoreID = @storeID");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());
            this._database.AddInParameter(cmd, "@storeID", DbType.Int32, storeID);

            try
            {
                IDataReader reader = _database.ExecuteReader(cmd);

                if (reader.Read())
                {
                    store = new Store();
                    store.StoreID = reader.GetInt32("StoreID");
                    store.Name = reader.GetString("Name");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return store;
        }

        public IEnumerable<Store> GetAllStores()
        {
            List<Store> stores = new List<Store>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT StoreID as StoreID, Name as Name FROM Store ");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());

            try
            {
                IDataReader reader = _database.ExecuteReader(cmd);

                while (reader.Read())
                {
                    Store store = new Store();
                    store.StoreID = reader.GetInt32("StoreID");
                    store.Name = reader.GetString("Name");

                    stores.Add(store);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stores;
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
