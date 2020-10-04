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
            if (registerData.Password == registerData.RetypePassword)
            {
                SetResponse setResponse = client.Set(@"Register/" + registerData.Username, registerWork);
            }
            return View();
        }
        static string username;
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
                username = login.Username;

                Redirect("~/Home/Index");
                // Httpw httpResponseBase = new Httpw();
                // httpResponseBase.Redirect("~/Home/Index");
                return View();


            }
            else if (login.Username != registerUser.Username)
            {
                //ViewBag.massege("User doesn't exists");

            }
            else if (login.Username == registerUser.Username && login.Password != registerUser.Password)
            {
                //  ViewBag.massege("Wrong Password");

            }
            // RedirectToAction
            return View();

        }
        public static String getUserName()
        {
            return username;
        }
        public ActionResult UpdateUser(UpdatUserProfileModel updateUserProfile)
        {

            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }

            FirebaseResponse getResponse = client.Get(@"Register/" + updateUserProfile.Username);
            if (getResponse == null) { ViewBag.message("no user"); }
            else
            {

                var registerUser = getResponse.ResultAs<Register>();
                var updateUserProfileData = registerUser;
                if (updateUserProfile.Password == registerUser.Password)
                {
                    if (updateUserProfile.FirstName != null)
                    {
                        updateUserProfileData.FirstName = updateUserProfile.FirstName;
                        var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }
                    if (updateUserProfile.LastName != null)
                    {
                        updateUserProfileData.LastName = updateUserProfile.LastName;
                        var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }
                    if (updateUserProfile.Gender != null)
                    {
                        updateUserProfileData.Gender = updateUserProfile.Gender;
                        var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }
                    if (updateUserProfile.Address != null)
                    {
                        updateUserProfileData.Address = updateUserProfile.Address;
                        var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }


                    if (updateUserProfile.Mobile != null)
                    {
                        updateUserProfileData.Mobile = updateUserProfile.Mobile;
                        var setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }
                    if (updateUserProfile.BirthDate != null & updateUserProfileData.BirthMonth != null & updateUserProfileData.BirthYear != null)
                    {

                        FirebaseResponse setResponse;
                        updateUserProfileData.BirthDate = updateUserProfile.BirthDate;
                        updateUserProfileData.BirthMonth = updateUserProfile.BirthMonth;
                        updateUserProfileData.BirthYear = updateUserProfile.BirthYear;
                        setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                        setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                        setResponse = client.Update(@"Register/" + updateUserProfileData.Username, updateUserProfileData);
                    }

                }
                return View();
            }
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
        public static int HighBid;
        public ActionResult BiddingOnDatabase(Bidding bidding)
        {

            var biddingData = bidding;
            //  PushResponse pushResponse = client.Push("Register/", registerData);
            // registerData.RegisterID = pushResponse.Result.name;
            if (client == null)
            {
                getClient();
            }
            var getHighestbid = client.Get(@"Bid");

            var HighestBid = getHighestbid.ResultAs<Bidding>();
            HighBid = int.Parse(HighestBid.BidValue);
            if (HighBid < int.Parse(bidding.BidValue))
            {
                SetResponse setBidResponse = client.Set(@"Bid", biddingData);
            }


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
        public static int GetHighbid()
        {
            IFirebaseConfig config2 = new FirebaseConfig
            {
                AuthSecret = "yHyLtdeqMqZxcRnIk9DaFImlSthBrRQeQCBlBKRw",
                BasePath = "https://auctionsite-1119f.firebaseio.com/"

            };
            if (client == null)
            {
                client = new FireSharp.FirebaseClient(config2);
            }
            var getHighestbid = client.Get(@"Bid");
            var HighestBid = getHighestbid.ResultAs<Bidding>();
            HighBid = int.Parse(HighestBid.BidValue);
            return HighBid;
        }
        public static string AuctionId;
        public static string TempAuctionId;
        public static string setAuctionId(Index index)
        {
            TempAuctionId = index.AuctionId;
            AuctionId = TempAuctionId;
            return TempAuctionId;
        }
        public static AuctionCreate GetAuction()
        {
            IFirebaseConfig config3 = new FirebaseConfig
            {
                AuthSecret = "yHyLtdeqMqZxcRnIk9DaFImlSthBrRQeQCBlBKRw",
                BasePath = "https://auctionsite-1119f.firebaseio.com/"

            };
            if (client == null)
            {
                client = new FireSharp.FirebaseClient(config3);
            }
            AuctionId = "Dy4Lxj7Chmr";
            var getAuction = client.Get(@"AuctionCreate/" + AuctionId);
            var AuctionData = getAuction.ResultAs<AuctionCreate>();

            return AuctionData;
        }


        public ActionResult getContact(Contact contact)
        {
            if (client == null)
            {
                getClient();
            }

            FirebaseResponse getResponse = client.Get(@"Register/" + contact.username);
            if (getResponse == null) { return View("No user"); }
            else
            {
                FirebaseResponse setResponse = client.Set(@"Massege/" + contact.username, contact);
                return View();
            }




            return View();
        }
        public ActionResult ChangeUserEmail(ChangeEmail changeEmail)
        {
            if (client == null)
            {
                getClient();
            }

            FirebaseResponse getResponse = client.Get(@"Register/" + changeEmail.Username);
            if (getResponse == null) { return View("No user"); }
            else
            {
                var changeEmailData = getResponse.ResultAs<Register>();

                if (changeEmailData.Password == changeEmail.Password)
                {
                    changeEmailData.Email = changeEmail.Email;
                    FirebaseResponse setResponse = client.Update(@"Register/" + changeEmailData.Username, changeEmailData);
                    return View();
                }
            }
            return View();
        }

        public ActionResult ChangeUserPassword(ChangePassword changePassword)
        {
            if (client == null)
            {
                getClient();
            }

            FirebaseResponse getResponse = client.Get(@"Register/" + changePassword.Username);
            if (getResponse == null) { return View("No user"); }
            else
            {
                var changePasswordData = getResponse.ResultAs<Register>();

                if (changePasswordData.Email == changePassword.Email)
                {
                    if (changePassword.OldPassword == changePasswordData.Password)
                    {
                        changePasswordData.Password = changePassword.NewPassword;
                        FirebaseResponse setResponse = client.Update(@"Register/" + changePasswordData.Username, changePasswordData);
                    }
                    return View();
                }
            }
            return View();
        }

    }
    public class Httpw : HttpResponseBase
    {

    }
}

//https://console.firebase.google.com/u/0/project/auctionsite-1119f/database/auctionsite-1119f/data