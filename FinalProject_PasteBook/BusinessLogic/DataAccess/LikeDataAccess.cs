using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class LikeDataAccess
    {
        public bool AddLike(LIKE like)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    context.LIKEs.Add(like);
                    returnValue = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }

            return returnValue;
        }

        public List<LIKE> GetAllLike()
        {
            List<LIKE> likeList = new List<LIKE>();

            try
            {
                using (var context = new PastebookEntities())
                {
                    likeList = context.LIKEs.Select(x => x).ToList();
                }
            }
            catch (Exception)
            {
                
            }
            return likeList;
        }
    }
}
