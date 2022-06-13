using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public static class DescriptorToNode
    {
        public static void UpdateNiNode(this SAMBoneDescriptor descriptor, NiNode node)
        {
            // build Vector3/Quaternion/Scale from descriptor data
            Vector3 boneLocation = new Vector3(float.Parse(descriptor.x), float.Parse(descriptor.y), float.Parse(descriptor.z));
            Quaternion boneOrientation = Quaternion.CreateFromYawPitchRoll(float.Parse(descriptor.yaw).ToRadians(),
                                                                           float.Parse(descriptor.pitch).ToRadians(),
                                                                           float.Parse(descriptor.roll).ToRadians());
            float boneScale = float.Parse(descriptor.scale);

            // convert coordinate system (Game -> System.Numerics)
            boneLocation.SwapHand();
            boneOrientation.SwapHand();

            // update NiNode with Vector3/Quaternion/Scale
            node.Update(boneLocation, boneOrientation, boneScale);
        }
    }
}
