using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Vendue.Models
{
    public class ChangePassword
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }
}