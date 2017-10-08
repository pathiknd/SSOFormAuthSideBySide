using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSOFormAuthSideBySide.Models;
using System.IdentityModel.Services;
using System.IdentityModel;
using System.Security.Claims;
using System.IdentityModel.Tokens;

namespace SSOFormAuthSideBySide.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult LogIn(LoginDetails loginCred)
        {
            if(loginCred.Username == loginCred.Password)
            {
                SetClaimsIdentity(loginCred.Username);
                return new RedirectResult("~/Home/Index");
            }
            else
            {
                return new RedirectResult("~/Account/Login");
            }
        }

        public ActionResult LogOut()
        {
            RemoveClaimsIdentity();
            return new RedirectResult("~/Account/LogIn");
        }

        private void SetClaimsIdentity(string userName)
        {
            var claims = new System.Security.Claims.Claim[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, userName)
            };

            ClaimsIdentity id = new System.Security.Claims.ClaimsIdentity(claims, "Forms");
            ClaimsPrincipal cp = new System.Security.Claims.ClaimsPrincipal(id);

            SessionSecurityToken token = new SessionSecurityToken(cp);
            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(token);
        }

        private void RemoveClaimsIdentity()
        {
            FederatedAuthentication.SessionAuthenticationModule.DeleteSessionTokenCookie();
        }
    }
}