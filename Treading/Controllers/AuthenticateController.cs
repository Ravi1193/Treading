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
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationViewModel model)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Email");
            ModelState.Remove("Mobile");
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
                    return View(model);

                }
            }
            {
                
                return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Register(AuthenticationViewModel model)
        {
            model.Status = true;
            if(ModelState.IsValid)
            {
                AuthenticateRepository repository = new AuthenticateRepository();
                var saveUsers =repository.SaveUser(model);
                  
                if(saveUsers ==1)
                {
                    bool sendMail = CommanRepository.SendMail(model);
                }
                return View(model);
            }
            
            return PartialView(model);
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