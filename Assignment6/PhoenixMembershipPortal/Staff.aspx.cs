using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Staff portal page accessible only to users with "staff" role.
    /// Displays staff profile information and admin functionality including member management.
    /// Allows staff to view all members from Member.xml.
    /// </summary>
    public partial class Staff : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Performs role-based authorization check,
        /// loads staff information from Staff.xml, and displays all members for admin viewing.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Role-based authorization check - only staff can access
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            if (!User.IsInRole("staff"))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                return;
            }

            if (!IsPostBack)
            {
                LoadStaffInfo();
                LoadAllMembers();
            }
        }

        private void LoadStaffInfo()
        {
            string username = User.Identity.Name;

            // Load staff information from Staff.xml
            XElement staff = XMLManager.GetStaffByUsername(username);

            if (staff != null)
            {
                // Display welcome message
                string fullName = staff.Element("FullName")?.Value ?? username;
                lblWelcome.Text = $"Welcome, {fullName}!";

                // Display profile information
                lblUsername.Text = staff.Element("Username")?.Value ?? username;
                lblFullName.Text = staff.Element("FullName")?.Value ?? "N/A";
                lblEmail.Text = staff.Element("Email")?.Value ?? "N/A";
                lblDepartment.Text = staff.Element("Department")?.Value ?? "N/A";
                lblPosition.Text = staff.Element("Position")?.Value ?? "N/A";
                lblDateHired.Text = FormatDate(staff.Element("DateHired")?.Value);

                // Display account status
                string isActive = staff.Element("IsActive")?.Value ?? "false";
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
                // Fallback if staff not found in XML
                lblWelcome.Text = $"Welcome, {username}!";
                lblUsername.Text = username;
                lblFullName.Text = "Information not available";
                lblEmail.Text = "Information not available";
                lblDepartment.Text = "N/A";
                lblPosition.Text = "N/A";
                lblDateHired.Text = "N/A";
                lblStatus.Text = "Active";
                lblStatus.CssClass = "badge bg-success";
                lblLastLogin.Text = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
                lblSessionStart.Text = DateTime.Now.ToString("MMMM dd, yyyy 'at' hh:mm tt");
            }
        }

        /// <summary>
        /// Loads all members from Member.xml and displays them in a GridView.
        /// This is admin functionality allowing staff to view complete member list.
        /// Creates a DataTable with member information and binds it to the GridView.
        /// </summary>
        private void LoadAllMembers()
        {
            // Load all members from Member.xml using XMLManager
            List<XElement> members = XMLManager.GetAllMembers();

            // Create DataTable for GridView
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Role", typeof(string));
            dt.Columns.Add("DateCreated", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("StatusClass", typeof(string));

            // Populate DataTable from XML
            foreach (XElement member in members)
            {
                string id = member.Attribute("id")?.Value ?? "N/A";
                string username = member.Element("Username")?.Value ?? "N/A";
                string fullName = member.Element("FullName")?.Value ?? "N/A";
                string email = member.Element("Email")?.Value ?? "N/A";
                string role = member.Element("Role")?.Value ?? "Member";
                string dateCreated = FormatDate(member.Element("DateCreated")?.Value);
                string isActive = member.Element("IsActive")?.Value ?? "false";
                
                string status = isActive.Equals("true", StringComparison.OrdinalIgnoreCase) ? "Active" : "Inactive";
                string statusClass = isActive.Equals("true", StringComparison.OrdinalIgnoreCase) ? "bg-success" : "bg-danger";

                dt.Rows.Add(id, username, fullName, email, role, dateCreated, status, statusClass);
            }

            // Bind to GridView
            gvMembers.DataSource = dt;
            gvMembers.DataBind();

            // Update member count
            lblMemberCount.Text = members.Count.ToString();
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

        protected void btnRefreshMembers_Click(object sender, EventArgs e)
        {
            LoadAllMembers();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
