using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class AuctionListController : Controller
    {
        // GET: AuctionList
        public ActionResult Index()
        {
            return View();
        }
    }
}