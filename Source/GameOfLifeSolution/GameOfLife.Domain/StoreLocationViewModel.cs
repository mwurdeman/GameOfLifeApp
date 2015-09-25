using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain
{
    public class StoreLocationViewModel
    {
        public int StoreID { get; set; }
        public int LocationID { get; set; }
        public int OfferID { get; set; }
        public string StoreName { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OfferDetails { get; set; }
        public string[] DaysOfWeek { get; set; }

        public string LocationAddress
        {
            get
            {
                if (String.IsNullOrEmpty(Address2))
                {
                    return String.Format("{0}, {1}, {2}, {3}", Address1, City, State, ZipCode);
                }
                else
                {
                    return String.Format("{0}, {1}, {2}, {3}, {4}", Address1, Address2, City, State, ZipCode);
                }
            }
        }
    }
}
