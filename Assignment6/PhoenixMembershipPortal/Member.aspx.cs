using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Xml.Linq;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Member portal page accessible only to users with "member" role.
    /// Displays member profile information loaded from Member.xml.
    /// Shows member-specific tools and account activity.
    /// </summary>
    public partial class Member : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Performs role-based authorization check
        /// and loads member information from Member.xml if authorized.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Role-based authorization check - only members can access
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
                LoadMemberInfo();
            }
        }

        /// <summary>
        /// Loads member information from Member.xml and displays it on the page.
        /// Retrieves user data based on authenticated username and populates all profile fields.
        /// </summary>
        private void LoadMemberInfo()
        {
            // Get authenticated username from Forms Authentication
            string username = User.Identity.Name;

            // Load member information from Member.xml using XMLManager
            XElement member = XMLManager.GetMemberByUsername(username);

            if (member != null)
            {
                // Display welcome message
                string fullName = member.Element("FullName")?.Value ?? username;
                lblWelcome.Text = $"Welcome, {fullName}!";

                // Display profile information
                lblUsername.Text = member.Element("Username")?.Value ?? username;
                lblFullName.Text = member.Element("FullName")?.Value ?? "N/A";
                lblEmail.Text = member.Element("Email")?.Value ?? "N/A";
                lblRole.Text = member.Element("Role")?.Value ?? "Member";
                lblDateCreated.Text = FormatDate(member.Element("DateCreated")?.Value);
                
                // Display account status
                string isActive = member.Element("IsActive")?.Value ?? "false";
                if (isActive.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    lblStatus.Text = "Active";
                    lblStatus.CssClass = "badge bg-success";
                }
                else
                {
                    lblStatus.Text = "Inactive";
                    lblStatus.CssClass = "badge bg-danger";
                }

                // Display session information
                lblLastLogin.Text = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
                lblSessionStart.Text = Session["SessionStartTime"]?.ToString() ?? DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
                
                // Store session start time if not already set
                if (Session["SessionStartTime"] == null)
                {
                    Session["SessionStartTime"] = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
                }
            }
            else
            {
                // Fallback if member not found in XML
                lblWelcome.Text = $"Welcome, {username}!";
                lblUsername.Text = username;
                lblFullName.Text = "Information not available";
                lblEmail.Text = "Information not available";
                lblRole.Text = "Member";
                lblDateCreated.Text = "N/A";
                lblStatus.Text = "Active";
                lblStatus.CssClass = "badge bg-success";
                lblLastLogin.Text = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
                lblSessionStart.Text = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
            }
        }

        private string FormatDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return "N/A";

            if (DateTime.TryParse(dateString, out DateTime date))
            {
                return date.ToString("MMMM dd, yyyy");
            }

            return dateString;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
