using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLibrary
{
    public class UserDataAccess
    {
        public bool AddUser(USER user)
        {
            bool returnValue = false;
            using (var context = new PastebookEntities())
            {
                context.USERs.Add(user);
                returnValue = context.SaveChanges() != 0;
            }

            return returnValue;
        }

        public USER GetSpecificUser(USER user)
        {
            USER entityUser = new USER();
            using (var context = new PastebookEntities())
            {
                if (user.EMAIL_ADDRESS != null)
                {
                    entityUser = context.USERs.Include("REF_COUNTRY").Include("FRIENDs").Include("FRIENDs.USER1").Include("FRIENDs1").Include("LIKEs").Include("NOTIFICATIONs").Include("NOTIFICATIONs1").Include("POSTs").Include("POSTs1").Where(x => x.EMAIL_ADDRESS == user.EMAIL_ADDRESS).FirstOrDefault();
                }
                if (user.ID != 0)
                {
                    entityUser = context.USERs.Include("REF_COUNTRY").Include("FRIENDs").Include("FRIENDs.USER1").Include("FRIENDs1").Include("LIKEs").Include("NOTIFICATIONs").Include("NOTIFICATIONs1").Include("POSTs").Include("POSTs1").Where(x => x.ID == user.ID).FirstOrDefault();
                }
                if (!string.IsNullOrEmpty(user.USER_NAME))
                {
                    entityUser = context.USERs.Include("REF_COUNTRY").Include("FRIENDs").Include("FRIENDs.USER1").Include("FRIENDs1").Include("LIKEs").Include("NOTIFICATIONs").Include("NOTIFICATIONs1").Include("POSTs").Include("POSTs1").Where(x => x.USER_NAME == user.USER_NAME).FirstOrDefault();
                }
            }
            return entityUser;
        }

        public List<USER> Search(int userID, string searchValue)
        {
            List<USER> entityUser = new List<USER>();
            using (var context = new PastebookEntities())
            {
                entityUser = context.USERs.Include("REF_COUNTRY").Include("FRIENDs").Include("FRIENDs1").Include("LIKEs").Include("NOTIFICATIONs").Include("NOTIFICATIONs1").Include("POSTs").Include("POSTs1").Where(x => ((x.ID != userID) && x.FIRST_NAME.Contains(searchValue)) || ((x.ID != userID) && x.LAST_NAME.Contains(searchValue))).ToList();
            }
            return entityUser;
        }

        public List<USER> GetAllFriendsInformation(int userID, List<FRIEND> friendsList)
        {
            List<USER> friendsInformationList = new List<USER>();
            int friendID = 0;
            using (var context = new PastebookEntities())
            {
                foreach (var item in friendsList)
                {
                    if (userID != 0)
                    {
                        if (item.USER_ID == userID)
                        {
                            friendID = item.FRIEND_ID;
                        }
                        else if (item.FRIEND_ID == userID)
                        {
                            friendID = item.USER_ID;
                        }
                    }

                    var list = context.USERs.Include("REF_COUNTRY").Include("FRIENDs").Include("FRIENDs1").Include("LIKEs").Include("NOTIFICATIONs").Include("NOTIFICATIONs1").Include("POSTs").Include("POSTs1").Where(x => x.ID == friendID).ToList();

                    foreach (var item1 in list)
                    {
                        friendsInformationList.Add(new USER()
                        {
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

            return friendsInformationList;
        }

        public bool UpdateUserAboutMe(USER user)
        {
            int status = 0;
            using (var context = new PastebookEntities())
            {
                var user1 = context.USERs.Where(x => x.ID == user.ID).SingleOrDefault();

                user1.ABOUT_ME = user.ABOUT_ME;
                status = context.SaveChanges();
            }

            return status != 0;
        }

        public bool ChnageProfilePicture(USER user)
        {
            int status = 0;
            using (var context = new PastebookEntities())
            {
                var user1 = context.USERs.Where(x => x.ID == user.ID).SingleOrDefault();

                user1.PROFILE_PIC = user.PROFILE_PIC;
                status = context.SaveChanges();
            }
            return status != 0;
        }

        //public bool CheckIfEmailExist(string email)
        //{
        //    bool returnValue = false;
        //    try
        //    {
        //        using (var context = new PastebookEntities())
        //        {
        //            var result = context.USERs.Where(x => x.EMAIL_ADDRESS == email).SingleOrDefault();

        //            if (result != null)
        //            {
        //                returnValue = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return returnValue;
        //}
    }
}
