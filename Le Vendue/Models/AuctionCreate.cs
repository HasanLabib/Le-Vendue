using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Vendue.Models
{

    public class AuctionCreate
    {
        //UniqueIdGenerator uniqueIdGenerator = new UniqueIdGenerator();
        public String AuctionId { get; set; }
        public String ProductName { get; set; }
        public String ProductDetails { get; set; }
        public String SetReservePrice { get; set; }
        public DateTime ClosingTime { get; set; }

    }
}