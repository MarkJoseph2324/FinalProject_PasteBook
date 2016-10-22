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


        public List<POST> GetPostForNewsFeed(int posterID, int profileOwnerID)
        {
            FriendDataAccess friendDataAccess = new FriendDataAccess();
            UserDataAccess userDataAccess = new UserDataAccess();
            
            List<POST> listOfPost = new List<POST>();
            List<POST> listOfPostOfFriends = new List<POST>();
            List<FRIEND> friendsList = new List<FRIEND>();
            List<USER> friendsInformationList = new List<USER>();

            try
            {
                using (var context = new PastebookEntities())
                {
                    friendsList = friendDataAccess.GetAllFriends(posterID);
                    friendsInformationList = userDataAccess.GetAllFriendsInformation(posterID, friendsList);

                    listOfPost = context.POSTs.Where(x => x.POSTER_ID == posterID || x.PROFILE_OWNER_ID == posterID).ToList();
                    foreach (var friendItem in friendsInformationList)
                    {
                        var postList = context.POSTs.Where((x=>x.POSTER_ID == friendItem.ID && x.PROFILE_OWNER_ID == friendItem.ID)).ToList();

                        foreach (var item in postList)
                        {
                            listOfPost.Add(new POST
                            {
                                CREATED_DATE = item.CREATED_DATE,
                                ID = item.ID,
                                CONTENT = item.CONTENT,
                                POSTER_ID = item.POSTER_ID,
                                PROFILE_OWNER_ID = item.PROFILE_OWNER_ID
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
