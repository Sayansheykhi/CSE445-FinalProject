using System;
using System.Web;
using PhoenixSecurity; // Required to access HashUtility DLL

namespace PhoenixMembershipPortal
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if a cookie exists
                if (Request.Cookies["UserName"] != null)
                {
                    lblCookieStatus.Text = "Welcome back, " + Request.Cookies["UserName"].Value + " 👋";
                    lblCookieStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblCookieStatus.Text = "No stored cookie found.";
                    lblCookieStatus.ForeColor = System.Drawing.Color.Gray;
                }
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            // Create service instance
            MembershipService service = new MembershipService();

            // Get username input
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                lblStatus.Text = "⚠ Please enter a username.";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
                return;
            }

            bool exists = service.CheckUsernameAvailability(username);

            if (exists)
            {
                lblStatus.Text = "❌ Username already exists!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblStatus.Text = "✔ Username is available!";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnSaveCookie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCookieInput.Text))
            {
                lblCookieStatus.Text = "⚠ Please enter a value before saving.";
                lblCookieStatus.ForeColor = System.Drawing.Color.Orange;
                return;
            }

            HttpCookie cookie = new HttpCookie("UserName", txtCookieInput.Text);
            cookie.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(cookie);

            lblCookieStatus.Text = "Cookie saved! Restart the browser to test.";
            lblCookieStatus.ForeColor = System.Drawing.Color.DarkBlue;
        }

        protected void btnHashTest_Click(object sender, EventArgs e)
        {
            string sample = "Hello123";
            string hash = HashUtility.ComputeSha256(sample);

            lblHashResult.Text = $"Sample Input: <b>{sample}</b><br/>SHA256 Hash:<br/><small>{hash}</small>";
            lblHashResult.ForeColor = System.Drawing.Color.Purple;
        }
    }
}
