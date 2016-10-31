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
            if(user != null)
            {
                if (user.Gender == null)
                {
                    user.Gender = "U";
                }
            }
            USER entityUser = new USER();
            if (string.IsNullOrEmpty(username))
            {
                 entityUser = new USER()
                {
                    USER_NAME = user.Username.Trim(),
                    BIRTHDAY = user.Birthday,
                    COUNTRY_ID = user.CountryID,
                    DATE_CREATED = DateTime.Now,
                    FIRST_NAME = user.FirstName.Trim(),
                    LAST_NAME = user.LastName.Trim(),
                    GENDER = user.Gender,
                    MOBILE_NO = user.MobileNumber,
                    PASSWORD = user.Password,
                    EMAIL_ADDRESS = user.Email.Trim()
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
                PASSWORD = user.Password.Trim(),
                EMAIL_ADDRESS = user.Email.Trim()
            };
            return entityUser;
        }

        public USER RegistrationMapper(RegistrationModel register)
        {
            if(register.Gender == "")
            {
                register.Gender = "U";
            }
            USER entityUser = new USER()
            {
                PASSWORD = register.Password.Trim(),
                EMAIL_ADDRESS = register.Email.Trim(),
                BIRTHDAY = register.Birthday,
                COUNTRY_ID = register.CountryID,
                DATE_CREATED = DateTime.Now,
                FIRST_NAME = register.FirstName.Trim(),
                GENDER = register.Gender,
                LAST_NAME = register.LastName.Trim(),
                MOBILE_NO = register.MobileNumber.Trim(),
                USER_NAME = register.Username.Trim()
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
                CONTENT = postContent.Trim(),
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

        public FRIEND FriendMapper(int userID, int profileOwnerID)
        {
            FRIEND entityFriend = new FRIEND()
            {
                BLOCKED = "N",
                CREATED_DATE = DateTime.Now,
                FRIEND_ID = profileOwnerID,
                REQUEST = "N",
                USER_ID = userID
            };
            return entityFriend;
        }
    }
}