using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Le_Vendue.Models
{
    public class AuctionInstanceCreateAndCheck
    {
        private static AuctionInstanceCreateAndCheck auctionInstanceCreateAndCheck;
        private AuctionInstanceCreateAndCheck()
        {

        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static AuctionInstanceCreateAndCheck GetInstance()
        {
            if (auctionInstanceCreateAndCheck == null)

                auctionInstanceCreateAndCheck = new AuctionInstanceCreateAndCheck();
            return auctionInstanceCreateAndCheck;


        }
    }
}