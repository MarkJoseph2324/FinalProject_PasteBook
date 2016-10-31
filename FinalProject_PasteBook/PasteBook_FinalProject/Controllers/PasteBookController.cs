using BusinessLogicLibrary;
using Entities;
using PasteBook_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Route("")]
        public ActionResult NewsFeed()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("LogIn", "PasteBookAccount");
            }
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

        [Route("{username}")]
        [HttpGet]
        public ActionResult Timeline(string username)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("LogIn", "PasteBookAccount");
            }
            else
            {
                int userID = Convert.ToInt32(Session["ID"]);
                var visitedUserID = businessLogic.GetSpecificUser(mapper.UserMapper(null, username));
                var friendsList = businessLogic.GetFriendsList(visitedUserID.ID);
                var userDetails = businessLogic.GetSpecificUser(mapper.UserMapper(null, username));
                return View(userDetails);
            }
        }

        [Route("Friends/{username}")]
        [HttpGet]
        public ActionResult Friends()
        {
            int userID = Convert.ToInt32(Session["ID"]);
            return View(businessLogic.GetSpecificUser(mapper.UserMapperByID(userID)));
        }

        public ActionResult Search(string searchValue)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("LogIn", "PasteBookAccount");
            }
            else
            {
                List<USER> user = new List<USER>();
                int userID = Convert.ToInt32(Session["ID"]);
                user = businessLogic.Search(userID, searchValue);
                return View(user);
            }
        }

        public JsonResult CreatePost(string post, int profileOwnerID)
        {
            int posterID = Convert.ToInt32(Session["ID"]);
            businessLogic.CreatePost(post, posterID, profileOwnerID);
            return Json(new { Post = post, PosterID = posterID, ProfileOwnerID = profileOwnerID }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikePost(int postID)
        {
            int likedBy = Convert.ToInt32(Session["ID"]);
            businessLogic.AddLike(mapper.LikeMapper(postID, likedBy));
            return Json(new { PostID = postID, LikeBy = likedBy }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddComment(int postID, string postContent)
        {
            int receiverID = 0;
            COMMENT comment = new COMMENT();
            int posterID = Convert.ToInt32(Session["ID"]);
            var postDetails = businessLogic.GetPostDetails(postID);
            if (postDetails.POSTER_ID == posterID)
            {
                receiverID = postDetails.PROFILE_OWNER_ID;
            }
            else
            {
                receiverID = postDetails.POSTER_ID;
            }
            comment = businessLogic.AddComment(mapper.CommentMapper(postID, posterID, postContent));

            return Json(new { PostID = comment.POST_ID, CommentID = comment.ID, ProfileOwnerID = receiverID }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNotification(string notifType, int postID, int commentID, int friendRequestID)
        {
            USER visitedUsername = new USER();
            int receiverID = 0;
            int senderID = Convert.ToInt32(Session["ID"]);
            var postDetails = businessLogic.GetPostDetails(postID);
            visitedUsername = businessLogic.GetSpecificUser(mapper.UserMapperByID(friendRequestID));
            if (postDetails != null)
            {
                if (postDetails.POSTER_ID == senderID)
                {
                    receiverID = postDetails.PROFILE_OWNER_ID;
                }
                else
                {
                    receiverID = postDetails.POSTER_ID;
                }
            }
            if(friendRequestID != 0 )
            {
                receiverID = friendRequestID;
            }

            businessLogic.AddNotification(mapper.NotificationMapper(notifType, postID, commentID, senderID, receiverID));

            return RedirectToAction("TimeLine", "PasteBook", new { username = visitedUsername.USER_NAME });
        }

        public ActionResult GetNotificationList()
        {
           
                int currentUserID = Convert.ToInt32(Session["ID"]);
                var listOfNotif = businessLogic.GetNotificationList(currentUserID);
                return PartialView("ShowNotificationCommentPartial", listOfNotif);
            
        }

        public JsonResult GetNotificationCount()
        {
            int currentUserID = Convert.ToInt32(Session["ID"]);
            int notifCount = businessLogic.GetNotificationList(currentUserID).Count();
            return Json(new { NotifCount = notifCount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string currentUser = Session["Username"].ToString();
            var user = businessLogic.GetSpecificUser(mapper.UserMapper(null, currentUser));
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    user.PROFILE_PIC = array;
                }
            }
            businessLogic.ChnageProfilePicture(user);
            return RedirectToAction("TimeLine", "Pastebook", new { username = Session["Username"] });
        }

        public JsonResult EditAboutMe(string value)
        {
            string currentUser = Session["Username"].ToString();
            var user = businessLogic.GetSpecificUser(mapper.UserMapper(null, currentUser));
            user.ABOUT_ME = value;
            bool status = businessLogic.UpdateUser(user);
            return Json(new { s = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddFriend(int userID, int profileOwnerID, string visitedUsername)
        {
            var status = businessLogic.AddFriend(mapper.FriendMapper(userID, profileOwnerID));
            return Json(new { UserID = userID, ProfileOwnerID = profileOwnerID , VisitedUsername = visitedUsername }, JsonRequestBehavior.AllowGet);
        }
    }
}