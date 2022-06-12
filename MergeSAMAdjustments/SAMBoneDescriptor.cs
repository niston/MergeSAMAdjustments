using System;
using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public class SAMBoneDescriptor
    { 
        public string pitch { set; get; }
        public string roll { set; get; }
        public string scale { set; get; }
        public string x { set; get; }
        public string y { set; get; }
        public string yaw { set; get; }
        public string z { set; get; }

        public void UpdateNiNode(NiNode niNode)
        {
            // build Vector3/Quaternion/Scale from descriptor data
            Vector3 boneLocation = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));
            Quaternion boneOrientation = Quaternion.CreateFromYawPitchRoll(float.Parse(yaw).ToRadians(), float.Parse(pitch).ToRadians(), float.Parse(roll).ToRadians());
            float boneScale = float.Parse(scale);

            // convert coordinate system (Game -> System.Numerics)
            boneLocation.SwapHand();
            boneOrientation.SwapHand();

            // update NiNode with Vector3/Quaternion/Scale
            niNode.Update(boneLocation, boneOrientation, boneScale);
        }

        public void UpdateDescriptor(NiNode niNode)
        {
            // local copies for conversion
            Vector3 boneLoc = niNode.Location;
            Quaternion boneOri = niNode.Orientation;

            // convert coordinate system (System.Numerics -> Game)
            boneLoc.SwapHand();
            boneOri.SwapHand();

            // extract y/p/r
            float mYaw; float mPitch; float mRoll;
            boneOri.ExtractYawPitchRoll(out mYaw, out mPitch, out mRoll);

            // update descriptor properties            
            x = Math.Round(boneLoc.X, 6).ToString();
            y = Math.Round(boneLoc.Y, 6).ToString();
            z = Math.Round(boneLoc.Z, 6).ToString();
            yaw = Math.Round(mYaw.ToDegrees(), 2).ToString();
            pitch = Math.Round(mPitch.ToDegrees(), 2).ToString();
            roll = Math.Round(mRoll.ToDegrees(), 2).ToString();
            scale = Math.Round(niNode.Scale, 6).ToString();
        }
    }
}
