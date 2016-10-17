using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccess
    {
        public bool AddUser(User user)
        {
            RegistrationManager registrationManager = new RegistrationManager();
            PasswordManager pwdManager = new PasswordManager();

            bool returnValue = false;
            string salt = string.Empty;
            user.Password = pwdManager.GeneratePasswordHash(user.Password, out salt);
            registrationManager.AddUserToDatabase(user);
            return returnValue;
        }

        public bool GetCoutries()
        {
            DataAccessMapper countryMapper = new DataAccessMapper();
            CountryManager countryManager = new CountryManager();

            bool returnValue = false;
            List<RefCountry> countryList = new List<RefCountry>();
            countryList = countryMapper.MapCountryFromDB(countryManager.GetAllCountries());
            return returnValue;
        }
    }
}
