using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string postContent { get; set; }
        public int ProfileOwnerID { get; set; }
        public int PosterID { get; set; }
    }
}