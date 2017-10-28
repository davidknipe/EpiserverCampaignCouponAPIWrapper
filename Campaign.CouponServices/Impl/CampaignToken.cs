using System;
using Campaign.CouponServices.Interfaces;
using EPiServer.ServiceLocation;

namespace Campaign.CouponServices.Impl
{
    [ServiceConfiguration(typeof(ICampaignToken), Lifecycle = ServiceInstanceScope.Singleton)]
    public class CampaignToken : ICampaignToken
    {
        private readonly ICampaignSettings _campaignSettings;

        private DateTime _tokenDateTime;
        private string _cachedToken;

        public CampaignToken(ICampaignSettings campaignSettings)
        {
            _campaignSettings = campaignSettings;
            _tokenDateTime = DateTime.MinValue;
        }

        public string GetToken()
        {
            //Tokens are valid for 20 mins
            if (_tokenDateTime < DateTime.Now.AddMinutes(-20).AddSeconds(-10))
            {
                var clientFactory = new ServiceClientFactory();
                var session = clientFactory.GetSessionClient();
                var connectionDetails = _campaignSettings.GetConnectionDetails();
                _cachedToken = session.login(connectionDetails.ClientId, connectionDetails.Username, connectionDetails.Password);
                _tokenDateTime = DateTime.Now;
            }
            return _cachedToken;
        }
    }
}