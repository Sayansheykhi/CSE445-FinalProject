using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Login page for user authentication.
    /// Handles Forms Authentication with role-based access control.
    /// Validates credentials against Member.xml and Staff.xml files.
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Redirects authenticated users to their appropriate portal
        /// based on their role (member or staff).
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("member"))
                {
                    Response.Redirect("~/Member.aspx");
                }
                else if (User.IsInRole("staff"))
                {
                    Response.Redirect("~/Staff.aspx");
                }
            }
        }

        /// <summary>
        /// Handles login button click event.
        /// Validates user credentials, creates authentication ticket, and redirects based on role.
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get and trim user input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validate that both fields are filled
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter both username and password.");
                return;
            }

            // Validate credentials and get user role
            string role = ValidateCredentials(username, password);

            if (!string.IsNullOrEmpty(role))
            {
                // Create Forms Authentication ticket with role
                CreateAuthenticationTicket(username, role);
                // Redirect to appropriate portal based on role
                RedirectByRole(role);
            }
            else
            {
                ShowError("Invalid username or password.");
            }
        }

        /// <summary>
        /// Validates username and password against Member.xml and Staff.xml files.
        /// Hashes the provided password and compares it with stored hash.
        /// Returns the user's role ("member" or "staff") if credentials are valid.
        /// </summary>
        /// <param name="username">Username to validate</param>
        /// <param name="password">Plain text password to validate</param>
        /// <returns>User role ("member" or "staff") if valid, null otherwise</returns>
        private string ValidateCredentials(string username, string password)
        {
            // Hash the provided password using SimpleSecurityLib DLL
            string hashedPassword = SimpleHasher.ComputeHash(password);

            // Check Member.xml first
            XElement member = XMLManager.GetMemberByUsername(username);
            if (ValidateUser(member, hashedPassword))
            {
                return "member";
            }

            // If not found in Member.xml, check Staff.xml
            XElement staff = XMLManager.GetStaffByUsername(username);
            if (ValidateUser(staff, hashedPassword))
            {
                return "staff";
            }

            // Credentials invalid
            return null;
        }

        /// <summary>
        /// Validates a user XElement against the provided hashed password.
        /// Checks if user exists, is active, and password hash matches.
        /// </summary>
        /// <param name="user">XElement representing the user from XML</param>
        /// <param name="hashedPassword">Hashed password to compare</param>
        /// <returns>True if user is valid and active with matching password</returns>
        private bool ValidateUser(XElement user, string hashedPassword)
        {
            // Return false if user element is null
            if (user == null)
                return false;

            // Extract password hash and active status from XML
            string storedHash = user.Element("Password")?.Value?.Trim() ?? string.Empty;
            string isActive = user.Element("IsActive")?.Value?.Trim() ?? "false";

            // Validate: user must be active and password hash must match
            return isActive.Equals("true", StringComparison.OrdinalIgnoreCase) && 
                   storedHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates a Forms Authentication ticket with the username and role.
        /// Encrypts the ticket and stores it in a cookie for session management.
        /// </summary>
        /// <param name="username">Authenticated username</param>
        /// <param name="role">User role ("member" or "staff")</param>
        private void CreateAuthenticationTicket(string username, string role)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                username,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                role,
                FormsAuthentication.FormsCookiePath
            );

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            Response.Cookies.Add(cookie);
        }

        private void RedirectByRole(string role)
        {
            if (role == "member")
            {
                Response.Redirect("~/Member.aspx");
            }
            else if (role == "staff")
            {
                Response.Redirect("~/Staff.aspx");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}

