using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class LogInManager
    {
        public User GetUser(User user)
        {
            DataAccessMapper mapper = new DataAccessMapper();
            User userCredential = new User();
            try
            {
                using (var context = new PastebookEntities())
                {
                    var userCredentials = context.USERs.Where(model => model.EMAIL_ADDRESS == user.Email).FirstOrDefault();

                    userCredential = mapper.MapUserCredentialFromDB(userCredentials);
                }
            }
            catch (Exception ex)
            {
                
            }
            return userCredential;
        }
    }
}
