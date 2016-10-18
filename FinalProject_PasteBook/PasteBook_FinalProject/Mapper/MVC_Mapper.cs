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
    }
}