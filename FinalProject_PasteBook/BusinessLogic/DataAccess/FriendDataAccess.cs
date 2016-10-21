using Entity;
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
                    friendsList = (context.FRIENDs.Where(x => x.USER_ID == userID || x.FRIEND_ID == userID)).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return friendsList;
        }
    }
}
