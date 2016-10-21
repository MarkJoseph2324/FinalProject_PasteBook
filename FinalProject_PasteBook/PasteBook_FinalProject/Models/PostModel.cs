using BusinessLogicLibrary;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject.Models
{
    public class PostModel
    {
        public PostModel()
        {
            UserInformationList = new List<USER>();
        }
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public string postContent { get; set; }
        public int ProfileOwnerID { get; set; }
        public int PosterID { get; set; }        
        public List<LIKE> LikeList { get; set; }
        public List<COMMENT> CommentList { get; set; }
        public List<USER> UserInformationList { get; set; }
    }
}