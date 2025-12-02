using System;
using System.Web;
using PhoenixSecurity;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Default page for the Phoenix Membership Portal application.
    /// Displays application visit statistics and provides hash testing functionality
    /// to demonstrate both PhoenixSecurity and SimpleSecurityLib DLL integrations.
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Initializes visit counter display from Application state.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int visits = (int)(Application["Visits"] ?? 0);
                int totalVisits = (int)(Application["TotalVisits"] ?? 0);
                lblVisitCount.Text = $"Total Application Visits: <strong>{visits}</strong> | Total Session Visits: <strong>{totalVisits}</strong>";
            }
        }

        /// <summary>
        /// Hash test button click handler. Demonstrates hash computation using both
        /// PhoenixSecurity.dll (HashUtility.ComputeSha256) and SimpleSecurityLib.dll
        /// (SimpleHasher.ComputeHash) with the same input string.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void btnHashTest_Click(object sender, EventArgs e)
        {
            string sample = "Hello123";
            string hashPhoenix = HashUtility.ComputeSha256(sample);
            string hashSimple = SimpleHasher.ComputeHash(sample);

            lblHashResult.Text = $@"
                <div class='alert alert-info'>
                    <h5>Sample Input: <strong>{sample}</strong></h5>
                    <hr />
                    <h6>PhoenixSecurity DLL (HashUtility.ComputeSha256):</h6>
                    <code>{hashPhoenix}</code>
                    <hr />
                    <h6>SimpleSecurityLib DLL (SimpleHasher.ComputeHash):</h6>
                    <code>{hashSimple}</code>
                </div>";
        }
    }
}
