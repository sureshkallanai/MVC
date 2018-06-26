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
    [HandleError()]
    public class AccountController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            //Log Exception e
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }

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
            Repository.Roles role = new Repository.Roles();
            using (UOW uow = new UOW())
            {
                user = uow._iUserRepository.Get().ToList().Where(x => x.UserName == User.UserName && x.Password == User.Password).FirstOrDefault();
                if (user != null)
                {
                    role = uow._iRoleRepository.Get().ToList().Where(x => x.Rid == user.Rid).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(User.UserName, false);
                    var authTicket = new FormsAuthenticationTicket(1, User.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, role.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Account");
                }
                else
                {                    
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return RedirectToAction("Login", "Account");
                }
                
            }
        }
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Account/Error")]
        public ActionResult Error()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}