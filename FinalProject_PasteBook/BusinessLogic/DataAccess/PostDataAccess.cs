using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class PostDataAccess
    {
        public bool CreatePost(POST post)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.POSTs.Add(post);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }


        public List<POST> GetPostForNewsFeed(int userID, int profileOwnerID, List<FRIEND> friendsList)
        {
            List<POST> listOfPost = new List<POST>();
            List<POST> listOfPostOfFriends = new List<POST>();
            int friendID = 0;
            
            try
            {
                using (var context = new PastebookEntities())
                {
                    listOfPost = context.POSTs.Include("COMMENTs").Include("LIKEs").Include("USER").Include("USER1").Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID).ToList();
                    foreach (var friendItem in friendsList)
                    {
                        if (userID != 0)
                        {
                            if (friendItem.USER_ID == userID)
                            {
                                friendID = friendItem.FRIEND_ID;
                            }
                            else if (friendItem.FRIEND_ID == userID)
                            {
                                friendID = friendItem.USER_ID;
                            }
                        }

                        var postList = context.POSTs.Include("COMMENTs").Include("LIKEs").Include("USER").Include("USER1").Where((x=>x.POSTER_ID == friendID && x.PROFILE_OWNER_ID == friendID)).ToList();
                        
                            

                            foreach (var item in postList)
                            {
                                listOfPost.Add(new POST
                                {
                                    CREATED_DATE = item.CREATED_DATE,
                                    ID = item.ID,
                                    CONTENT = item.CONTENT,
                                    POSTER_ID = item.POSTER_ID,
                                    PROFILE_OWNER_ID = item.PROFILE_OWNER_ID,
                                    USER = item.USER,
                                    USER1 = item.USER1
                                });
                            }
                        
                    };

                    foreach (var item in listOfPostOfFriends)
                    {

                    }
                    listOfPost = listOfPost.OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return listOfPost;
        }
    }
}
