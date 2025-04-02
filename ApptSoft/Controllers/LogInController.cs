using ApptSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApptSoft.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginIN(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "123")
                {
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }
            }
            return View("..\\Login\\Index", model);
        }
        public ActionResult UserDashBoard()
        {
            //return View("..\\Login\\Index");
            return View("..\\Dashboard\\DashboardIndex");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }
    }
}