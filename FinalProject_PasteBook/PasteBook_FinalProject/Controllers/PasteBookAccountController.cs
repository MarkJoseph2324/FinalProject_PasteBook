using BusinessLogicLibrary;
using Entity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PasteBook_FinalProject
{
    public class PasteBookAccountController : Controller
    {
        BusinessLogic businessLogic = new BusinessLogic();
        Mapper mapper = new Mapper();
        // GET: PasteBookUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.Country = new SelectList(businessLogic.GetAllCountries(), "ID", "Country");
            
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                businessLogic.AddUser(mapper.UserMapper(user, null));
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
            USER user = new USER();
            user = mapper.UserCredentailMapper(model);
            if (ModelState.IsValid)
            {
                user = businessLogic.CheckUserCredential(user);
            }
            if (user.PASSWORD == null || user.EMAIL_ADDRESS == null)
            {
                ModelState.AddModelError("Password", "Invalid Username or Password.");
                return View(model);
            }
            else
            {
                Session["FirstName"] = user.FIRST_NAME;
                Session["ID"] = user.ID;
                return RedirectToAction("Index","Pastebook");
            }
        }

        public ActionResult LogOut()
        {
            Session["FirstName"] = null;
            Session["ID"] = null;
            return View("LogIn");
        }
    }
}