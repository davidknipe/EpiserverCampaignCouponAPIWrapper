using System.Collections.Generic;
using Campaign.CouponServices.CouponBlock;
using Campaign.CouponServices.Interfaces;
using Campaign.CouponServices.Models;
using EPiServer.ServiceLocation;

namespace Campaign.CouponServices.Impl
{
    [ServiceConfiguration(typeof(ICampaignCouponDefinition))]
    public class CampaignCouponDefinition : ICampaignCouponDefinition
    {
        private readonly ICampaignToken _campaignToken;

        public CampaignCouponDefinition(ICampaignToken campaignToken)
        {
            _campaignToken = campaignToken;
        }

        public IList<CouponDefinition> GetAllCouponDefinitions()
        {
            var clientFactory = new ServiceClientFactory();
            var couponBlockService = clientFactory.GetCouponBlockWebserviceClient();

            var allCoupons = new List<CouponDefinition>();

            allCoupons.AddRange(
                ParseCoupons(couponBlockService, CouponDefinition.CouponSources.Manual));

            allCoupons.AddRange(
                ParseCoupons(couponBlockService, CouponDefinition.CouponSources.Automatic));

            return allCoupons;
        }

        private List<CouponDefinition> ParseCoupons(CouponBlockWebserviceClient couponBlockWebserviceClient, CouponDefinition.CouponSources couponSource)
        {
            var allCoupons = new List<CouponDefinition>();

            var couponSourceString = string.Empty;
            switch (couponSource)
            {
                case CouponDefinition.CouponSources.Manual:
                    couponSourceString = "static";
                    break;

                case CouponDefinition.CouponSources.Automatic:
                    couponSourceString = "generated";
                    break;
            }

            var allCouponIds = couponBlockWebserviceClient.getAllIds(_campaignToken.GetToken(), couponSourceString);
            foreach (var couponId in allCouponIds)
            {
                var couponName = couponBlockWebserviceClient.getName(_campaignToken.GetToken(), couponId);
                allCoupons.Add(new CouponDefinition()
                {
                    CouponSource = couponSource,
                    CouponId = couponId,
                    CouponName = couponName
                });
            }

            return allCoupons;
        }
    }
}
