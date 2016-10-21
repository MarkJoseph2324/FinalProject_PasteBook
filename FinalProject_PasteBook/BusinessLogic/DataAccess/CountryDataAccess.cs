using Entity;
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
            try
            {
                using (var context = new PastebookEntities())
                {
                    foreach (var item in context.REF_COUNTRY.ToList())
                    {
                        countryList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return countryList;
        }
    }
}
