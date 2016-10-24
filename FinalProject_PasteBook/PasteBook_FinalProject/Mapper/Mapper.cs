using Entity;
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
    }
}