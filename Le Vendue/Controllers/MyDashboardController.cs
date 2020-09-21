using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class MyDashboardController : Controller
    {
        // GET: MyDashboard
        [HttpGet]
        public ActionResult MyDashboard()
        {
            return View();
        }
    }
}