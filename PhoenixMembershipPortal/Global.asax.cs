using System;

namespace PhoenixMembershipPortal
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Initialize a global counter when the application starts
            Application["Visits"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Increment visit counter every time a new user session begins
            int currentCount = (int)Application["Visits"];
            Application["Visits"] = currentCount + 1;
        }
    }
}
