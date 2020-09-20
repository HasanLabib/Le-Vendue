using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Le_Vendue.Models;

namespace Le_Vendue.Controllers
{
    public class RegisterWork
    {
        //[HttpGet]
        // 
        public String RegisterID;
        public void AuctionRegister(Register registerModel)
        {
            String FirstName;
            String LastName;
            String BirthDate;
            String BirthMonth;
            String BirthYear;
            String Gender;
            String Email;
            String Password;
            String RetypePassword; String Username; String Address;

            /* Register RegisterDataList = new Register();
             RegisterDataList.FirstName = FirstName;
             RegisterDataList.LastName = LastName;
             RegisterDataList.BirthDate = BirthDate;
             RegisterDataList.BirthMonth = BirthMonth;
             RegisterDataList.BirthYear = BirthYear;
             RegisterDataList.Gender = Gender;
             RegisterDataList.Email = Email;
             RegisterDataList.Password = Password;*/
            FirstName = registerModel.FirstName;
            LastName = registerModel.LastName;
            Username = registerModel.Username;
            Email = registerModel.Email;
            Password = registerModel.Password;
            RetypePassword = registerModel.RetypePassword;
            BirthDate = registerModel.BirthDate;
            BirthMonth = registerModel.BirthMonth;
            BirthYear = registerModel.BirthYear;
            Gender = registerModel.Gender;
            Address = registerModel.Address;

            DatabaseController databaseController = new DatabaseController();
            databaseController.SendRegisterdata(registerModel);
            return;

            //BuildManagerViewEngine buildManagerViewEngine = new BuildManagerViewEngine();

        }


    }
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(Register registerModel)
        {
            //  Register registerModel = new Register();
            //String FirstName, String LastName, String BirthDate, String BirthMonth, String BirthYear, String Gender, String Email, String Password, String Username, String Address
            /*   FirstName = Request["FirstName"].ToString();
               LastName = Request["LastName"].ToString();
               BirthDate = Request["BirthDate"].ToString();
               BirthMonth = Request["BirthMonth"].ToString();
               BirthYear = Request["BirthYear"].ToString();
               Email = Request["Email"].ToString();
               Gender = Request["Gender"].ToString();
               Password = Request["Password"].ToString();
               Username = Request["Username"].ToString();
               Address = Request["Address"].ToString();
               //    RegisterWork registerWork = new RegisterWork();
               //  registerWork.AuctionRegister(FirstName, LastName, BirthDate, BirthMonth, BirthYear, Gender, Email, Password, Username, Address);

               //AuctionRegister();
               // return View(registerModel);*/
            RegisterWork registerWork = new RegisterWork();
            registerWork.AuctionRegister(registerModel);

            return View();
        }
    }
}


// }
// public ActionResult AuctionRegister()
//  {
//String FirstName, String LastName, String BirthDate, String BirthMonth, String BirthYear, String Gender, String Email, String Password, String Username, String Address
/* Register RegisterDataList = new Register();
 RegisterDataList.FirstName = FirstName;
 RegisterDataList.LastName = LastName;
 RegisterDataList.BirthDate = BirthDate;
 RegisterDataList.BirthMonth = BirthMonth;
 RegisterDataList.BirthYear = BirthYear;
 RegisterDataList.Gender = Gender;
 RegisterDataList.Email = Email;
 RegisterDataList.Password = Password;*/

// return View();

//BuildManagerViewEngine buildManagerViewEngine = new BuildManagerViewEngine();

//  }
//  }
//}
//}