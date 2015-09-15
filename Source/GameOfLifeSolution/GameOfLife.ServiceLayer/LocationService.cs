using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ServiceLayer
{
    public class LocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        public Location GetLocationByID(int locationID)
        {
            return this._locationRepository.GetLocationByID(locationID);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return this._locationRepository.GetAllLocations();
        }

        //public IEnumerable<Location> GetLocationsWithOffers(string dayOfWeek)
        //{
        //    string validDayOfWeek = this.GetValidDayOfWeek(dayOfWeek);
        //    List<Location> locations = this._locationRepository.GetAllLocations() as List<Location>;
        //    return locations.Where(x => x.Offers.Count(y => y.DaysOfWeek.Contains(validDayOfWeek)) > 0);
        //}

        public IEnumerable<Location> GetLocationsByStoreID(int storeID)
        {
            List<Location> locations = this._locationRepository.GetAllLocations() as List<Location>;
            return locations.Where(x => x.StoreID == storeID);
        }

        public void SaveLocation(Location location)
        {
            //TODO: Add Validation Logic here

            if (location.LocationID == 0)
            {
                this._locationRepository.AddLocation(location);
            }
            else
            {
                this._locationRepository.UpdateLocation(location);
            }
        }

        public void DeleteLocation(Location location)
        {
            this._locationRepository.DeleteLocation(location);
        }

        
    }
}
