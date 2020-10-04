using Le_Vendue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace Le_Vendue.Controllers
{
    public class ChangeEmailController : Controller
    {
        // GET: ChangeEmail
        [HttpGet]
        public ActionResult ChangeEmail()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ChangeEmail(ChangeEmail changeEmailModel)
        {


            DatabaseController databaseController = new DatabaseController();
            databaseController.ChangeUserEmail(changeEmailModel);

            return View();
        }
    }
}