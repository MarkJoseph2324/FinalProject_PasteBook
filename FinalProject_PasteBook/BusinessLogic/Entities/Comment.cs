using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int PosterID { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
