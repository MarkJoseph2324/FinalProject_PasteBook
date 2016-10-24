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

        public ActionResult GetAllPostPartial()
        {
            int userID = Convert.ToInt32(Session["ID"]);
            var friendsList = businessLogic.GetFriendsList(userID);
            return PartialView("GetAllPostPartialView", businessLogic.GetPostForNewsFeed(userID, userID, friendsList));
        }

        [HttpGet]
        public ActionResult Timeline()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListOfFriends()
        {
            return View();
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
            int commentID = Convert.ToInt32(Session["ID"]);
            businessLogic.AddComment(mapper.CommentMapper(postID, commentID, postContent));
            return Json(new { PosterID = commentID, Content = postContent }, JsonRequestBehavior.AllowGet);
        }
    }
} 