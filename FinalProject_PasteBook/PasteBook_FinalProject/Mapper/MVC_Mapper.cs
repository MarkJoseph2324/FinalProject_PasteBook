using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject
{
    public class MVC_Mapper
    {
        public CountryModel MapCountryFromDB(RefCountry country)
        {
            CountryModel countryModel = new CountryModel()
            {
                ID = country.ID,
                Country = country.Country
            };

            return countryModel;
        }

        public User MapUserToDB(RegistrationModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.Birthday,
                Email = model.Email,
                Gender = model.Gender,
                MobileNumber = model.MobileNumber,
                CountryID = model.CountryID
            };
            return user;
        }
    }
}