using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RegistrationManager
    {
        public List<REF_COUNTRY> GetAllCountries()
        {
            List<REF_COUNTRY> countryList = new List<REF_COUNTRY>();
            try
            {
                using (var context = new PastebookEntities())
                {
                    countryList = context.REF_COUNTRY.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return countryList;
        }

        public bool AddUser(USER user)
        {
            bool returnValue = false;
            try
            {
                using (var context = new PastebookEntities())
                {
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return returnValue;
        }
    }
}
