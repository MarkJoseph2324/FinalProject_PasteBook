using Entity;
using FinalProject_PasteBook;
using PasteBook_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook_FinalProject
{
    public class PasteBookUserController : Controller
    {
        MVC_CountryManager countryManager = new MVC_CountryManager();
        // GET: PasteBookUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel. = new SelectList(countryManager.GetAllCountries(), "ID", "Country");
            return View(registrationModel);
        }

        [HttpPost]
        public ActionResult Registration(USER user)
        {
            registrationModel.Countries = new SelectList(registrationManager.GetAllCountries(), "ID", "Country");
            if (ModelState.IsValid)
            {
                registrationManager.AddUser(user);
            }

            return View(user);
        }
    }
}