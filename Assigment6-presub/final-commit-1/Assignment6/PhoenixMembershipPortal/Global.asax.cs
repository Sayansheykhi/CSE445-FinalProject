using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Global application class handling application and session level events.
    /// Manages visit counters, session initialization, and Forms Authentication role assignment.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Application start event handler. Initializes application-wide variables.
        /// Called once when the application starts.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        void Application_Start(object sender, EventArgs e)
        {
            // Initialize visit counters to zero on application start
            Application["Visits"] = 0;
            Application["TotalVisits"] = 0;
        }

        /// <summary>
        /// Session start event handler. Increments visit counters for each new session.
        /// Uses Application.Lock() and Application.UnLock() for thread-safe access to Application state.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        void Session_Start(object sender, EventArgs e)
        {
            // Lock application state for thread-safe access
            Application.Lock();
            
            // Increment current session visits counter
            int currentVisits = (int)(Application["Visits"] ?? 0);
            Application["Visits"] = currentVisits + 1;
            
            // Increment total visits counter across all sessions
            int currentTotalVisits = (int)(Application["TotalVisits"] ?? 0);
            Application["TotalVisits"] = currentTotalVisits + 1;
            
            // Unlock application state
            Application.UnLock();
        }

        /// <summary>
        /// Application authenticate request event handler.
        /// Decrypts Forms Authentication ticket and assigns roles to the current user principal.
        /// Called on every request to ensure user roles are properly set for authorization.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Get the authentication cookie from the request
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Decrypt the Forms Authentication ticket
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket != null && !ticket.Expired)
                {
                    // Extract role from ticket UserData and assign to current user principal
                    // This enables role-based authorization throughout the application
                    string[] roles = { ticket.UserData };
                    GenericPrincipal principal = new GenericPrincipal(new GenericIdentity(ticket.Name), roles);
                    Context.User = principal;
                }
            }
        }
    }
}
