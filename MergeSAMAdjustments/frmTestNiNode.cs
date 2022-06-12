using System;
using System.Numerics;
using System.Windows.Forms;

namespace MergeSAMAdjustments
{
    public partial class frmTestNiNode : Form
    {

        private NiNode testNode;

        public frmTestNiNode()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            testNode = new NiNode();
            ResetInput();
            UpdateCurrentDisplay();
        }

        private void UpdateCurrentDisplay()
        {
            // convert coord system to game
            Vector3 myLocation = testNode.Location;
            Quaternion myOrientation = testNode.Orientation;                        
            myLocation.SwapHand();
            myOrientation.SwapHand();

            // location
            txtCurX.Text = Math.Round(myLocation.X, 4).ToString();
            txtCurY.Text = Math.Round(myLocation.Y, 4).ToString();
            txtCurZ.Text = Math.Round(myLocation.Z, 4).ToString();

            // orientation
            float yaw;
            float pitch;
            float roll;
            myOrientation.ExtractYawPitchRoll(out yaw, out pitch, out roll);
            txtCurYaw.Text = Math.Round(yaw.ToDegrees(), 4).ToString();
            txtCurPitch.Text = Math.Round(pitch.ToDegrees(), 4).ToString();
            txtCurRoll.Text = Math.Round(roll.ToDegrees(), 4).ToString();

            // scale
            txtCurScale.Text = Math.Round(testNode.Scale, 4).ToString();
        }

        private void ResetInput()
        {
            txtUpdX.Text = "0";
            txtUpdY.Text = "0";
            txtUpdZ.Text = "0";
            txtUpdYaw.Text = "0";
            txtUpdPitch.Text = "0";
            txtUpdRoll.Text = "0";
            txtUpdScale.Text = "1";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Vector3 updVector = new Vector3(float.Parse(txtUpdX.Text), float.Parse(txtUpdY.Text), float.Parse(txtUpdZ.Text));
                Quaternion updQuat = Quaternion.CreateFromYawPitchRoll(float.Parse(txtUpdYaw.Text).ToRadians(), float.Parse(txtUpdPitch.Text).ToRadians(), float.Parse(txtUpdRoll.Text).ToRadians());
                float updScale = float.Parse(txtUpdScale.Text);

                // convert coord system from game
                updVector.SwapHand();
                updQuat.SwapHand();


                testNode.Update(updVector, updQuat, updScale);                

                UpdateCurrentDisplay();
            }
            catch
            {
                MessageBox.Show("Failed to parse inputs!");

                ResetInput();
            }

            return;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
            testNode.Reset();
            UpdateCurrentDisplay();
        }
    }
}
