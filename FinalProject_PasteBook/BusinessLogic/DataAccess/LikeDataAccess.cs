using Entities;
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
            using (var context = new PastebookEntities())
            {
                context.LIKEs.Add(like);
                returnValue = context.SaveChanges() != 0;
            }
            return returnValue;
        }

        public bool Unlike(LIKE like)
        {
            bool returnValue = false;
            using (var context = new PastebookEntities())
            {
                var itemToRemove = context.LIKEs.SingleOrDefault(x => x.POST_ID == like.POST_ID && x.LIKE_BY == like.LIKE_BY); //returns a single item.

                if (itemToRemove != null)
                {
                    context.LIKEs.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }
            return returnValue;
        }

        

        public List<LIKE> GetAllLike()
        {
            List<LIKE> likeList = new List<LIKE>();
            using (var context = new PastebookEntities())
            {
                likeList = context.LIKEs.Select(x => x).ToList();
            }
            return likeList;
        }
    }
}
