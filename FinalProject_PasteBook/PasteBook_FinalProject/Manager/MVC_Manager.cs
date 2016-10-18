﻿using DataAccessLibrary;
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
        
        public RegistrationModel AddUser(RegistrationModel user)
        {
            dataAccess.AddUser(mapper.MapUserToDB(user));
            return user;
        }

        public string CheckUserIfExisting(LogInModel model)
        {
            PasswordManager pwdManager = new PasswordManager();
            User userCredential = new User();

            string returnValue = string.Empty;

            userCredential = dataAccess.CheckIfUserExist(mapper.MapUserCredentials(model));
            if (userCredential.ToString().Count() != 0)
            {
                if (pwdManager.IsPasswordMatch(model.Password, userCredential.Salt, userCredential.Password))
                {
                    returnValue = userCredential.FirstName;
                }
            }
            else
            {
                returnValue = string.Empty;                
            }
            return returnValue;
        }
    }
}