using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
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
            user.Salt = salt;
            returnValue = registrationManager.AddUserToDatabase(user);
            return returnValue;
        }

        public List<RefCountry> GetCoutries()
        {
            DataAccessMapper countryMapper = new DataAccessMapper();
            CountryManager countryManager = new CountryManager();
            
            List<RefCountry> countryList = new List<RefCountry>();
            countryList = countryMapper.MapCountryFromDB(countryManager.GetAllCountries());
            return countryList;
        }
    }
}
