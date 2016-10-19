using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PostManager
    {
        DataAccessMapper map = new DataAccessMapper();
        public bool AddPost(Post post)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.POSTs.Add(map.MapAddPost(post));
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }


        public List<Post> RetrievePostForNewsFeed(int userID)
        {
            List<Post> listOfPost = new List<Post>();
            List<User> friendsList = new List<User>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    friendsList = GetAllFriends(userID);
                    foreach (var item in friendsList)
                    {
                        listOfPost = map.MapRetrievePostFromDB(context.POSTs.Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID || (x.POSTER_ID == item.ID && x.PROFILE_OWNER_ID == item.ID)).OrderByDescending(x=>x.CREATED_DATE).Take(100).ToList());
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return listOfPost;
        }


        private List<User> GetAllFriends(int userID)
        {
            List<User> friendsList = new List<User>();
            List<Friend> relationship = new List<Friend>();
            int friendID = 0;
            try
            {
                using (var context = new PastebookEntities())
                {
                    var relationshipsList = (context.FRIENDs.Where(x => x.USER_ID == userID || x.FRIEND_ID == userID)).ToList();
                    foreach (var item in relationshipsList)
                    {
                        relationship.Add(new Friend()
                        {
                            FriendID = item.FRIEND_ID,
                            UserID = item.USER_ID
                        });
                    }

                    foreach (var item in relationship)
                    {
                        if (item.UserID == userID)
                        {
                            friendID = item.FriendID;
                        }
                        else if(item.FriendID == userID)
                        {
                            friendID = item.UserID;
                        }

                        friendsList = map.MapUserListFromDB(context.USERs.Where(x => x.ID == friendID).ToList());
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return friendsList;
        }

        public Post RetrievePostForNewsFeed1(int userID)
        {
            Post listOfPost = new Post();
            List<User> friendsList = new List<User>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    friendsList = GetAllFriends(userID);
                    foreach (var item in friendsList)
                    {
                        listOfPost = context.POSTs.Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID || (x.POSTER_ID == item.ID && x.PROFILE_OWNER_ID == item.ID)).OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();
                    };
                }
            }
            catch (Exception ex)
            {

            }
            return listOfPost;
        }

    }
}
