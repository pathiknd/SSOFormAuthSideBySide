using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSOFormAuthSideBySide.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SetUsername();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            SetUsername();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            SetUsername();
            return View();
        }

        private void SetUsername()
        {
            System.Security.Claims.ClaimsIdentity cp = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
            var name = cp.Claims.First<System.Security.Claims.Claim>(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier);
            ViewBag.UserName = name.Value;
        }
    }
}