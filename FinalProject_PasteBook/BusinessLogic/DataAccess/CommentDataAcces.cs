using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class CommentDataAcces
    {
        public bool AddComment(COMMENT comment)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.COMMENTs.Add(comment);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
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
