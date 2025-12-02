using System;
using System.Web.UI;
using PhoenixMembershipPortal.Services;

namespace PhoenixMembershipPortal
{
    public partial class WeatherServiceTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Text = "Enter a zipcode and click 'Get Temperature' to test the service.";
                lblResult.CssClass = "alert alert-secondary d-block";
            }
        }

        protected void btnGetTemperature_Click(object sender, EventArgs e)
        {
            string zipcode = txtZipcode.Text.Trim();

            if (string.IsNullOrWhiteSpace(zipcode))
            {
                lblResult.Text = "<strong>Error:</strong> Please enter a zipcode.";
                lblResult.CssClass = "alert alert-warning d-block";
                return;
            }

            try
            {
                WeatherService service = new WeatherService();
                int temperature = service.GetTemperature(zipcode);

                lblResult.Text = $"<strong>Temperature:</strong> <strong>{temperature}°F</strong> for zipcode <strong>{zipcode}</strong>";
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

