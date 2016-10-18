using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Notification
    {
        public int ID { get; set; }
        public string NotificationType { get; set; }
        public int ReceiverID { get; set; }
        public int SenderID { get; set; }
        public DateTime DateCreated { get; set; }
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string Seen { get; set; }
    }
}
