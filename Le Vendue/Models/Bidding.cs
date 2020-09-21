using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Le_Vendue.Models
{
    public class Bidding
    {
        public String UserId { get; set; }
        public String ProductName { get; set; }
        public String ProductDetails { get; set; }
        public DateTime ClosingTime { get; set; }
        public String ReserveValue { get; set; }
        public String HighestBidValue { get; set; }

    }


    public class BidSyncronize : Bidding
    {
        private static BidSyncronize bidSyncronize;
        private BidSyncronize()
        {
        }
        [MethodImpl(MethodImplOptions.Synchronized)]//For synronizing
        public static BidSyncronize GetBidSyncronizeInstance()
        {
            if (bidSyncronize == null)
                bidSyncronize = new BidSyncronize();
            return bidSyncronize;
        }
    }



}