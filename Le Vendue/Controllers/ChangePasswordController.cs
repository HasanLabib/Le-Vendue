using Le_Vendue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            DatabaseController databaseController = new DatabaseController();
            databaseController.ChangeUserPassword(changePassword);
            return View();
        }

    }
}