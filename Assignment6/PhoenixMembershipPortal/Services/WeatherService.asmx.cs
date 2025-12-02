using System;
using System.Web.Services;

namespace PhoenixMembershipPortal.Services
{
    /// <summary>
    /// ASMX web service for weather-related operations.
    /// Provides temperature information by zipcode for demonstration purposes.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WeatherService : System.Web.Services.WebService
    {
        /// <summary>
        /// Gets the temperature in Fahrenheit for the specified zipcode.
        /// This is a demonstration service that returns a fixed temperature value.
        /// </summary>
        /// <param name="zipcode">The 5-digit zipcode to get temperature for</param>
        /// <returns>Temperature in Fahrenheit (currently returns a fixed value of 72°F)</returns>
        [WebMethod]
        public int GetTemperature(string zipcode)
        {
            return 72;
        }
    }
}

