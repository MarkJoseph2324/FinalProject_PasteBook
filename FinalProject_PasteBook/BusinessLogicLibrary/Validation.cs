using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class Validation
    {
        UserDataAccess userDataAccess = new UserDataAccess();

        public bool CheckEmailformat(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckIfEmailIsExisting(string email)
        {
            bool returnValue = false;
            USER user = new USER();
            user.EMAIL_ADDRESS = email.Trim();
            var userResult = userDataAccess.GetSpecificUser(user);
            if(userResult != null)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }
            
            return returnValue;
        }

        public bool CheckIfUsernameIsExisting(string username)
        {
            bool returnValue = false;
            USER user = new USER();
            user.USER_NAME = username.Trim();
            var result = userDataAccess.GetSpecificUser(user);
            if(result != null)
            {
                returnValue = true;
            }
            return returnValue;
        }
    }
}
