using GameOfLife.Domain;
using GameOfLife.Domain.Repositories;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            Offer offer = null;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT OfferID as OfferID, Name as Name, Description as Description ");
            sql.Append("WHERE OfferID = @offerID");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());
            this._database.AddInParameter(cmd, "@offerID", DbType.Int32, offerID);

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                if (reader.Read())
                {
                    offer = new Offer();
                    offer.OfferID = reader.GetInt32("OfferID");
                    offer.Name = reader.GetString("Name");
                    offer.Description = reader.GetString("Description");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return offer;
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            List<Offer> offers = new List<Offer>();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT OfferID as OfferID, Name as Name, Description as Description ");

            DbCommand cmd = this._database.GetSqlStringCommand(sql.ToString());

            try
            {
                IDataReader reader = this._database.ExecuteReader(cmd);

                while (reader.Read())
                {
                    Offer offer = new Offer();
                    offer.OfferID = reader.GetInt32("OfferID");
                    offer.Name = reader.GetString("Name");
                    offer.Description = reader.GetString("Description");

                    offers.Add(offer);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return offers;
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
