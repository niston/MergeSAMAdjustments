using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public class ParseSAMJson
    {
        public void Parse(List<NiNode> bonesList, string jsonFilePath)
        {
            // local vars
            NiNode boneNiNode = new NiNode();
            string boneName = string.Empty;
            SAMBoneDescriptor boneDescriptor = new SAMBoneDescriptor();

            // read SAM json file into string
            string jsonText = File.ReadAllText(jsonFilePath);

            // parse SAM json toplevel from string
            JObject o = JObject.Parse(jsonText);

            // process all bones in json
            foreach (JProperty property in o.Properties())
            {
                // get name from toplevel and deserialize sublevel into SAMBoneDescriptor object
                boneName = property.Name;
                boneDescriptor = JsonConvert.DeserializeObject<SAMBoneDescriptor>(property.Value.ToString());

                // find bone in list or add new?
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
                    // access bone already in list
                    boneNiNode = bonesList[boneIndex];
                }

                // update NiNode from SAMBoneDescriptor
                boneDescriptor.UpdateNiNode(boneNiNode);
            }
        }
    }
}
