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

        public IEnumerable<Location> GetLocationsWithOffers(string dayOfWeek)
        {
            string validDayOfWeek = this.GetValidDayOfWeek(dayOfWeek);
            List<Location> locations = this._locationRepository.GetAllLocations() as List<Location>;
            return locations.Where(x => x.Offers.Count(y => y.DaysOfWeek.Contains(validDayOfWeek)) > 0);
        }

        public IEnumerable<Location> GetLocationsByStoreID(int storeID)
        {
            List<Location> locations = this._locationRepository.GetAllLocations() as List<Location>;
            return locations.Where(x => x.Store.StoreID == storeID);
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

        private string GetValidDayOfWeek(string inputtedDayOfWeek)
        {
            string validDayOfWeek = "";

            switch (inputtedDayOfWeek)
            {
                case "Monday":
                case "Mon":
                case "Mo":
                    validDayOfWeek = "Mo";
                    break;
                case "Tuesday":
                case "Tues":
                case "Tu":
                    validDayOfWeek = "Tu";
                    break;
                case "Wednesday":
                case "Wed":
                case "We":
                    validDayOfWeek = "We";
                    break;
                case "Thursday":
                case "Thur":
                case "Th":
                    validDayOfWeek = "Th";
                    break;
                case "Friday":
                case "Fri":
                case "Fr":
                    validDayOfWeek = "Fr";
                    break;
                case "Saturday":
                case "Sat":
                case "Sa":
                    validDayOfWeek = "Sa";
                    break;
                case "Sunday":
                case "Sun":
                case "Su":
                    validDayOfWeek = "Su";
                    break;
                default:
                    validDayOfWeek = "XXX";
                    break;
            }

            return validDayOfWeek;
        }
    }
}
