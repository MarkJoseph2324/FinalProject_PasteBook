using BusinessLogicLibrary;
using DataAccessLibrary;
using DataAccessLibrary.DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class BusinessLogic
    {
        PasswordManager passwordManager = new PasswordManager();
        CountryDataAccess countryDataAccess = new CountryDataAccess();
        UserDataAccess userDataAccess = new UserDataAccess();
        PostDataAccess postDataAccess = new PostDataAccess();
        FriendDataAccess friendDataAccess = new FriendDataAccess();
        LikeDataAccess likeDataAccess = new LikeDataAccess();
        CommentDataAcces commentDataAcces = new CommentDataAcces();

        public List<REF_COUNTRY> GetAllCountries()
        {
            return countryDataAccess.GetAllCountries();
        }

        public bool AddUser(USER user)
        {
            string salt = string.Empty;
            DateTime curretDate = DateTime.Now;
            user.DATE_CREATED = curretDate;
            user.PASSWORD = passwordManager.GeneratePasswordHash(user.PASSWORD, out salt);
            user.SALT = salt;
            return userDataAccess.AddUser(user);
        }

        public USER GetSpecificUser(USER user)
        {
            return userDataAccess.GetSpecificUser(user);
        }

        public USER CheckUserCredential(USER user)
        {
            USER userCredential = new USER();
            userCredential = userDataAccess.GetSpecificUser(user);
            if (userCredential.ToString().Count() != 0)
            {
                if (passwordManager.IsPasswordMatch(user.PASSWORD, userCredential.SALT, userCredential.PASSWORD))
                {
                    return userCredential;
                }
                else
                {
                    userCredential.PASSWORD = string.Empty;
                    return userCredential;
                }
            }
            else
            {
                userCredential.EMAIL_ADDRESS = string.Empty;
                return userCredential;
            }
        } 

        public bool CreatePost(string postContent, int posterID, int profileOwner)
        {
            POST entityPost = new POST();
            entityPost.CONTENT = postContent;
            entityPost.CREATED_DATE = DateTime.Now;
            entityPost.POSTER_ID = posterID;
            entityPost.PROFILE_OWNER_ID = profileOwner;
            return postDataAccess.CreatePost(entityPost);
        }

        public List<POST> GetPostForNewsFeed(int posterID, int profileOwnerID)
        {
            return postDataAccess.GetPostForNewsFeed(posterID, profileOwnerID);
        }

        public List<FRIEND> GetFriendsList(int userID)
        {
            return friendDataAccess.GetAllFriends(userID);
        }

        public List<USER> GetFriendsInformationList(int userID, List<FRIEND> friendsList)
        {
            return userDataAccess.GetAllFriendsInformation(userID, friendsList);
        }

        public List<USER> MergeFriendsAndUserList(List<USER> friendsList, USER userInfo)
        {
            List<USER> mergeList = new List<USER>();
            foreach (var item in friendsList)
            {
                mergeList.Add(new USER()
                {
                    ABOUT_ME = item.ABOUT_ME,
                    BIRTHDAY = item.BIRTHDAY,
                    COUNTRY_ID = item.COUNTRY_ID,
                    DATE_CREATED = item.DATE_CREATED,
                    EMAIL_ADDRESS = item.EMAIL_ADDRESS,
                    FIRST_NAME = item.FIRST_NAME,
                    GENDER = item.GENDER,
                    ID = item.ID,
                    LAST_NAME = item.LAST_NAME,
                    MOBILE_NO = item.MOBILE_NO,
                    PASSWORD = item.PASSWORD,
                    PROFILE_PIC = item.PROFILE_PIC,
                    SALT = item.SALT,
                    USER_NAME = item.USER_NAME
                });
            }
            mergeList.Add(new USER()
            {
                ABOUT_ME = userInfo.ABOUT_ME,
                BIRTHDAY = userInfo.BIRTHDAY,
                COUNTRY_ID = userInfo.COUNTRY_ID,
                DATE_CREATED = userInfo.DATE_CREATED,
                EMAIL_ADDRESS = userInfo.EMAIL_ADDRESS,
                FIRST_NAME = userInfo.FIRST_NAME,
                GENDER = userInfo.GENDER,
                ID = userInfo.ID,
                LAST_NAME = userInfo.LAST_NAME,
                MOBILE_NO = userInfo.MOBILE_NO,
                PASSWORD = userInfo.PASSWORD,
                PROFILE_PIC = userInfo.PROFILE_PIC,
                SALT = userInfo.SALT,
                USER_NAME = userInfo.USER_NAME
            });
            return mergeList;
        }
        /// <summary>
        /// Reference:
        /// http://stackoverflow.com/questions/3177836/how-to-format-time-since-xxx-e-g-4-minutes-ago-similar-to-stack-exchange-site
        /// </summary>
        public string TimeStamp(DateTime date)
        {
            TimeSpan span = DateTime.Now - date;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                {
                    years += 1;
                }
                return String.Format(" {0} {1} ago", years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                {
                    months += 1;
                }
                return String.Format(" {0} {1} ago", months, months == 1 ? "month" : "months");
            }
            if (span.Days > 0)
            {
                return String.Format(" {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");
            }
            if (span.Hours > 0)
            {
                return String.Format(" {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");
            }
            if (span.Minutes > 0)
            {
                return String.Format(" {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            }
            if (span.Seconds > 5)
            {
                return String.Format(" {0} seconds ago", span.Seconds);
            }
            if (span.Seconds <= 5)
            {
                return "just now";
            }
            return string.Empty;
        }

        public bool AddLike(LIKE like)
        {
            return likeDataAccess.AddLike(like);
        }

        public List<LIKE> GetAllLikeList()
        {
            return likeDataAccess.GetAllLike();
        }

        public bool AddComment(COMMENT comment)
        {
            return commentDataAcces.AddComment(comment);
        }

        public List<COMMENT> GetAllComments()
        {
            return commentDataAcces.GetAllComments();
        }
    }
}
