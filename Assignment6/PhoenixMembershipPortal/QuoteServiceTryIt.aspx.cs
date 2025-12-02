using System;
using System.Web.UI;
using PhoenixMembershipPortal.Services;

namespace PhoenixMembershipPortal
{
    public partial class QuoteServiceTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Text = "Enter a name (or leave empty) and click 'Get Quote' to test the service.";
                lblResult.CssClass = "alert alert-secondary d-block";
            }
        }

        protected void btnGetQuote_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            try
            {
                QuoteService service = new QuoteService();
                string quote = service.GetQuote(name);

                lblResult.Text = $"<strong>Quote:</strong> {quote}";
                lblResult.CssClass = "alert alert-success d-block";
            }
            catch (Exception ex)
            {
                lblResult.Text = $"<strong>Error:</strong> {ex.Message}";
                lblResult.CssClass = "alert alert-danger d-block";
            }
        }
    }
}

