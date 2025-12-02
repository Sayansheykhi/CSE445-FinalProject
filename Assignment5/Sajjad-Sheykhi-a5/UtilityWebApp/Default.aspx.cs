using System;
using System.Data;
using System.Web.UI;
using SimpleSecurityLib;
using WeatherLookupService;

namespace UtilityWebApp
{
    /// <summary>
    /// Code-behind class for the Default.aspx page.
    /// This page serves as the main entry point for the Utility Web Application and provides
    /// access to various utility services including cryptographic hashing and weather lookup.
    /// The page displays a visit counter, service directory, and interactive TryIt sections
    /// for testing the integrated DLL and ASMX web service functionality.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event handler that initializes the page content on first load.
        /// This method populates the visit counter from Application state and builds
        /// the Service Directory data table for display in the GridView.
        /// </summary>
        /// <param name="sender">The source of the event (Page object).</param>
        /// <param name="e">Event arguments containing event data.</param>
        /// <remarks>
        /// The IsPostBack check ensures that initialization code only runs on the initial
        /// page load, not on subsequent postbacks (e.g., when buttons are clicked).
        /// This improves performance and prevents data from being reset on each postback.
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only initialize page content on first load, not on postbacks
            if (!IsPostBack)
            {
                // Retrieve and display the total visit counter from Application state
                // This value is maintained in Global.asax and incremented on each Session_Start
                int visits = (int)Application["TotalVisits"];
                lblVisits.Text = "Total Visits: " + visits.ToString();

                // Build the Service Directory data table
                // This table will be bound to the GridView to display all available services
                DataTable dt = new DataTable();
                
                // Define the three columns for the service directory
                // ServiceName: The name of the service or component
                // ServiceType: The type/category of the service (Event Handler, DLL, Web Service)
                // Description: A brief description of what the service does
                dt.Columns.Add("ServiceName");
                dt.Columns.Add("ServiceType");
                dt.Columns.Add("Description");

                // Add the three required service directory entries
                // Entry 1: Global.asax - Application event handler that tracks visits
                dt.Rows.Add("Global.asax", "Application Event Handler", "Tracks application visits");
                
                // Entry 2: SimpleSecurityLib.dll - Class library providing SHA256 hashing
                dt.Rows.Add("SimpleSecurityLib.dll", "Class Library", "Provides SHA256 hashing functionality");
                
                // Entry 3: Weather Service - ASMX web service for temperature lookup
                dt.Rows.Add("Weather Service", "ASMX Web Service", "Returns temperature for a given zipcode");

                // Bind the data table to the GridView control
                // This populates the Service Directory table on the page
                gvServiceDirectory.DataSource = dt;
                gvServiceDirectory.DataBind();
            }
        }

        /// <summary>
        /// Event handler for the Hash TryIt button click.
        /// This method integrates with the SimpleSecurityLib DLL to compute and display
        /// the SHA-256 hash of user-provided input text.
        /// </summary>
        /// <param name="sender">The source of the event (Button control).</param>
        /// <param name="e">Event arguments containing event data.</param>
        /// <remarks>
        /// This method demonstrates integration with the SimpleSecurityLib class library.
        /// It calls the static ComputeHash method from the SimpleHasher class, which uses
        /// the SHA-256 cryptographic algorithm to generate a one-way hash of the input.
        /// 
        /// Integration Details:
        /// - The SimpleSecurityLib project is referenced as a project reference in UtilityWebApp
        /// - The SimpleHasher.ComputeHash() method is called directly from the DLL
        /// - The result is a 64-character hexadecimal string representing the hash
        /// </remarks>
        protected void btnHash_Click(object sender, EventArgs e)
        {
            // Retrieve user input from the text box
            string input = txtHashInput.Text;
            
            // Validate that input is not empty
            if (!string.IsNullOrEmpty(input))
            {
                // Call the ComputeHash method from SimpleSecurityLib DLL
                // This static method takes the input string and returns a SHA-256 hash
                // as a 64-character hexadecimal string
                string hash = SimpleHasher.ComputeHash(input);
                
                // Display the computed hash in the output label
                lblHashOutput.Text = "Hash: " + hash;
            }
            else
            {
                // Display error message if no input was provided
                lblHashOutput.Text = "Please enter text to hash.";
            }
        }

        /// <summary>
        /// Event handler for the Weather Service TryIt button click.
        /// This method integrates with the WeatherLookupService ASMX web service to
        /// retrieve and display temperature information for a given zipcode.
        /// </summary>
        /// <param name="sender">The source of the event (Button control).</param>
        /// <param name="e">Event arguments containing event data.</param>
        /// <remarks>
        /// This method demonstrates integration with the WeatherLookupService ASMX web service.
        /// It instantiates the WeatherService class and calls the GetTemperature web method,
        /// which returns a temperature value for the specified zipcode.
        /// 
        /// Integration Details:
        /// - The WeatherLookupService project is referenced as a project reference
        /// - The WeatherService class is instantiated directly (works because both are in the same solution)
        /// - The GetTemperature() web method is called, which is decorated with [WebMethod]
        /// - Error handling is implemented to catch any exceptions during service calls
        /// 
        /// Note: In a production environment, this would typically use a web reference or
        /// service reference to consume the ASMX service via SOAP/HTTP, but for this
        /// assignment, direct instantiation works since both projects are in the same solution.
        /// </remarks>
        protected void btnGetTemp_Click(object sender, EventArgs e)
        {
            // Retrieve zipcode input from the text box
            string zipcode = txtZipcode.Text;
            
            // Validate that zipcode is not empty
            if (!string.IsNullOrEmpty(zipcode))
            {
                try
                {
                    // Instantiate the WeatherService from WeatherLookupService
                    // This service is consumed via project reference
                    WeatherService service = new WeatherService();
                    
                    // Call the GetTemperature web method with the user-provided zipcode
                    // This method returns an integer representing the temperature in Fahrenheit
                    int temp = service.GetTemperature(zipcode);
                    
                    // Display the temperature result in the output label
                    lblTempOutput.Text = "Temperature for zipcode " + zipcode + ": " + temp.ToString() + "°F";
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during service call
                    // This could include network errors, service unavailable, or invalid responses
                    lblTempOutput.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                // Display error message if no zipcode was provided
                lblTempOutput.Text = "Please enter a zipcode.";
            }
        }
    }
}

