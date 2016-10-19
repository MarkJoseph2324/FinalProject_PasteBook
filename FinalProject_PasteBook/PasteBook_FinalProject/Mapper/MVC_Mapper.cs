using DataAccessLibrary;
using PasteBook_FinalProject.Models;
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

        public User MapUserCredentials(LogInModel model)
        {
            User userCredentials = new User()
            {
                Email = model.Email,
                Password = model.Password
            };
            return userCredentials;
        }

        public Post MapPost(string post, int posterID, int profileOwnerID)
        {
            DateTime dateCreated = DateTime.Now;
            Post entityPost = new Post()
            {
                DateCreated = dateCreated,
                postContent = post,
                PosterID = posterID,
                ProfileOwnerID = profileOwnerID
            };
            return entityPost;
        }

        public List<PostModel> MapPostFromDB(List<Post> postList)
        {
            List<PostModel> postModel = new List<PostModel>();
            foreach (var item in postList)
            {
                postModel.Add(new PostModel()
                {
                    DateCreated = item.DateCreated,
                    ID = item.ID,
                    PosterID = item.PosterID,
                    ProfileOwnerID = item.ProfileOwnerID,
                    postContent = item.postContent
                });
            }
            return postModel;
        }
    }
}