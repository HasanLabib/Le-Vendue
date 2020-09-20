﻿using System;
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
            FirebaseResponse getResponse = client.Get(@"Register/" + registerWork.Username);
            Register registerUser = getResponse.ResultAs<Register>();

            if (login.Username == registerUser.Username && login.Password == registerUser.Password)
            {
                Console.WriteLine("Login Successful");
            }
            else if (login.Username != registerUser.Username)
            {
                Console.WriteLine("User doesn't exists");
            }
            else if (login.Username == registerUser.Username && login.Password != registerUser.Password)
            {
                Console.WriteLine("Wrong Password");
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
            SetResponse setResponse = client.Set(@"AuctionCreate/" + auctionCreate.ProductName, auctionCreate);
            return View();
        }
    }
}