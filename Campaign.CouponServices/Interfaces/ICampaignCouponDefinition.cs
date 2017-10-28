using System.Collections.Generic;
using Campaign.CouponServices.Models;

namespace Campaign.CouponServices.Interfaces
{
    public interface ICampaignCouponDefinition
    {
        IList<CouponDefinition> GetAllCouponDefinitions();
    }
}