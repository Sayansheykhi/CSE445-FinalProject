using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// Configuration class for URL routing and friendly URLs.
    /// Enables clean, SEO-friendly URLs throughout the application.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers friendly URL routes for the application.
        /// Configures automatic permanent redirects for clean URL generation.
        /// </summary>
        /// <param name="routes">The route collection to register routes with</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
