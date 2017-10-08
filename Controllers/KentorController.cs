using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSOFormAuthSideBySide.Controllers
{
    public class KentorController : Controller
    {
        // GET: Kentor
        public ActionResult LogIn()
        {
            return new RedirectResult("~/AuthServices/SignIn");
        }

        public ActionResult LogInComplete()
        {
            return new RedirectResult("~/Home/Index");
        }
    }
}