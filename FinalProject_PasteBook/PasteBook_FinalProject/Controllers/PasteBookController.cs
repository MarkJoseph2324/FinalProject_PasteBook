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

        [Route("Pastebook.com")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllPostPartial(string username)
        {
            int userID = Convert.ToInt32(Session["ID"]);
            if (!string.IsNullOrEmpty(username))
            {
                var timelineOwner = businessLogic.GetSpecificUser(mapper.UserMapper(null, username));
                var friendsList = businessLogic.GetFriendsList(timelineOwner.ID);
                return PartialView("GetAllPostPartialView", businessLogic.GetPostForNewsFeed(userID, timelineOwner.ID, friendsList));
            }
            else
            {
                var friendsList = businessLogic.GetFriendsList(userID);
                return PartialView("GetAllPostPartialView", businessLogic.GetPostForNewsFeed(userID, userID, friendsList));
            }
        }

        [Route("Pastebook.com/{username}")]
        [HttpGet]
        public ActionResult Timeline(string username)
        {
            var user = businessLogic.GetSpecificUser(mapper.UserMapper(null, username));
            return View(user);
        }

        [Route("Pastebook.com/Friends/{username}")]
        [HttpGet]
        public ActionResult Friends()
        {
            int userID = Convert.ToInt32(Session["ID"]);
            return View(businessLogic.GetFriendsList(userID));
        }

        public ActionResult Search(string searchValue)
        {
            List<USER> user = new List<USER>();
            int userID = Convert.ToInt32(Session["ID"]);
            user = businessLogic.Search(userID, searchValue);
            return View(user);
        }

        public JsonResult CreatePost(string post)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            businessLogic.CreatePost(post, posterID, posterID);
            return Json(new { Post = post, PosterID = posterID, ProfileOwnerID = posterID }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikePost(int postID)
        {
            int likedBy = Convert.ToInt32(Session["ID"]);
            businessLogic.AddLike(mapper.LikeMapper(postID, likedBy));
            return Json(new { PostID = postID, LikeBy = likedBy }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddComment(int postID, string postContent)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            businessLogic.AddComment(mapper.CommentMapper(postID,posterID,  postContent));
            return Json(new { PosterID = posterID, Content = postContent }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Notification(string notifType, int postID, int commentID)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            if (postID != 0)
            {
                businessLogic.AddNotification(mapper.MapNotification(posterID, notifType, postID, commentID))
            }

            return View();
        }
    }
} 