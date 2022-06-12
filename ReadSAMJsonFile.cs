using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

public class ReadSAMJsonFile
{
	public ReadSAMJsonFile()
	{
	}

	public void ReadJson(List<NiNode> ref bonesList, string filePath)
    {
        //string filePath = @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 4.new\Data\F4SE\Plugins\SAF\Adjustments\SAM-Legs.json";


        NiNode boneNiNode = new NiNode();
        string boneName = string.Empty;
        SAMBoneDescriptor boneDescriptor;
        Vector3 boneLoc = new Vector3();
        Quaternion boneOri = new Quaternion();
        float boneScale = 1;

        // read SAM json file into string
        string jsonText = File.ReadAllText(filePath);

        // parse SAM json toplevel from string
        JObject o = JObject.Parse(jsonText);

        // process all bones in json
        foreach (JProperty property in o.Properties())
        {
            // get name from toplevel and deserialize sublevel into SAMBoneDescriptor object
            boneName = property.Name;
            boneDescriptor = JsonConvert.DeserializeObject<SAMBoneDescriptor>(property.Value.ToString());

            // find bone or create new
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

            // update NiNode from SAMBoneDescriptor
            boneDescriptor.UpdateNiNode(boneNiNode);

            // transform bone data from SAMBoneDescriptor into usable format (Vector3, Quaternion, Float)
            //boneLoc = new Vector3(float.Parse(boneDescriptor.x), float.Parse(boneDescriptor.y), float.Parse(boneDescriptor.z));
            //boneOri = Quaternion.CreateFromYawPitchRoll(float.Parse(boneDescriptor.yaw), float.Parse(boneDescriptor.pitch), float.Parse(boneDescriptor.roll));
            //boneScale = float.Parse(boneDescriptor.scale);

            // update NiNode with bone data
            //boneNiNode.Update(boneLoc, boneOri, boneScale);
        }

        int i = 1;
    }
}
}
