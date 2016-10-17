using DataAccess;
using PasteBook_FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject
{
    public class MVC_CountryManager
    {

        public RegistrationModel GetAllCountries(List<RefCountry> countries)
        {
            RegistrationModel countriesList = new RegistrationModel();
            foreach (var item in countries)
            {
                countriesList.CountryID = item.ID;
                countriesList.Country = item.Country;
            }
            return countriesList;
        }
    }
}