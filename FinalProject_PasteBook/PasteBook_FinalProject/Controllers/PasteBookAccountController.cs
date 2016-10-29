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
        Validation validation = new Validation();
        Mapper mapper = new Mapper();
        // GET: PasteBookUser
        public ActionResult Index()
        {
            return View();
        }

        [Route("Account/Register")]
        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.Country = new SelectList(businessLogic.GetAllCountries(), "ID", "COUNTRY");
            
            return View();
        }

        [Route("Account/Register")]
        [HttpPost]
        public ActionResult Registration(RegistrationModel user)
        {
            bool returnValue = false;
            ViewBag.Country = new SelectList(businessLogic.GetAllCountries(), "ID", "COUNTRY");
            if (validation.CheckEmailformat(user.Email))
            {
                if (validation.CheckIfEmailIsExisting(user.Email))
                {
                    ModelState.AddModelError("Email", "Sorry, email is already exist!");
                }
            }
            else
            {
                ModelState.AddModelError("EmailAddress", "Please enter a proper email. (e.g. 'sample@yahoo.com')");
            }
            
            if (validation.CheckIfUsernameIsExisting(user.Username))
            {
                ModelState.AddModelError("Username", "Sorry, username already exist!");
            }

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
                return RedirectToAction("NewsFeed", "Pastebook");
            }
            else
            {
                return View(user);
            }
        }

        [Route("Account/Login")]
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [Route("Account/Login")]
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            USER user = new USER();
            if (ModelState.IsValid)
            {
                user = mapper.UserCredentailMapper(model);
                user = businessLogic.CheckUserCredential(user);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Invalid Username or Password.");
                    return View(model);
                }
                else
                {
                    Session["FirstName"] = user.FIRST_NAME;
                    Session["ID"] = user.ID;
                    Session["Username"] = user.USER_NAME;
                    return RedirectToAction("NewsFeed", "Pastebook");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session["FirstName"] = null;
            Session["ID"] = null;
            Session["Username"] = null;
            return View("LogIn");
        }
    }
}