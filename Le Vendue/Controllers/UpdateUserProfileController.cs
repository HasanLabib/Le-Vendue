using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Le_Vendue.Models;
namespace Le_Vendue.Controllers
{
    public class UpdateUserProfileController : Controller
    {
        // GET: UpdateUserProfile
        [HttpGet]
        public ActionResult UpdateUserProfile()
        {
            return View();
        }
        [HttpPost]

        public ActionResult UpdateUserProfile(UpdatUserProfileModel updatUserProfile)
        {
            DatabaseController databaseController = new DatabaseController();
            databaseController.UpdateUser(updatUserProfile);

            return View();
        }
    }
}