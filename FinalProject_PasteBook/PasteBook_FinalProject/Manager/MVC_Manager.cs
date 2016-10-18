using DataAccessLibrary;
using PasteBook_FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBook_FinalProject
{
    public class MVC_Manager
    {
        DataAccess dataAccess = new DataAccess();
        MVC_Mapper mapper = new MVC_Mapper();
           
        public List<CountryModel> GetAllCountries()
        {
            List<CountryModel> countriesList = new List<CountryModel>();
            foreach (var item in dataAccess.GetCoutries())
            {
                countriesList.Add(mapper.MapCountryFromDB(item));
            }
            
            return countriesList;
        }
    }
}