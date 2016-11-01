using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (var context = new PastebookEntities())
            {
                context.NOTIFICATIONs.Add(notif);
                returnValue = context.SaveChanges() != 0;
            }
            return returnValue;
        }

        public List<NOTIFICATION> GetNotificationList(int userID)
        {
            List<NOTIFICATION> entityNotif = new List<NOTIFICATION>();
            using (var context = new PastebookEntities())
            {
                entityNotif = context.NOTIFICATIONs.Include("USER").Include("USER1").Where(x => (x.RECEIVER_ID == userID && x.SENDER_ID != userID && x.NOTIF_TYPE == "L") || ((x.RECEIVER_ID == userID && x.SENDER_ID != userID && x.NOTIF_TYPE == "C") || (x.RECEIVER_ID == userID && x.NOTIF_TYPE == "F"))).ToList();
            }
            return entityNotif;
        }

        public List<NOTIFICATION> GetNotificationListCount(int userID)
        {
            List<NOTIFICATION> entityNotif = new List<NOTIFICATION>();
            using (var context = new PastebookEntities())
            {
                entityNotif = context.NOTIFICATIONs.Include("USER").Include("USER1").Where(x => (x.RECEIVER_ID == userID && x.SENDER_ID != userID && x.SEEN.Equals("N") && x.NOTIF_TYPE == "L") || ((x.RECEIVER_ID == userID && x.SENDER_ID != userID && x.SEEN.Equals("N") && x.NOTIF_TYPE == "C") || (x.RECEIVER_ID == userID && x.SEEN.Equals("N") && x.NOTIF_TYPE == "F"))).ToList();
            }
            return entityNotif;
        }

        public bool SeenNotification(int userID, List<NOTIFICATION> notif)
        {
            bool returnValue = false;
            using (var context = new PastebookEntities())
            {
                foreach (var item in notif)
                {
                    item.SEEN = "Y";
                    context.Entry(item).State = EntityState.Modified;
                    returnValue =context.SaveChanges() !=0;
                }
            }
            return returnValue;
        }
    }
}
