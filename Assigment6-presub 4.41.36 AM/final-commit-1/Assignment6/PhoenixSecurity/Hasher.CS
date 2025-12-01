using System;
using System.Security.Cryptography;
using System.Text;

namespace PhoenixSecurity
{
    public class Hasher
    {
        public string HashText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
