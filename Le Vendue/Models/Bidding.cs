using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Le_Vendue.Models
{
    public class Bidding
    {


        public String BidValue { get; set; }

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