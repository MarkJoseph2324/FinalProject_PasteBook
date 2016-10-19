using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DataAccess
    {
        public List<RefCountry> GetCoutries()
        {
            DataAccessMapper countryMapper = new DataAccessMapper();
            CountryManager countryManager = new CountryManager();

            List<RefCountry> countryList = new List<RefCountry>();
            countryList = countryMapper.MapCountryFromDB(countryManager.GetAllCountries());
            return countryList;
        }

        public User GetUser(User user)
        {
            LogInManager logInManager = new LogInManager();
            User userCredential = new User();

            userCredential = logInManager.GetUser(user);

            return userCredential;
        }

        public bool AddUser(User user)
        {
            RegistrationManager registrationManager = new RegistrationManager();
            PasswordManager pwdManager = new PasswordManager();

            bool returnValue = false;
            string salt = string.Empty;
            user.Password = pwdManager.GeneratePasswordHash(user.Password, out salt);
            user.Salt = salt;
            returnValue = registrationManager.AddUserToDatabase(user);
            return returnValue;
        }

        public bool CreatePost(Post post)
        {
            PostManager postManager = new PostManager();
            bool returnValue = false;
            returnValue = postManager.AddPost(post);
            return returnValue;
        }

        public List<Post> RetrievePostForNewsFeed(int userID)
        {
            PostManager postManager = new PostManager();
            List<Post> postList = new List<Post>();
            postList = postManager.RetrievePostForNewsFeed(userID);
            return postList;
        }

        public Post RetrievePostForNewsFeed1(int userID)
        {
            PostManager postManager = new PostManager();
            Post postList = new Post();
            postList = postManager.RetrievePostForNewsFeed(userID);
            return postList;
        }
    }
}
