using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// WCF service implementation for membership-related operations.
    /// Provides functionality for checking username availability by querying Member.xml.
    /// </summary>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Checks if a username is available (not already taken) in the system.
        /// Searches Member.xml for existing usernames using case-insensitive comparison.
        /// </summary>
        /// <param name="username">The username to check for availability</param>
        /// <returns>
        /// True if the username already exists in Member.xml (not available),
        /// False if the username does not exist (available) or if Member.xml is not found
        /// </returns>
        public bool CheckUsernameAvailability(string username)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");

            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (!File.Exists(filePath))
                return false; // XML not found → assume unavailable

            XDocument doc = XDocument.Load(filePath);

            var exists = doc.Descendants("Username")
                            .Any(u => string.Equals(u.Value.Trim(),
                                                    username.Trim(),
                                                    StringComparison.OrdinalIgnoreCase));

            return exists;
        }
    }
}
