﻿namespace Campaign.CouponServices.Models
{
    public class CouponDefinition
    {
        public enum CouponSources
        {
            Manual,
            Automatic
        }

        public long CouponId { get; set; }
        public string CouponName { get; set; }

        public CouponSources CouponSource { get; set; }
    }
}
