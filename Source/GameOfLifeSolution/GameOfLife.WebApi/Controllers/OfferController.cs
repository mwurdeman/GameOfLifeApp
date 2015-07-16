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
    public class OfferController : ApiController
    {
        private readonly OfferService _offerService;

        public OfferController(IOfferRepository offerRepository)
        {
            this._offerService = new OfferService(offerRepository);
        }

        // GET: api/Offer
        public IEnumerable<Offer> Get()
        {
            return this._offerService.GetAllOffers();
        }

        // GET: api/Offer/5
        public Offer Get(int id)
        {
            Offer offer;
            offer = this._offerService.GetOfferByID(id);

            if (offer == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return offer;
        }

        // POST: api/Offer
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // PUT: api/Offer/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }

        // DELETE: api/Offer/5
        public void Delete(int id)
        {
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented));
        }
    }
}
