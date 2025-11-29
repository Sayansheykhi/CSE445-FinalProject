using System;
using System.Web;
using System.Web.UI;

namespace UtilityDemoWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Show total visits from Global.asax
                object visits = Application["TotalVisits"];
                lblTotalVisits.Text = "Total visits (sessions) so far: " + (visits ?? 0).ToString();

                // Optional: read name from cookie and pre-fill txtName
                HttpCookie nameCookie = Request.Cookies["UserName"];
                if (nameCookie != null && !string.IsNullOrEmpty(nameCookie.Value))
                {
                    txtName.Text = nameCookie.Value;
                }
            }
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtToHash.Text;
            string hashed = PasswordHasher.HashPassword(input);
            lblHashResult.Text = "Hash: " + hashed;
        }

        protected void btnGetQuote_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            // Optional: store name in cookie
            HttpCookie cookie = new HttpCookie("UserName", name);
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);

            // Endpoint URL of your service on WebStrar (update page id)
            string endpointUrl = "http://webstrar143.fulton.asu.edu/page0/QuoteService.svc";

            var proxy = new QuoteServiceProxy(endpointUrl);
            string quote = proxy.GetQuote(name);
            lblQuoteResult.Text = quote;
        }
    }
}
