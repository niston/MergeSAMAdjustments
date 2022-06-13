using System;
using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class NodeToDescriptor
    {
        public static void UpdateDescriptor(this NiNode node, SAMBoneDescriptor descriptor)
        {
            // local copies for conversion
            Vector3 boneLoc = node.Location;
            Quaternion boneOri = node.Orientation;

            // convert coordinate system (System.Numerics -> Game)
            boneLoc.SwapHand();
            boneOri.SwapHand();

            // extract y/p/r
            float mYaw; float mPitch; float mRoll;
            boneOri.ExtractYawPitchRoll(out mYaw, out mPitch, out mRoll);

            // update descriptor properties            
            descriptor.x = Math.Round(boneLoc.X, 6).ToString();
            descriptor.y = Math.Round(boneLoc.Y, 6).ToString();
            descriptor.z = Math.Round(boneLoc.Z, 6).ToString();
            descriptor.yaw = Math.Round(mYaw.ToDegrees(), 2).ToString();
            descriptor.pitch = Math.Round(mPitch.ToDegrees(), 2).ToString();
            descriptor.roll = Math.Round(mRoll.ToDegrees(), 2).ToString();
            descriptor.scale = Math.Round(node.Scale, 6).ToString();
        }
    }
}
