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
        public string LocationAddress { get; set; }
        public string OfferDetails { get; set; }
        public string[] DaysOfWeek { get; set; }
    }
}
