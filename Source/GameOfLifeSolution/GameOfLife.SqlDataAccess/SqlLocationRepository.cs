using GameOfLife.Domain.Repositories;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            throw new NotImplementedException();
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
    }
}
