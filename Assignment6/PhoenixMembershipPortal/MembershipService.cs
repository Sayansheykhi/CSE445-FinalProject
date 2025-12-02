using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;

namespace PhoenixMembershipPortal
{
    public class MembershipService : IMembershipService
    {
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
