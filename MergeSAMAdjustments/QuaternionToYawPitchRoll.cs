using System;
using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class QuaternionToYawPitchRoll
    {
        public static void ExtractYawPitchRoll(this Quaternion r, out float yaw, out float pitch, out float roll)
        {
            // function provided by LEI-Hongfaan at https://github.com/dotnet/runtime/issues/38567

            yaw = MathF.Atan2(2.0f * (r.Y * r.W + r.X * r.Z), 1.0f - 2.0f * (r.X * r.X + r.Y * r.Y));
            pitch = MathF.Asin(2.0f * (r.X * r.W - r.Y * r.Z));
            roll = MathF.Atan2(2.0f * (r.X * r.Y + r.Z * r.W), 1.0f - 2.0f * (r.X * r.X + r.Z * r.Z));
        }
    }
}
