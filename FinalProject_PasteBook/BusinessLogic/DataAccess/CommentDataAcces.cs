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
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.COMMENTs.Add(comment);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return comment;
        }

        public List<COMMENT> GetAllComments()
        {
            List<COMMENT> entityComment = new List<COMMENT>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    entityComment = context.COMMENTs.Select(x => x).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return entityComment;
        }
    }
}
