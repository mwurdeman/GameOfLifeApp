using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Domain
{
    public class Location
    {
        public int LocationID {get;set;}
        public Store Store { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public IEnumerable<OfferDetail> Offers { get; set; }
     }
}
