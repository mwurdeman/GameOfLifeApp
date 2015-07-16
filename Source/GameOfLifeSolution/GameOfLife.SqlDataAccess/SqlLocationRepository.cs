using GameOfLife.Domain.Repositories;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace GameOfLife.SqlDataAccess
{
    public class SqlLocationRepository : ILocationRepository
    {
        private Database _database;

        public SqlLocationRepository(string connectionString)
        {
            this._database = new SqlDatabase(connectionString);
        }

        public Location GetLocationByID(int locationID)
        {
            Location location = null;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT S.StoreID, S.Name as 'StoreName', L.LocationID, L.Name as 'LocationName' ");
	        sql.Append(", L.Address1, L.Address2, L.City, L.State, L.ZipCode ");
            sql.Append("FROM Location L ");
            sql.Append("JOIN Store S ON S.StoreID = L.StoreID ");
            sql.Append("WHERE L.LocationID = @locationID ");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());
            this._database.AddInParameter(cmd, "@locationID", DbType.Int32, locationID);

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                if (reader.Read())
                {
                    Store store = new Store();
                    store.StoreID = reader.GetInt32("StoreID");
                    store.Name = reader.GetString("StoreName");

                    location = new Location();
                    location.Store = store;
                    location.LocationID = reader.GetInt32("LocationID");
                    location.Name = reader.GetString("LocationName");
                    location.Address1 = reader.GetString("Address1");
                    location.Address2 = reader.GetString("Address2");
                    location.City = reader.GetString("City");
                    location.State = reader.GetString("State");
                    location.ZipCode = reader.GetString("ZipCode");

                    location.Offers = this.GetLocationOfferDetails(location.LocationID);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return location;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            List<Location> locations = new List<Location>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT S.StoreID, S.Name as 'StoreName', L.LocationID, L.Name as 'LocationName' ");
            sql.Append(", L.Address1, L.Address2, L.City, L.State, L.ZipCode ");
            sql.Append("FROM Location L ");
            sql.Append("JOIN Store S ON S.StoreID = L.StoreID ");
            
            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                while (reader.Read())
                {
                    Location location = new Location();

                    Store store = new Store();
                    store.StoreID = reader.GetInt32("StoreID");
                    store.Name = reader.GetString("StoreName");
                    location.Store = store;

                    location.LocationID = reader.GetInt32("LocationID");
                    location.Name = reader.GetString("LocationName");
                    location.Address1 = reader.GetString("Address1");
                    location.Address2 = reader.GetString("Address2");
                    location.City = reader.GetString("City");
                    location.State = reader.GetString("State");
                    location.ZipCode = reader.GetString("ZipCode");

                    location.Offers = this.GetLocationOfferDetails(location.LocationID);

                    locations.Add(location);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return locations;
        }

        public IEnumerable<Location> GetLocationsByOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocationsByOfferDay(string dayOfWeek)
        {
            throw new NotImplementedException();
        }

        public void AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public void DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        private List<OfferDetail> GetLocationOfferDetails(int locationID)
        {
            List<OfferDetail> offers = new List<OfferDetail>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT L.LocationID, O.OfferID, O.Name, O.Details, LO.DaysOfWeek ");
            sql.Append("FROM Location L ");
            sql.Append("JOIN LocationOffer LO ON L.LocationID = LO.LocationID ");
            sql.Append("JOIN Offer O ON LO.OfferID = O.OfferID ");
            sql.Append("WHERE L.LocationID = @locationID ");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());
            this._database.AddInParameter(cmd, "@locationID", DbType.Int32, locationID);

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                while (reader.Read())
                {
                    OfferDetail offerDetail = new OfferDetail();
                    offerDetail.DaysOfWeek = reader.GetString("DaysOfWeek");
                    offerDetail.OfferID = reader.GetInt32("OfferID");
                    offerDetail.Name = reader.GetString("Name");
                    offerDetail.Description = reader.GetString("Details");

                    offers.Add(offerDetail);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return offers;
        }
    }
}
