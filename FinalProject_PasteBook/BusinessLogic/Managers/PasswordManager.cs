using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PasswordManager
    {
        /// <summary>
        /// http://www.codeproject.com/Articles/608860/Understanding-and-Implementing-Password-Hashing
        /// </summary>

        HashComputer hashComputer = new HashComputer();
        SaltGenerator saltGenerator = new SaltGenerator();

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = saltGenerator.GetSaltString();
            string finalString = plainTextPassword + salt;
            return hashComputer.GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }

    public class Utility
    {
        public byte[] GetBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public string GetString(byte[] resultBytes)
        {
            return Encoding.ASCII.GetString(resultBytes);
        }
    }

    public class HashComputer
    {
        Utility utility = new Utility();
        public string GetPasswordHashAndSalt(string message)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return utility.GetString(resultBytes);
        }
    }

    public class SaltGenerator
    {
        Utility utility = new Utility();
        private static RNGCryptoServiceProvider CryptoServiceProvider = null;
        private const int SaltSize = 24;

        public SaltGenerator()
        {
            CryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public string GetSaltString()
        {
            byte[] saltBytes = new byte[SaltSize];
            CryptoServiceProvider.GetNonZeroBytes(saltBytes);
            string saltString = utility.GetString(saltBytes);
            return saltString;
        }
    }
}
