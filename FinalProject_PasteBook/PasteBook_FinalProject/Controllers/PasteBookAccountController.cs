using BusinessLogicLibrary;
using Entities;
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
            ViewBag.Country = new SelectList(businessLogic.GetAllCountries(), "ID", "COUNTRY");
            
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel user)
        {
            bool returnValue = false;
            if (ModelState.IsValid)
            {
                returnValue=businessLogic.AddUser(mapper.UserMapper(user, null));
            }
            if (returnValue)
            {
                var currentUser = businessLogic.CheckUserCredential(mapper.UserMapper(user, null));
                Session["FirstName"] = currentUser.FIRST_NAME;
                Session["ID"] = currentUser.ID;
                Session["Username"] = currentUser.USER_NAME;
                return RedirectToAction("Index", "Pastebook");
            }
            else
            {
                return View(user);
            }
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
            if (user==null)
            {
                ModelState.AddModelError("Email", "Invalid Username or Password.");
                return View(model);
            }
            else
            {
                Session["FirstName"] = user.FIRST_NAME;
                Session["ID"] = user.ID;
                Session["Username"] = user.USER_NAME;
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