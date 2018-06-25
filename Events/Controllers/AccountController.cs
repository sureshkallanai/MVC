using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Events.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult Login(Users User)
        {
            if (!ModelState.IsValid)
            {
                return View(User);
            }
           Users user = new Users();
            using (UOW uow = new UOW())
            {
                user = uow._iUserRepository.Get().ToList().Where(x=>x.UserName==User.UserName&&x.Password==User.Password).FirstOrDefault();
               // user.Role.Role = uow._iRoleRepository.Get().ToList().Where(x=>x.Rid= user.Role.Rid)
            }

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(User.UserName, false);

                var authTicket = new FormsAuthenticationTicket(1, User.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false,"");
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(User);
            }            
        }
       // [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}