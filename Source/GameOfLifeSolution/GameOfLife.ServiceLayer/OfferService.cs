using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ServiceLayer
{
    public class OfferService
    {
        private IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }

        public Offer GetOfferByID(int offerID)
        {
            return this._offerRepository.GetOfferByID(offerID);
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            return this._offerRepository.GetAllOffers();
        }

        public void SaveOffer(Offer offer)
        {
            //TODO: Add validation for the offer

            if (offer.OfferID == 0)
            {
                this._offerRepository.AddOffer(offer);
            }
            else
            {
                this._offerRepository.UpdateOffer(offer);
            }
        }

        public void DeleteOffer(Offer offer)
        {
            this._offerRepository.DeleteOffer(offer);
        }
    }
}
