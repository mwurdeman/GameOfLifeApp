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

        public IEnumerable<StoreLocationViewModel> GetStoreLocationViewModels()
        {
            List<StoreLocationViewModel> storeLocations = new List<StoreLocationViewModel>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT S.StoreID ");
            sql.Append(", L.LocationID "); 
            sql.Append(", O.OfferID ");  
            sql.Append(", S.Name as StoreName "); 
            sql.Append(", L.Name as LocationName "); 
            sql.Append(", L.Address1 "); 
            sql.Append(", L.Address2 "); 
            sql.Append(", L.City "); 
            sql.Append(", L.State "); 
            sql.Append(", L.ZipCode "); 
            sql.Append(", O.Details "); 
            sql.Append(", LO.DaysOfWeek "); 
            sql.Append("FROM Store S "); 
            sql.Append("JOIN Location L ON S.StoreID = L.StoreID ");
            sql.Append("JOIN LocationOffer LO ON L.LocationID = LO.LocationID "); 
            sql.Append("JOIN Offer O ON LO.OfferID = O.OfferID" );

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                while(reader.Read())
                {
                    StoreLocationViewModel storeLoc = new StoreLocationViewModel();
                    storeLoc.StoreID = reader.GetInt32("StoreID");
                    storeLoc.LocationID = reader.GetInt32("LocationID");
                    storeLoc.OfferID = reader.GetInt32("OfferID");
                    storeLoc.StoreName = reader.GetString("StoreName");
                    storeLoc.LocationName = reader.GetString("LocationName");
                    storeLoc.Address1 = reader.GetString("Address1");
                    storeLoc.Address2 = reader.GetString("Address2");
                    storeLoc.City = reader.GetString("City");
                    storeLoc.State = reader.GetString("State");
                    storeLoc.ZipCode = reader.GetString("ZipCode");
                    storeLoc.OfferDetails = reader.GetString("Details");
                    storeLoc.DaysOfWeek = FormatOfferDays(reader.GetString("DaysOfWeek"));

                    storeLocations.Add(storeLoc);
                }

                reader.Close();

                return storeLocations;
            }
            catch (Exception)
            {
                throw;
            }
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

        private string[] FormatOfferDays(string offerDays)
        {
            return offerDays.Split(Convert.ToChar(","));
        }
    }
}
