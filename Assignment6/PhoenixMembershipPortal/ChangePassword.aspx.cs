using System;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    public partial class ChangePassword : System.Web.UI.Page
    {
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

        private void ShowError(string message)
        {
            lblStatus.Text = $"<strong>Error:</strong> {message}";
            lblStatus.CssClass = "alert alert-danger d-block";
            lblStatus.Visible = true;
        }

        private void ShowSuccess(string message)
        {
            lblStatus.Text = $"<strong>Success:</strong> {message}";
            lblStatus.CssClass = "alert alert-success d-block";
            lblStatus.Visible = true;
        }
    }
}

