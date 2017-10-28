namespace Campaign.CouponServices.Interfaces
{
    public interface ICampaignCoupons
    {
        bool IsCouponAssigned(string userEmail, long couponBlockId, string couponCode);
        bool IsCouponUsed(long couponBlockId, string couponCode);
        void MarkCouponAsUsed(long couponBlockId, string couponCode);
    }
}