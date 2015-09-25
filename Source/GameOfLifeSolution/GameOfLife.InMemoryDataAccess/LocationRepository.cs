using GameOfLife.Domain.Repositories;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.InMemoryDataAccess
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> _locations;

        public LocationRepository()
        {
            this._locations = new List<Location>();
        }

        public LocationRepository(List<Location> locations)
        {
            this._locations = locations;
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
