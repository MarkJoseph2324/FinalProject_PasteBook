using DataAccessLibrary;
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
            if (ModelState.IsValid)
            {
                model = manager.CheckUserUserCredential(model);
            }
            if (model.Password == null || model.Email == null)
            {
                ModelState.AddModelError("Password", "Invalid Username or Password.");
                return View(model);
            }
            else
            {
                Session["FirstName"] = model.FirstName;
                Session["ID"] = model.UserID;
                return RedirectToAction("Index","Pastebook");
            }
        }

        public ActionResult LogOut()
        {
            Session["FirstName"] = null;
            return View("LogIn");
        }
    }
}