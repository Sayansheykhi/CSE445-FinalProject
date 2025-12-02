using System;
using System.Web.UI;
using PhoenixMembershipPortal.Services;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// TryIt page for testing the QuoteService WCF service.
    /// Allows users to test the GetQuote operation by entering a name
    /// and receiving a personalized quote message.
    /// </summary>
    public partial class QuoteServiceTryIt : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler. Initializes the TryIt page with default instructions.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Text = "Enter a name (or leave empty) and click 'Get Quote' to test the service.";
                lblResult.CssClass = "alert alert-secondary d-block";
            }
        }

        /// <summary>
        /// Button click handler for getting a personalized quote.
        /// Calls QuoteService.GetQuote and displays the returned quote message.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
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

