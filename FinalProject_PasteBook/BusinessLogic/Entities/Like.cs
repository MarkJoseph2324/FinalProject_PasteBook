using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Like
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int LikedByID { get; set; }
    }
}
