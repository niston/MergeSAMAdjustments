using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class CoordSystemConvert
    {
        public static void SwapHand(this Vector3 input)
        {
            // swap
            float tmp = input.Y;
            input.Y = input.Z;
            input.Z = tmp;
        }

        public static void SwapHand(this ref Quaternion input)
        {
            float yaw; float pitch; float roll;
            input.ExtractYawPitchRoll(out yaw, out pitch, out roll);

            // swap
            float tmp = yaw;
            yaw = roll;
            roll = tmp;

            input = Quaternion.CreateFromYawPitchRoll(-yaw, pitch, -roll);            
        }
    }
}
