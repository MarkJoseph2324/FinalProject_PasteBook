using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class PasswordManager
    {
        /// <summary>
        /// http://www.codeproject.com/Articles/608860/Understanding-and-Implementing-Password-Hashing
        /// </summary>

        private RNGCryptoServiceProvider CryptoServiceProvider = null;
        private const int SaltSize = 24;

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = GetSaltString();
            string finalString = plainTextPassword + salt;
            return GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == GetPasswordHashAndSalt(finalString);
        }

        public string GetPasswordHashAndSalt(string message)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return GetString(resultBytes);
        }

        public byte[] GetBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public string GetString(byte[] resultBytes)
        {
            return Encoding.ASCII.GetString(resultBytes);
        }
        
        public void SaltGenerator()
        {
            CryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public string GetSaltString()
        {
            byte[] saltBytes = new byte[SaltSize];
            CryptoServiceProvider.GetNonZeroBytes(saltBytes);
            string saltString = GetString(saltBytes);
            return saltString;
        }
    }
}
