using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Entity;

namespace FinalProject_PasteBook.Controllers
{
    public class PasteBookController : Controller
    {
        RegistrationManager registrationManager = new RegistrationManager();
        RegistrationModel registrationModel = new RegistrationModel();

        [HttpGet]
        public ActionResult Registration()
        {
            registrationModel.Countries = new SelectList(registrationManager.GetAllCountries(), "ID", "Country");
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