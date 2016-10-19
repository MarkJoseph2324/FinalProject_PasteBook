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
        
        public RegistrationModel AddUser(RegistrationModel user)
        {
            dataAccess.AddUser(mapper.MapUserToDB(user));
            return user;
        }

        public LogInModel CheckUserUserCredential(LogInModel model)
        {
            PasswordManager pwdManager = new PasswordManager();
            User userCredential = new User();
            userCredential = dataAccess.GetUser(mapper.MapUserCredentials(model));
            if (userCredential.ToString().Count() != 0)
            {
                if (pwdManager.IsPasswordMatch(model.Password, userCredential.Salt, userCredential.Password))
                {
                    model.FirstName = userCredential.FirstName;
                    model.UserID = userCredential.ID;
                    return model;
                }
                else
                {
                    model.Password = null;
                    return model;
                }
            }
            else
            {
                model.Email = userCredential.Email;
                return model;
            }
        }

        public bool CreatePost(string post, int posterID, int profileOwnerID)
        {
            bool returnValue = false;

            returnValue = dataAccess.CreatePost(mapper.MapPost(post, posterID, profileOwnerID));

            return returnValue;
        }

        public List<Post> RetrievePostForNewsFeed(int userID)
        {
            List<Post> postList = new List<Post>();
            postList = dataAccess.RetrievePostForNewsFeed(userID);
            return postList;
        }
    }
}