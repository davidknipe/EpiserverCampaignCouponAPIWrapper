using Campaign.CouponServices.Interfaces;
using EPiServer.ServiceLocation;

namespace Campaign.CouponServices.Impl
{
    [ServiceConfiguration(typeof(ICampaignCoupons))]
    public class CampaignCoupons : ICampaignCoupons
    {
        private readonly ICampaignToken _campaignToken;

        public CampaignCoupons(ICampaignToken campaignToken)
        {
            _campaignToken = campaignToken;
        }

        public bool IsCouponAssigned(string userEmail, long couponBlockId, string couponCode)
        {
            var clientFactory = new ServiceClientFactory();
            var couponClient = clientFactory.GetCouponCodeWebserviceClient();

            var assignedRecipientId = couponClient.getAssignedRecipientId(_campaignToken.GetToken(), couponBlockId, couponCode);
            return userEmail == assignedRecipientId;
        }

        public bool IsCouponUsed(long couponBlockId, string couponCode)
        {
            var clientFactory = new ServiceClientFactory();
            var couponClient = clientFactory.GetCouponCodeWebserviceClient();

            return couponClient.isUsed(_campaignToken.GetToken(), couponBlockId, couponCode);
        }

        public void MarkCouponAsUsed(long couponBlockId, string couponCode)
        {
            var clientFactory = new ServiceClientFactory();
            var couponClient = clientFactory.GetCouponCodeWebserviceClient();

            couponClient.markAsUsed(_campaignToken.GetToken(), couponBlockId, couponCode);
        }
    }
}