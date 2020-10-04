using Le_Vendue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult LoginHome()
        {
            DatabaseController database = new DatabaseController();
            string username = DatabaseController.getUserName();
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Index index)
        {
            DatabaseController.setAuctionId(index);
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {

            DatabaseController databaseController = new DatabaseController();
            databaseController.getContact(contact);

            return View();
        }

    }
}