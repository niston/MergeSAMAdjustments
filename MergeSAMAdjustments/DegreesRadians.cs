using System;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class DegreesRadians
    {
        public static float ToRadians(this float degrees)
        {
            return ((float)(Math.PI) / 180) * degrees;
        }

        public static float ToDegrees(this float radians)
        {
            return (180f / (float)(Math.PI) * radians);
        }
    }
}
