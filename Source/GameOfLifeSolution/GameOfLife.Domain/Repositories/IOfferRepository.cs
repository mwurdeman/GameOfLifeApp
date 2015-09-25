using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Domain;

namespace GameOfLife.Domain.Repositories
{
    public interface IOfferRepository
    {
        Offer GetOfferByID(int offerID);
        IEnumerable<Offer> GetAllOffers();
        void AddOffer(Offer offer);
        void DeleteOffer(Offer offer);
        void UpdateOffer(Offer offer);
    }
}
