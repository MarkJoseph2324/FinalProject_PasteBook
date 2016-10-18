using DataAccessLibrary;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class DataAccessMapper
    {
        public USER MapAddUser(User user)
        {
            USER tblUser = new USER()
            {
                USER_NAME = user.Username,
                PASSWORD = user.Password,
                SALT = user.Salt,
                FIRST_NAME = user.FirstName,
                LAST_NAME = user.LastName,
                BIRTHDAY = user.BirthDate,
                COUNTRY_ID = user.CountryID,
                MOBILE_NO = user.MobileNumber,
                GENDER = user.Gender,
                PROFILE_PIC = user.ProfilePicture,
                DATE_CREATED = user.DateCreated,
                ABOUT_ME = user.AboutMe,
                EMAIL_ADDRESS = user.Email
            };
            return tblUser;
        }

        public List<RefCountry> MapCountryFromDB(List<REF_COUNTRY> tblCountry)
        {
            List<RefCountry> country = new List<RefCountry>();
            foreach (var item in tblCountry)
            {
                country.Add(new RefCountry()
                {
                    ID = item.ID,
                    Country = item.COUNTRY
                });

            }
            return country;
        }

    }
}
