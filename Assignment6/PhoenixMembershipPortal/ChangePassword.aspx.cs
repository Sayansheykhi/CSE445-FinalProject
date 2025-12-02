using System;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Change Password page for authenticated member users.
    /// Allows members to update their account password by validating the current password
    /// and securely hashing the new password before storing it in Member.xml.
    /// </summary>
    public partial class ChangePassword : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Performs authentication and role-based authorization checks.
        /// Redirects unauthenticated users or non-member users to the login page.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            if (!User.IsInRole("member"))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            if (!IsPostBack)
            {
                lblStatus.Visible = false;
            }
        }

        /// <summary>
        /// Button click handler for changing the user's password.
        /// Validates current password, confirms new password match, hashes the new password,
        /// and updates Member.xml with the new password hash.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;

            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmNewPassword = txtConfirmNewPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword))
            {
                ShowError("Please enter your current password.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ShowError("Please enter a new password.");
                return;
            }

            if (newPassword.Length < 6)
            {
                ShowError("New password must be at least 6 characters long.");
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                ShowError("New password and confirmation do not match.");
                return;
            }

            string username = User.Identity.Name;
            XElement member = XMLManager.GetMemberByUsername(username);

            if (member == null)
            {
                ShowError("User account not found. Please contact support.");
                return;
            }

            string storedPasswordHash = member.Element("Password")?.Value?.Trim() ?? string.Empty;
            string currentPasswordHash = SimpleHasher.ComputeHash(currentPassword);

            if (!storedPasswordHash.Equals(currentPasswordHash, StringComparison.OrdinalIgnoreCase))
            {
                ShowError("Current password is incorrect.");
                return;
            }

            string newPasswordHash = SimpleHasher.ComputeHash(newPassword);
            string memberId = member.Attribute("id")?.Value;

            if (string.IsNullOrWhiteSpace(memberId))
            {
                ShowError("Unable to identify user account. Please contact support.");
                return;
            }

            var updates = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Password", newPasswordHash }
            };

            bool success = XMLManager.UpdateMember(memberId, updates);

            if (success)
            {
                ShowSuccess("Password changed successfully! You can now use your new password to log in.");
                txtCurrentPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtConfirmNewPassword.Text = string.Empty;
            }
            else
            {
                ShowError("Failed to update password. Please try again or contact support.");
            }
        }

        /// <summary>
        /// Displays an error message to the user in the status label.
        /// </summary>
        /// <param name="message">The error message to display</param>
        private void ShowError(string message)
        {
            lblStatus.Text = $"<strong>Error:</strong> {message}";
            lblStatus.CssClass = "alert alert-danger d-block";
            lblStatus.Visible = true;
        }

        /// <summary>
        /// Displays a success message to the user in the status label.
        /// </summary>
        /// <param name="message">The success message to display</param>
        private void ShowSuccess(string message)
        {
            lblStatus.Text = $"<strong>Success:</strong> {message}";
            lblStatus.CssClass = "alert alert-success d-block";
            lblStatus.Visible = true;
        }
    }
}

