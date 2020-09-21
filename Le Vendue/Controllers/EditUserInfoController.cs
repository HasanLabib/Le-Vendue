using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Le_Vendue.Controllers
{
    public class EditUserInfoController : Controller
    {
        // GET: EditUserInfo
        [HttpGet]
        public ActionResult EditUserInfo()
        {
            return View();
        }
    }
}