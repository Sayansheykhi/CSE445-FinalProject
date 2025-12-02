using System;
using System.Web;

namespace UtilityWebApp
{
    /// <summary>
    /// Global application class that handles application-level and session-level events.
    /// This class manages the application lifecycle and tracks visitor statistics using
    /// the ASP.NET Application state dictionary. The visit counter is incremented each
    /// time a new user session begins.
    /// </summary>
    /// <remarks>
    /// The Global.asax file inherits from this class and handles HTTP application events.
    /// Application state is shared across all sessions and persists for the lifetime
    /// of the application (until the web server is restarted or the application pool
    /// is recycled).
    /// </remarks>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Event handler that fires once when the web application starts.
        /// This method initializes application-wide variables and resources.
        /// It is called before any HTTP requests are processed.
        /// </summary>
        /// <param name="sender">The source of the event (HttpApplication instance).</param>
        /// <param name="e">Event arguments (empty for Application_Start).</param>
        /// <remarks>
        /// This method initializes the TotalVisits counter to zero when the application
        /// first starts. The counter will persist in Application state until the application
        /// is restarted. This is the ideal place to initialize shared resources, connection
        /// strings, or application-wide configuration settings.
        /// </remarks>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Initialize the visit counter in Application state
            // Application state is shared across all user sessions
            // This value persists until the application is restarted
            Application["TotalVisits"] = 0;
        }

        /// <summary>
        /// Event handler that fires each time a new user session begins.
        /// This method increments the total visit counter, tracking how many unique
        /// sessions have accessed the application since it started.
        /// </summary>
        /// <param name="sender">The source of the event (HttpApplication instance).</param>
        /// <param name="e">Event arguments (empty for Session_Start).</param>
        /// <remarks>
        /// This method uses Application.Lock() and Application.UnLock() to ensure thread-safe
        /// access to the shared Application state. This is critical because multiple users
        /// may start sessions simultaneously, and we need to prevent race conditions when
        /// incrementing the counter.
        /// 
        /// Thread Safety:
        /// - Application.Lock() prevents other threads from modifying Application state
        /// - The counter is incremented atomically
        /// - Application.UnLock() releases the lock so other threads can proceed
        /// 
        /// Note: Each new browser session triggers this event, so the counter represents
        /// the total number of user sessions, not necessarily unique visitors (a user could
        /// start multiple sessions by clearing cookies or using different browsers).
        /// </remarks>
        protected void Session_Start(object sender, EventArgs e)
        {
            // Lock Application state to ensure thread-safe access
            // This prevents race conditions when multiple sessions start simultaneously
            Application.Lock();
            
            // Increment the total visit counter
            // Cast to int, increment, and store back to Application state
            Application["TotalVisits"] = (int)Application["TotalVisits"] + 1;
            
            // Unlock Application state to allow other threads to access it
            Application.UnLock();
        }
    }
}

