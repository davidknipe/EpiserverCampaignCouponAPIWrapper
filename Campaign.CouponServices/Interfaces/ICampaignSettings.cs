using Campaign.Services.Models;

namespace Campaign.CouponServices.Interfaces
{
    public interface ICampaignSettings
    {
        CampaignConnectionDetails GetConnectionDetails();
    }
}