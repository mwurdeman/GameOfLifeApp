using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Domain;

namespace GameOfLife.Domain.Repositories
{
    public interface ILocationRepository
    {
        Location GetLocationByID(int locationID);
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Location> GetLocationsByOffer(Offer offer);
        IEnumerable<Location> GetLocationsByOfferDay(string dayOfWeek);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
    }
}
