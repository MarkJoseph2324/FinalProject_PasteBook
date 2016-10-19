using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook_FinalProject.Controllers
{
    public class PasteBookController : Controller
    {
        MVC_Manager managerMVC = new MVC_Manager();
        // GET: PasteBook
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult CreatePost(string txtPost)
        //{
        //    int posterID = Convert.ToInt32(Session["ID"]);
        //    managerMVC.CreatePost(txtPost, posterID, posterID);

        //    return View("Index");
        //}

        public ActionResult RetrieveAllPostPartial()
        {
            MVC_Mapper map = new MVC_Mapper();
            int userID = Convert.ToInt32(Session["ID"]);
            return PartialView("RetrieveAllPostPartialView", map.MapPostFromDB(managerMVC.RetrievePostForNewsFeed(userID)));
        }

        public JsonResult CreatePost(string post)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            managerMVC.CreatePost(post, posterID, posterID);
            return Json(new { Post = post, PosterID = posterID, ProfileOwnerID = posterID }, JsonRequestBehavior.AllowGet);
        }
    }
}