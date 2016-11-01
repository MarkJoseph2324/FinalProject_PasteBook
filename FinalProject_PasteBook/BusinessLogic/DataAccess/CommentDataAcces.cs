using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class CommentDataAcces
    {
        public COMMENT AddComment(COMMENT comment)
        {
            using (var context = new PastebookEntities())
            {
                context.COMMENTs.Add(comment);
                context.SaveChanges();
            }
            return comment;
        }

        public List<COMMENT> GetAllComments()
        {
            List<COMMENT> entityComment = new List<COMMENT>();
            using (var context = new PastebookEntities())
            {
                entityComment = context.COMMENTs.Select(x => x).ToList();
            }
            return entityComment;
        }
    }
}
