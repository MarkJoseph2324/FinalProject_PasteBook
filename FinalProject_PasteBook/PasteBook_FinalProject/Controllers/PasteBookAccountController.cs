using Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PasteBook_FinalProject
{
    public class PasteBookAccountController : Controller
    {
        MVC_Manager manager = new MVC_Manager();
        // GET: PasteBookUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            if(Session["Country"]==null)
            {
                Session["Country"] = new SelectList(manager.GetAllCountries(), "ID", "Country");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                manager.AddUser(user);
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            string result = string.Empty;
            if(ModelState.IsValid)
            {
                result = manager.CheckUserIfExisting(model);
            }
            if (result == string.Empty)
            {
                ModelState.AddModelError("Password", "Invalid Username or Password.");
                return View(model);
            }
            else
            {
                Session["FirstName"] = result;
                return View("Index");
            }
        }
    }
}