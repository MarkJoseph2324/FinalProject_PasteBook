using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class CountryDataAccess
    {
        public List<REF_COUNTRY> GetAllCountries()
        {
            List<REF_COUNTRY> countryList = new List<REF_COUNTRY>();
            using (var context = new PastebookEntities())
            {
                countryList = context.REF_COUNTRY.ToList();
            }
            return countryList;
        }
    }
}
