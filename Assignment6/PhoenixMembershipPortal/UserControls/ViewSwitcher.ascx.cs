using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace PhoenixMembershipPortal
{
    /// <summary>
    /// User control for switching between mobile and desktop views.
    /// Detects the current view mode and provides a link to switch to the alternate view.
    /// </summary>
    public partial class ViewSwitcher : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets the current view mode (Mobile or Desktop).
        /// </summary>
        protected string CurrentView { get; private set; }

        /// <summary>
        /// Gets the alternate view mode (Desktop or Mobile).
        /// </summary>
        protected string AlternateView { get; private set; }

        /// <summary>
        /// Gets the URL to switch to the alternate view.
        /// </summary>
        protected string SwitchUrl { get; private set; }

        /// <summary>
        /// Page load event handler. Detects current view mode and generates switch URL.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var isMobile = WebFormsFriendlyUrlResolver.IsMobileView(new HttpContextWrapper(Context));
            CurrentView = isMobile ? "Mobile" : "Desktop";

            AlternateView = isMobile ? "Desktop" : "Mobile";

            var switchViewRouteName = "AspNet.FriendlyUrls.SwitchView";
            var switchViewRoute = RouteTable.Routes[switchViewRouteName];
            if (switchViewRoute == null)
            {
                this.Visible = false;
                return;
            }
            var url = GetRouteUrl(switchViewRouteName, new { view = AlternateView, __FriendlyUrls_SwitchViews = true });
            url += "?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl);
            SwitchUrl = url;
        }
    }
}

