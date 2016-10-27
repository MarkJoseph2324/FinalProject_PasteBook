using Entities;
using PasteBook_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject
{
    public class Mapper
    {
        public USER UserMapper(RegistrationModel user, string username)
        {
            USER entityUser = new USER();
            if (string.IsNullOrEmpty(username))
            {
                 entityUser = new USER()
                {
                    USER_NAME = user.Username,
                    BIRTHDAY = user.Birthday,
                    COUNTRY_ID = user.CountryID,
                    DATE_CREATED = DateTime.Now,
                    FIRST_NAME = user.FirstName,
                    LAST_NAME = user.LastName,
                    GENDER = user.Gender,
                    MOBILE_NO = user.MobileNumber,
                    PASSWORD = user.Password,
                    EMAIL_ADDRESS = user.Email
                };
            }
            else
            {
                entityUser = new USER()
                {
                    USER_NAME = username
                };
            }

            return entityUser;
        }

        public USER UserCredentailMapper(LogInModel user)
        {
            USER entityUser = new USER()
            {
                PASSWORD = user.Password,
                EMAIL_ADDRESS = user.Email
            };
            return entityUser;
        }
        
        public LIKE LikeMapper(int postID, int likedBy)
        {
            LIKE entityLike = new LIKE()
            {
                POST_ID = postID,
                LIKE_BY = likedBy
            };
            return entityLike;
        }

        public COMMENT CommentMapper(int postID, int commentID, string postContent)
        {
            COMMENT entityComment = new COMMENT()
            {
                CONTENT = postContent,
                CREATED_DATE = DateTime.Now,
                POST_ID = postID,
                POSTER_ID = commentID
            };
            return entityComment;
        }

        public NOTIFICATION NotificationMapper(string  notifType, int postID, int commentID,int senderID,int receiverID)
        {
            NOTIFICATION entityNotification = new NOTIFICATION();
            if (notifType == "Like")
            {
                entityNotification = new NOTIFICATION()
                {
                    CREATED_DATE = DateTime.Now,
                    NOTIF_TYPE = "L",
                    POST_ID = postID,
                    RECEIVER_ID = receiverID,
                    SEEN = "N",
                    SENDER_ID = senderID
                };
            }
            else if (notifType == "Comment")
            {
                entityNotification = new NOTIFICATION()
                {
                    COMMENT_ID = commentID,
                    CREATED_DATE = DateTime.Now,
                    NOTIF_TYPE = "C",
                    POST_ID = postID,
                    RECEIVER_ID = receiverID,
                    SEEN = "N",
                    SENDER_ID = senderID
                };
            }
            else if (notifType == "AddFriend")
            {
                entityNotification = new NOTIFICATION()
                {
                    CREATED_DATE = DateTime.Now,
                    NOTIF_TYPE = "F",
                    RECEIVER_ID = receiverID,
                    SEEN = "N",
                    SENDER_ID = senderID
                };
            }
            return entityNotification;
        }
    }
}