using Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PasteBook_FinalProject
{
    public class PasteBookUserController : Controller
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
    }
}