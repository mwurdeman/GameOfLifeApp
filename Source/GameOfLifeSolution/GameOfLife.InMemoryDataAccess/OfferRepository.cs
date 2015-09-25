using GameOfLife.Domain.Repositories;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.InMemoryDataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private List<Offer> _offers;

        public OfferRepository()
        {
            this._offers = new List<Offer>();
        }
        
        public OfferRepository(List<Offer> offers)
        {
            this._offers = offers;
        }

        public Offer GetOfferByID(int offerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            throw new NotImplementedException();
        }

        public void AddOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public void DeleteOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public void UpdateOffer(Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
