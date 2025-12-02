using System;
using System.Web.UI;

namespace PhoenixMembershipPortal
{
    public partial class MembershipServiceTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Text = "Enter a username and click 'Check Availability' to test the service.";
                lblResult.CssClass = "alert alert-secondary d-block";
            }
        }

        protected void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                lblResult.Text = "<strong>Error:</strong> Please enter a username.";
                lblResult.CssClass = "alert alert-warning d-block";
                return;
            }

            try
            {
                MembershipService service = new MembershipService();
                bool isAvailable = service.CheckUsernameAvailability(username);

                if (isAvailable)
                {
                    lblResult.Text = $"<strong>Result:</strong> Username '<strong>{username}</strong>' is <strong>NOT available</strong> (already exists).";
                    lblResult.CssClass = "alert alert-danger d-block";
                }
                else
                {
                    lblResult.Text = $"<strong>Result:</strong> Username '<strong>{username}</strong>' is <strong>available</strong> (does not exist).";
                    lblResult.CssClass = "alert alert-success d-block";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"<strong>Error:</strong> {ex.Message}";
                lblResult.CssClass = "alert alert-danger d-block";
            }
        }
    }
}

