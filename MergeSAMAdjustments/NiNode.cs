using System.Numerics;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public class NiNode
    {
        public string Name { set; get; }
        public Vector3 Location { set; get; }
        public Quaternion Orientation { set; get; }
        public float Scale { set; get; }

        public NiNode()
        {
            // ctor: initialize node to all zero
            Location = new Vector3(0, 0, 0);
            Orientation = Quaternion.CreateFromYawPitchRoll(0, 0, 0);
            // except scale, which must be one
            Scale = 1;
        }

        public NiNode(Vector3 initialLocation, Quaternion initialOrientation, float initialScale)
        {
            // ctor: initialize node with given parameters
            Location = initialLocation;
            Orientation = initialOrientation;
            Scale = initialScale;
        }

        public NiNode(float x, float y, float z, float yaw, float pitch, float roll, float scaleFactor)
        {
            // ctor: initialize node with given parameters
            Location = new Vector3(x, y, z);
            Orientation = Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll);
            Scale = scaleFactor;
        }

        public void Update(Vector3 distances, Quaternion angles, float scaleFactor)
        {
            // update current orientation
            Orientation *= angles;

            // update current scale
            Scale = (Scale == 0 ? scaleFactor : (Scale * scaleFactor));

            // transform distances with scale factor            
            distances = Vector3.Transform(distances, Matrix4x4.CreateScale(Scale));

            // transform distances with current orientation           
            distances = Vector3.Transform(distances, Matrix4x4.CreateFromQuaternion(Orientation));

            // transform current Location with scaled & rotated distances
            Location = Vector3.Transform(Location, Matrix4x4.CreateTranslation(distances));
        }

        public void Reset()
        {
            // reset this node
            Location = new Vector3(0, 0, 0);
            Orientation = Quaternion.CreateFromYawPitchRoll(0, 0, 0);
            Scale = 1.0f;
        }
    }
}
