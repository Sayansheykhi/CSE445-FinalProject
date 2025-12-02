using System;
using System.Web;
using PhoenixSecurity;
using SimpleSecurityLib;

namespace PhoenixMembershipPortal
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int visits = (int)(Application["Visits"] ?? 0);
                int totalVisits = (int)(Application["TotalVisits"] ?? 0);
                lblVisitCount.Text = $"Total Application Visits: <strong>{visits}</strong> | Total Session Visits: <strong>{totalVisits}</strong>";
            }
        }

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
