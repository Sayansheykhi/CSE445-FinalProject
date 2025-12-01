using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// XMLManager provides static utility methods for managing XML data files
    /// used for storing member and staff user information.
    /// Handles read, write, and modify operations for Member.xml and Staff.xml files.
    /// </summary>
    public static class XMLManager
    {
        /// <summary>
        /// Gets the physical file path for Member.xml in the App_Data folder.
        /// Uses Server.MapPath to resolve the virtual path to a physical path.
        /// </summary>
        /// <returns>Full physical path to Member.xml file</returns>
        private static string GetMemberFilePath()
        {
            return HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
        }

        /// <summary>
        /// Gets the physical file path for Staff.xml in the App_Data folder.
        /// Uses Server.MapPath to resolve the virtual path to a physical path.
        /// </summary>
        /// <returns>Full physical path to Staff.xml file</returns>
        private static string GetStaffFilePath()
        {
            return HttpContext.Current.Server.MapPath("~/App_Data/Staff.xml");
        }

        /// <summary>
        /// Loads an XML document from the specified file path, or creates a new document
        /// with the specified root element name if the file doesn't exist.
        /// </summary>
        /// <param name="filePath">Physical path to the XML file</param>
        /// <param name="rootElementName">Name of the root element to create if file doesn't exist</param>
        /// <returns>XDocument loaded from file or new empty document</returns>
        private static XDocument LoadOrCreateDocument(string filePath, string rootElementName)
        {
            // If file exists, load it; otherwise create new document with root element
            if (File.Exists(filePath))
            {
                return XDocument.Load(filePath);
            }
            
            return new XDocument(
                new XElement(rootElementName)
            );
        }

        /// <summary>
        /// Saves an XDocument to the specified file path.
        /// Creates the directory structure if it doesn't exist.
        /// </summary>
        /// <param name="doc">XDocument to save</param>
        /// <param name="filePath">Physical path where to save the document</param>
        private static void SaveDocument(XDocument doc, string filePath)
        {
            // Ensure the directory exists before saving
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            doc.Save(filePath);
        }

        /// <summary>
        /// Retrieves all member user elements from Member.xml.
        /// Returns an empty list if the file doesn't exist or has no users.
        /// </summary>
        /// <returns>List of XElement objects representing all members</returns>
        public static List<XElement> GetAllMembers()
        {
            string filePath = GetMemberFilePath();
            XDocument doc = LoadOrCreateDocument(filePath, "Members");
            // Return all User elements, or empty list if root is null
            return doc.Root?.Elements("User").ToList() ?? new List<XElement>();
        }

        /// <summary>
        /// Retrieves all staff user elements from Staff.xml.
        /// Returns an empty list if the file doesn't exist or has no staff.
        /// </summary>
        /// <returns>List of XElement objects representing all staff</returns>
        public static List<XElement> GetAllStaff()
        {
            string filePath = GetStaffFilePath();
            XDocument doc = LoadOrCreateDocument(filePath, "Staff");
            // Return all User elements, or empty list if root is null
            return doc.Root?.Elements("User").ToList() ?? new List<XElement>();
        }

        public static XElement GetMemberById(string id)
        {
            string filePath = GetMemberFilePath();
            if (!File.Exists(filePath))
                return null;

            XDocument doc = XDocument.Load(filePath);
            return doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);
        }

        public static XElement GetMemberByUsername(string username)
        {
            string filePath = GetMemberFilePath();
            if (!File.Exists(filePath))
                return null;

            XDocument doc = XDocument.Load(filePath);
            return doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Element("Username")?.Value?.Equals(username, StringComparison.OrdinalIgnoreCase) == true);
        }

        public static XElement GetStaffById(string id)
        {
            string filePath = GetStaffFilePath();
            if (!File.Exists(filePath))
                return null;

            XDocument doc = XDocument.Load(filePath);
            return doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);
        }

        public static XElement GetStaffByUsername(string username)
        {
            string filePath = GetStaffFilePath();
            if (!File.Exists(filePath))
                return null;

            XDocument doc = XDocument.Load(filePath);
            return doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Element("Username")?.Value?.Equals(username, StringComparison.OrdinalIgnoreCase) == true);
        }

        public static bool AddMember(string username, string password, string email, string fullName, string role, bool isActive = true)
        {
            if (GetMemberByUsername(username) != null)
                return false;

            string filePath = GetMemberFilePath();
            XDocument doc = LoadOrCreateDocument(filePath, "Members");

            if (doc.Root == null)
            {
                doc = new XDocument(new XElement("Members"));
            }

            int maxId = doc.Root.Elements("User")
                .Select(u => int.TryParse(u.Attribute("id")?.Value, out int id) ? id : 0)
                .DefaultIfEmpty(0)
                .Max();

            XElement newMember = new XElement("User",
                new XAttribute("id", (maxId + 1).ToString()),
                new XElement("Username", username),
                new XElement("Password", password ?? string.Empty),
                new XElement("Email", email ?? string.Empty),
                new XElement("FullName", fullName ?? string.Empty),
                new XElement("Role", role ?? "Member"),
                new XElement("DateCreated", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement("IsActive", isActive.ToString().ToLower())
            );

            doc.Root.Add(newMember);
            SaveDocument(doc, filePath);
            return true;
        }

        public static bool AddStaff(string username, string email, string fullName, string department, string position, bool isActive = true)
        {
            if (GetStaffByUsername(username) != null)
                return false;

            string filePath = GetStaffFilePath();
            XDocument doc = LoadOrCreateDocument(filePath, "Staff");

            if (doc.Root == null)
            {
                doc = new XDocument(new XElement("Staff"));
            }

            int maxId = doc.Root.Elements("User")
                .Select(u => int.TryParse(u.Attribute("id")?.Value, out int id) ? id : 0)
                .DefaultIfEmpty(0)
                .Max();

            XElement newStaff = new XElement("User",
                new XAttribute("id", (maxId + 1).ToString()),
                new XElement("Username", username),
                new XElement("Email", email ?? string.Empty),
                new XElement("FullName", fullName ?? string.Empty),
                new XElement("Department", department ?? string.Empty),
                new XElement("Position", position ?? string.Empty),
                new XElement("DateHired", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement("IsActive", isActive.ToString().ToLower())
            );

            doc.Root.Add(newStaff);
            SaveDocument(doc, filePath);
            return true;
        }

        public static bool UpdateMember(string id, Dictionary<string, string> updates)
        {
            string filePath = GetMemberFilePath();
            if (!File.Exists(filePath))
                return false;

            XDocument doc = XDocument.Load(filePath);
            XElement member = doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);

            if (member == null)
                return false;

            foreach (var update in updates)
            {
                XElement element = member.Element(update.Key);
                if (element != null)
                {
                    element.Value = update.Value;
                }
            }

            SaveDocument(doc, filePath);
            return true;
        }

        public static bool UpdateStaff(string id, Dictionary<string, string> updates)
        {
            string filePath = GetStaffFilePath();
            if (!File.Exists(filePath))
                return false;

            XDocument doc = XDocument.Load(filePath);
            XElement staff = doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);

            if (staff == null)
                return false;

            foreach (var update in updates)
            {
                XElement element = staff.Element(update.Key);
                if (element != null)
                {
                    element.Value = update.Value;
                }
            }

            SaveDocument(doc, filePath);
            return true;
        }

        public static bool DeleteMember(string id)
        {
            string filePath = GetMemberFilePath();
            if (!File.Exists(filePath))
                return false;

            XDocument doc = XDocument.Load(filePath);
            XElement member = doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);

            if (member == null)
                return false;

            member.Remove();
            SaveDocument(doc, filePath);
            return true;
        }

        public static bool DeleteStaff(string id)
        {
            string filePath = GetStaffFilePath();
            if (!File.Exists(filePath))
                return false;

            XDocument doc = XDocument.Load(filePath);
            XElement staff = doc.Root?.Elements("User")
                .FirstOrDefault(u => u.Attribute("id")?.Value == id);

            if (staff == null)
                return false;

            staff.Remove();
            SaveDocument(doc, filePath);
            return true;
        }

        public static bool MemberExists(string username)
        {
            return GetMemberByUsername(username) != null;
        }

        public static bool StaffExists(string username)
        {
            return GetStaffByUsername(username) != null;
        }
    }
}

