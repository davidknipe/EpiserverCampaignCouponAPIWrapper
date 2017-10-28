using System.Configuration;
using Campaign.CouponServices.Interfaces;
using Campaign.Services.Models;
using EPiServer.ServiceLocation;

namespace Campaign.CouponServices.Impl
{
    [ServiceConfiguration(typeof(ICampaignSettings))]
    public class CampaignSettings : ICampaignSettings
    {
        public CampaignConnectionDetails GetConnectionDetails()
        {
            return new CampaignConnectionDetails()
            {
                Username = ConfigurationManager.AppSettings["episerver:campaign.Username"],
                Password = ConfigurationManager.AppSettings["episerver:campaign.Password"],
                ClientId = long.Parse(ConfigurationManager.AppSettings["episerver:campaign.ClientId"])
            };
        }
    }
}
