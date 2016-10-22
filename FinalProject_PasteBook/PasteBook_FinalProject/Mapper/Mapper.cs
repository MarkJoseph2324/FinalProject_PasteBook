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
        public USER UserMapper(RegistrationModel user)
        {
            USER entityUser = new USER()
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

        public List<PostModel> ListOfPostMapper(List<POST> postList, List<USER> userInformation, List<LIKE> likeList, USER currentUser)
        {
            List<PostModel> listOfPost = new List<PostModel>();
            foreach (var item2 in postList)
            {
                listOfPost.Add(new PostModel()
                {
                    DateCreated = item2.CREATED_DATE,
                    ID = item2.ID,
                    postContent = item2.CONTENT,
                    ProfileOwnerID = item2.PROFILE_OWNER_ID,
                    PosterID = item2.POSTER_ID,
                    FullName = currentUser.FIRST_NAME + " "+ currentUser.LAST_NAME,
                    UserInformationList = userInformation,
                    LikeList = likeList
                });
            }
            return listOfPost;
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
    }
}