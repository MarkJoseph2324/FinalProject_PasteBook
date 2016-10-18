using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class RegistrationManager
    {
        public bool AddUserToDatabase(User user)
        {
            DataAccessMapper map = new DataAccessMapper();
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                    DateTime curretDate = DateTime.Now;
                    user.DateCreated = curretDate;
                    context.USERs.Add(map.MapAddUser(user));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return returnValue;
        }
    }
}
