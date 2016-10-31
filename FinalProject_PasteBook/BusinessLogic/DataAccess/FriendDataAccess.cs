using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class FriendDataAccess
    {
        public List<FRIEND> GetAllFriends(int userID)
        {
            List<FRIEND> friendsList = new List<FRIEND>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    friendsList = (context.FRIENDs.Include("USER").Include("USER1").Where(x => x.USER_ID == userID)).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return friendsList;
        }

        public bool CheckIfFriend(int userID, int profileOwnerID)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                     var result  = (context.FRIENDs.Where(x => x.USER_ID == userID && x.FRIEND_ID == profileOwnerID && x.REQUEST == "Y")).FirstOrDefault();

                    if(result != null)
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }

        public bool AddFriend(FRIEND friend)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.FRIENDs.Add(friend);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }

        public bool DeclineFriendRequest(FRIEND friend)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    var record = context.FRIENDs.Where(x => x.FRIEND_ID == friend.USER_ID && x.USER_ID == friend.FRIEND_ID && x.REQUEST == "Y").First();
                    context.FRIENDs.Remove(record);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }
    }
}
