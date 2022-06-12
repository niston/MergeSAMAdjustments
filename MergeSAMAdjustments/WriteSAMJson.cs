using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

// SAM Adjustment Merge Tool by niston

namespace MergeSAMAdjustments
{
    public class WriteSAMJson
    {
        public void Write(List<NiNode> bonesList, string outputFile)
        {
            StringBuilder json = new StringBuilder();
            json.AppendLine("{");

            int c = 0;
            foreach (NiNode bone in bonesList)
            {
                // increase bone counter
                c += 1;

                // write bone name
                json.Append("\"");
                json.Append(bone.Name);
                json.Append("\" : ");

                // write bone settings
                SAMBoneDescriptor boneDesc = new SAMBoneDescriptor();
                boneDesc.UpdateDescriptor(bone);
                json.Append(JsonConvert.SerializeObject(boneDesc));

                // append comma if not last bone
                json.AppendLine((c < bonesList.Count) ? "," : string.Empty);
            }

            json.AppendLine("}");

            // write json to output file
            File.WriteAllText(outputFile, json.ToString());
        }
    }
}
