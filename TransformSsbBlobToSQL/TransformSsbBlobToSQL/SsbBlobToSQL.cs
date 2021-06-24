using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TransformSsbBlobToSQL
{
    public static class SsbBlobToSQL
    {
        [Function("SsbBlobToSQL")]
        public static void Run([BlobTrigger("ssbdata/{name}", Connection = "")] string myBlob, string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("Log from 'SsbBlobToSQL'");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {myBlob}");
        }
    }
}
