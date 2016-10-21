using BusinessLogicLibrary;
using Entity;
using PasteBook_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBook_FinalProject.Controllers
{
    public class PasteBookController : Controller
    {
        Mapper mapper = new Mapper();
        BusinessLogic businessLogic = new BusinessLogic();
        // GET: PasteBook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RetrieveAllPostPartial()
        {
            USER entityUser = new USER();
            int userID = Convert.ToInt32(Session["ID"]);
            entityUser.ID = userID;
            var friendsList = businessLogic.RetrieveFriendsList(userID);
            var friendsInformationList = businessLogic.RetrieveFriendsInformationList(userID, friendsList);
            var userInformation = businessLogic.GetSpecificUser(entityUser);
            var mergeUserInformation = businessLogic.MergeFriendsAndUserList(friendsInformationList, userInformation);
            return PartialView("RetrieveAllPostPartialView", mapper.ListOfPostMapper((businessLogic.RetrievePostForNewsFeed(userID, userID)), mergeUserInformation, userInformation));
        }

        public JsonResult CreatePost(string post)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            businessLogic.CreatePost(post, posterID, posterID);
            return Json(new { Post = post, PosterID = posterID, ProfileOwnerID = posterID }, JsonRequestBehavior.AllowGet);
        }
    }
}