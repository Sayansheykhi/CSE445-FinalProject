using System;
using System.Web;

namespace UtilityDemoWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //initialize total visit counter
            Application["TotalVisits"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            //increment total visits when new session starts
            Application.Lock();
            int current = (int)(Application["TotalVisits"] ?? 0);
            Application["TotalVisits"] = current + 1;
            Application.UnLock();
        }
    }
}
