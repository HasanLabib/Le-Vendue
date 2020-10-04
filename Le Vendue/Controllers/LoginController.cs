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

    public class LoginController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login loginModel)
        {
            String Username, Password;
            Username = loginModel.Username;
            Password = loginModel.Password;
            bool v = false;

            DatabaseController databaseController = new DatabaseController();
            databaseController.GetUserdata(loginModel);

            return View();
        }

    }
}