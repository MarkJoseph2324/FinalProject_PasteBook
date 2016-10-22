using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class UserDataAccess
    {
        public bool AddUser(USER user)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.USERs.Add(user);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }

        public USER GetSpecificUser(USER user)
        {
            USER entityUser = new USER();
            try
            {
                using (var context = new PastebookEntities())
                {
                    if (user.EMAIL_ADDRESS != null)
                    {
                        entityUser = context.USERs.Where(x => x.EMAIL_ADDRESS == user.EMAIL_ADDRESS).FirstOrDefault();
                    }
                    if(user.ID != 0)
                    {
                        entityUser = context.USERs.Where(x => x.ID == user.ID).FirstOrDefault();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return entityUser;
        }


        public List<USER> GetAllFriendsInformation(int userID, List<FRIEND> friendsList)
        {
            List<USER> friendsInformationList = new List<USER>();
            int friendID = 0;
            try
            {
                using (var context = new PastebookEntities())
                {
                    foreach (var item in friendsList)
                    {
                        if (item.USER_ID == userID)
                        {
                            friendID = item.FRIEND_ID;
                        }
                        else if (item.FRIEND_ID == userID)
                        {
                            friendID = item.USER_ID;
                        }

                        var list = context.USERs.Where(x => x.ID == friendID).ToList();

                        foreach (var item1 in list)
                        {
                            friendsInformationList.Add(new USER(){
                                ID = item1.ID,
                                ABOUT_ME = item1.ABOUT_ME,
                                BIRTHDAY = item1.BIRTHDAY,
                                DATE_CREATED = item1.DATE_CREATED,
                                EMAIL_ADDRESS = item1.EMAIL_ADDRESS,
                                FIRST_NAME = item1.FIRST_NAME,
                                GENDER = item1.GENDER,
                                LAST_NAME = item1.LAST_NAME,
                                MOBILE_NO = item1.MOBILE_NO,
                                PASSWORD = item1.PASSWORD,
                                PROFILE_PIC = item1.PROFILE_PIC,
                                SALT = item1.SALT,
                                USER_NAME = item1.USER_NAME,
                                COUNTRY_ID = item1.COUNTRY_ID
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return friendsInformationList;
        }
    }
}
