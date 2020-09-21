using Le_Vendue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class AuctionCreateController : Controller
    {
        // GET: AuctionCreate
        /* [HttpGet]
         public ActionResult AuctionCreate()
         {
             return View();
         }*/
        // [HttpPost]
        public ActionResult AuctionCreate(AuctionCreate auctionCreate)
        {
            DatabaseController databaseController = new DatabaseController();
            databaseController.AuctionCreationOnDatabase(auctionCreate);
            return View();
        }
    }
}