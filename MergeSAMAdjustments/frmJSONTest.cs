using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace MergeSAMAdjustments
{
    public partial class frmJSONTest : Form
    {
        public frmJSONTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 4.new\Data\F4SE\Plugins\SAF\Adjustments\SAM-Legs.json";
            string text = File.ReadAllText(filePath);

            List<NiNode> bonesList = new();
            NiNode boneNiNode = new NiNode(); 
            string boneName = string.Empty;
            SAMBoneDescriptor boneDescriptor;
            Vector3 boneLoc = new Vector3();
            Quaternion boneOri = new Quaternion();
            float boneScale = 1;

            // parse SAM json toplevel
            JObject o = JObject.Parse(text);       
            
            // deserialize bones
            foreach (JProperty property in o.Properties())
            {
                boneName = property.Name;
                boneDescriptor = JsonConvert.DeserializeObject<SAMBoneDescriptor>(property.Value.ToString());


                int boneIndex = bonesList.FindIndex(o => o.Name == boneName);
                if (boneIndex < 0)
                {
                    // bone not in NiNode list yet, add new
                    boneNiNode = new NiNode();
                    boneNiNode.Name = boneName;
                    bonesList.Add(boneNiNode);
                }
                else
                {
                    // access bone already NiNode in list
                    boneNiNode = bonesList[boneIndex];
                }

                // transform bone data into usable format (Vector3, Quaternion, Float)
                boneLoc = new Vector3(float.Parse(boneDescriptor.x), float.Parse(boneDescriptor.y), float.Parse(boneDescriptor.z));
                boneOri = Quaternion.CreateFromYawPitchRoll(float.Parse(boneDescriptor.yaw), float.Parse(boneDescriptor.pitch), float.Parse(boneDescriptor.roll));
                boneScale = float.Parse(boneDescriptor.scale);

                // update NiNode with bone data
                boneNiNode.Update(boneLoc, boneOri, boneScale);                
            }

            int i = 1;
        }        
    }
}
