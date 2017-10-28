using System.ServiceModel;
using Campaign.CouponServices.CouponBlock;
using Campaign.CouponServices.CouponCode;
using Campaign.CouponServices.Session;

namespace Campaign.CouponServices
{
    /// <summary>
    /// Use this factory to get the service client and avoid the need for system.serviceModel configuration
    /// </summary>
    internal class ServiceClientFactory
    {
        private readonly string baseApiUrl = "https://api.campaign.episerver.net";

        public SessionWebserviceClient GetSessionClient()
        {
            return new SessionWebserviceClient(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport), 
                new EndpointAddress(baseApiUrl + "/soap11/Session"));
        }

        public CouponBlockWebserviceClient GetCouponBlockWebserviceClient()
        {
            return new CouponBlockWebserviceClient(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport), 
                new EndpointAddress(baseApiUrl + "/soap11/addons/CouponBlock"));
        }

        public CouponCodeWebserviceClient GetCouponCodeWebserviceClient()
        {
            return new CouponCodeWebserviceClient(
                new BasicHttpBinding(BasicHttpSecurityMode.Transport), 
                new EndpointAddress(baseApiUrl + "/soap11/addons/CouponCode"));
        }
    }
}
