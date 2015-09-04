using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using GameOfLife.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameOfLife.WebApi.Controllers
{
    [RoutePrefix("api/Location")]
    public class LocationController : ApiController
    {
        private readonly LocationService _locationService;

        public LocationController(ILocationRepository locationRepository)
        {
            this._locationService = new LocationService(locationRepository);
        }

        // GET: api/Location
        [Route("")]
        public IEnumerable<Location> Get()
        {
            return this._locationService.GetAllLocations();
        }

        // GET: api/Location/5
        [Route("{id:int}")]
        public Location Get(int id)
        {
            Location location;
            location = this._locationService.GetLocationByID(id);

            if (location == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
            }
           
            return location;
        }

        //GET: api/Location/Mo
        [Route("{dayOfWeek}")]
        public IEnumerable<Location> GetLocationsByDayOfWeek(string dayOfWeek)
        {
            IEnumerable<Location> locations; // = new List<Location>();
            locations = this._locationService.GetLocationsWithOffers(dayOfWeek);
            
            if (locations.Count() == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent));
            }

            return locations;
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }
    }
}
