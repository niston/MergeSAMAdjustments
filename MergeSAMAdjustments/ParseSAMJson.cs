﻿using Newtonsoft.Json;
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
            JObject toplevelObject = JObject.Parse(jsonText);

            // process all bones in json
            foreach (JProperty property in toplevelObject.Properties())
            {
                // get name from toplevel and deserialize sublevel into SAMBoneDescriptor object
                if (property.Name == "name") { continue; }
                if (property.Name == "version") { continue; }
                if (property.Name == "transforms")
                {
                    JObject transformObjects = JObject.Parse(property.Value.ToString());
                    foreach (JProperty transform in transformObjects.Properties())
                    {
                        boneName = transform.Name;
                        boneDescriptor = JsonConvert.DeserializeObject<SAMBoneDescriptor>(transform.Value.ToString());

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
    }
}
