using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Le_Vendue.Models;

namespace Le_Vendue.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yHyLtdeqMqZxcRnIk9DaFImlSthBrRQeQCBlBKRw",
            BasePath = "https://auctionsite-1119f.firebaseio.com/"

        };

        private static IFirebaseClient client;


        public ActionResult getClient()
        {
            if (client == null)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }

            }

            return View();

        }
        [HttpGet]
        public ActionResult SendRegisterdata(Register registerWork)
        {
            var registerData = registerWork;
            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }
            SetResponse setResponse = client.Set(@"Register/" + registerData.Username, registerWork);
            return View();
        }
        [HttpGet]
        public ActionResult GetUserdata(Login login)
        {

            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            Register registerWork = new Register();
            if (client == null)
            {
                getClient();
            }
            FirebaseResponse getResponse = client.Get(@"Register/" + login.Username);
            var registerUser = getResponse.ResultAs<Register>();

            if (login.Username == registerUser.Username && login.Password == registerUser.Password)
            {


            }
            else if (login.Username != registerUser.Username)
            {
                Console.WriteLine("User doesn't exists");

            }
            else if (login.Username == registerUser.Username && login.Password != registerUser.Password)
            {
                Console.WriteLine("Wrong Password");

            }
            // RedirectToAction
            return View("Index");

        }
        public ActionResult UpdateUser(UpdatUserProfileModel updateUserProfile)
        {
            var updateUserProfileData = updateUserProfile;
            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }
            //FirebaseResponse getResponse = client.Get(@"Register/" + updateUserProfile.Username);
            // var registerUser = getResponse.ResultAs<Register>();

            var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
            return View();
        }
        public ActionResult AuctionCreationOnDatabase(AuctionCreate auctionCreate)
        {
            var auctionCreateData = auctionCreate;
            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }


            var getAuctionnumberResponse = client.Get(@"Auctionnumber");
            var Auctionnumber = int.Parse(getAuctionnumberResponse.ResultAs<string>());

            SetResponse setAuctionnumberResponse = client.Set(@"Auctionnumber", ++Auctionnumber);
            SetResponse setResponse = client.Set(@"AuctionCreate/" + auctionCreate.AuctionId, auctionCreate);
            return View();
        }

        public ActionResult BiddingOnDatabase(Bidding bidding)
        {
            var biddingData = bidding;
            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }
            SetResponse setBidResponse = client.Set(@"Bid", biddingData);
            //bidding.ProductName = auction.ProductName;
            // bidding.ProductDetails = auction.ProductDetails;
            // bidding.ReserveValue = auction.SetReservePrice;
            // bidding.ClosingTime = auction.ClosingTime;

            //var getAuctionnumberResponse = client.Get(@"Auctionnumber");
            //var Auctionnumber = int.Parse(getAuctionnumberResponse.ResultAs<string>());

            // SetResponse setAuctionnumberResponse = client.Set(@"Auctionnumber", ++Auctionnumber);
            // SetResponse setResponse = client.Set(@"AuctionCreate/" + auctionCreate.AuctionId, auctionCreate);
            return View();
        }
    }
}
//https://console.firebase.google.com/u/0/project/auctionsite-1119f/database/auctionsite-1119f/data