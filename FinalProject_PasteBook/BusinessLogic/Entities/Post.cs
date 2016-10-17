using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string postContent { get; set; }
        public int ProfileOwnerID { get; set; }
        public int PosterID { get; set; }
    }
}
