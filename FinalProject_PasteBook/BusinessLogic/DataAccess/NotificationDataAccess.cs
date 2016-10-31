using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{ 
    public class NotificationDataAccess
    {
        public bool AddNotification(NOTIFICATION notif)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.NOTIFICATIONs.Add(notif);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }

        public List<NOTIFICATION> GetNotificationList(int userID)
        {
            List<NOTIFICATION> entityNotif = new List<NOTIFICATION>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    entityNotif = context.NOTIFICATIONs.Include("USER").Include("USER1").Where(x => (x.RECEIVER_ID != userID && x.SEEN.Equals("N") && x.NOTIF_TYPE == "L") || ((x.RECEIVER_ID == userID && x.SEEN.Equals("N") && x.NOTIF_TYPE == "C"))).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return entityNotif;
        }

       
    }
}
