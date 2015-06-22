using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.SqlDataAccess
{
    public class SqlOfferRepository : IOfferRepository
    {
        private Database _database;

        public SqlOfferRepository(string connectionString)
        {
            this._database = new SqlDatabase(connectionString);
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
