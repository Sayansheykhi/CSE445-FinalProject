using System;
using System.Security.Cryptography;
using System.Text;

namespace UtilityDemoWeb
{
    public static class PasswordHasher
    {
        //returns Base64-encoded SHA256 hash of the input string
        public static string HashPassword(string plainText)
        {
            if (plainText == null) plainText = "";

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hashBytes = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
