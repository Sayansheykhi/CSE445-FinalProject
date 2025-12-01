using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleSecurityLib
{
    /// <summary>
    /// Provides cryptographic hashing functionality using the SHA-256 algorithm.
    /// This class implements a simple, static method for computing one-way hash values
    /// of input strings, commonly used for password hashing, data integrity verification,
    /// and digital signatures.
    /// </summary>
    public class SimpleHasher
    {
        /// <summary>
        /// Computes the SHA-256 hash of the input string and returns it as a hexadecimal string.
        /// SHA-256 is a cryptographic hash function that produces a 256-bit (32-byte) hash value,
        /// which is displayed as a 64-character hexadecimal string.
        /// </summary>
        /// <param name="input">The input string to be hashed. Cannot be null.</param>
        /// <returns>
        /// A 64-character lowercase hexadecimal string representing the SHA-256 hash
        /// of the input. Each byte is represented as two hexadecimal characters (x2 format).
        /// </returns>
        /// <remarks>
        /// This method uses the SHA-256 algorithm from the System.Security.Cryptography namespace.
        /// The input is first converted to UTF-8 byte array, then hashed. The resulting hash bytes
        /// are converted to a hexadecimal string representation. The using statement ensures
        /// proper disposal of the SHA256 object to free cryptographic resources.
        /// 
        /// Example: ComputeHash("hello") returns "2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824"
        /// </remarks>
        public static string ComputeHash(string input)
        {
            // Create SHA-256 hash algorithm instance
            // Using statement ensures proper disposal of cryptographic resources
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert input string to UTF-8 byte array and compute hash
                // UTF-8 encoding ensures consistent byte representation across platforms
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                
                // Build hexadecimal string representation of hash bytes
                StringBuilder builder = new StringBuilder();
                
                // Iterate through each byte in the hash result
                // Each byte is converted to two hexadecimal characters (x2 format)
                // Example: byte value 255 becomes "ff", byte value 0 becomes "00"
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                
                // Return the complete 64-character hexadecimal hash string
                return builder.ToString();
            }
        }
    }
}

