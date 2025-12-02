using System;
using System.Web.Services;

namespace WeatherLookupService
{
    /// <summary>
    /// ASMX Web Service that provides weather lookup functionality.
    /// This service implements a simple temperature lookup method that accepts a zipcode
    /// and returns a temperature value. Currently returns a hard-coded value for demonstration
    /// purposes, but can be extended to integrate with real weather APIs.
    /// </summary>
    /// <remarks>
    /// This web service follows the WS-I Basic Profile 1.1 specification for interoperability.
    /// The service is decorated with WebService and WebServiceBinding attributes to ensure
    /// proper SOAP message formatting and service description generation.
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WeatherService : System.Web.Services.WebService
    {
        /// <summary>
        /// Retrieves the temperature for a given zipcode.
        /// This method is exposed as a web service operation and can be called via SOAP
        /// or HTTP GET/POST requests.
        /// </summary>
        /// <param name="zipcode">
        /// A string representing the 5-digit US zipcode for which to retrieve temperature.
        /// Example: "85001" for Phoenix, Arizona.
        /// </param>
        /// <returns>
        /// An integer representing the temperature in Fahrenheit.
        /// Currently returns a hard-coded value of 72°F for all zipcodes.
        /// </returns>
        /// <remarks>
        /// This is a demonstration method that returns a dummy temperature value.
        /// In a production environment, this method would:
        /// 1. Validate the zipcode format
        /// 2. Query a weather API (e.g., OpenWeatherMap, Weather.gov)
        /// 3. Parse the API response
        /// 4. Return the actual temperature for the specified location
        /// 
        /// The WebMethod attribute makes this method accessible as a SOAP web service operation.
        /// </remarks>
        [WebMethod]
        public int GetTemperature(string zipcode)
        {
            // Return hard-coded temperature value for demonstration purposes
            // In a production implementation, this would query a weather API
            // based on the provided zipcode and return the actual temperature
            return 72;
        }
    }
}

