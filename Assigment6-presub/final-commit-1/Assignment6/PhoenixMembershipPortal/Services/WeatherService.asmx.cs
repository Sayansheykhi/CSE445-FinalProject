using System;
using System.Web.Services;

namespace PhoenixMembershipPortal.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WeatherService : System.Web.Services.WebService
    {
        [WebMethod]
        public int GetTemperature(string zipcode)
        {
            return 72;
        }
    }
}

