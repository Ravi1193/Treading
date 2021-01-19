using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Treading.Models;
using Treading.ViewModel;
namespace Treading.Controllers
{
    public class AuthenticateController : Controller
    {
        AuthenticationViewModel model = new AuthenticationViewModel();
        // GET: Authenticate
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool AuthUsers = AuthenticateRepository.Authenticate(model);
                if (AuthUsers == true)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Session["session"] = "test";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return PartialView(model);

                }
            }
            {
                
                return PartialView(model);
            }
        }
        public ActionResult Signup()
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}