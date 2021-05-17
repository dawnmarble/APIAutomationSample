using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using File = System.IO.File;

namespace APIAutomationSample.Helpers
{
    class FileUtility
    {
        public static dynamic SetPayloadBody(string fileName)
        {
            string fileLocation = GetPayloadFile("\\" + fileName);
            dynamic testPayload = ReadJsonFile(fileLocation);

            return testPayload;
        }

        public static string GetPayloadFile(string payloadFile)
        {
            var payloadFileName = payloadFile;

            string fullFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                              + "\\Payloads\\" + payloadFileName;
            return fullFilePath;
        }

        public static dynamic ReadJsonFile(string filePath)
        {
            dynamic jsonFile = JObject.Parse(File.ReadAllText(filePath)).ToString();
            return jsonFile;
        }


    }


}
