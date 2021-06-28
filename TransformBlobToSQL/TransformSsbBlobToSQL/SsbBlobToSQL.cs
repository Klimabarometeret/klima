using System;
using System.Linq;
using Microsoft.Azure.Functions.Worker;
using MoreLinq;
using TransformSsbBlobToSQL.Conversion;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL
{
    public static class SsbBlobToSQL
    {
        [Function("SsbBlobToSQL")]
        public static void Run([BlobTrigger("ssbdata/{name}", Connection = "")]
            string ssbBlob, string name,
            FunctionContext context)
        {
            var ssb07849 = Converter.fromCsv(ssbBlob)
                .DistinctBy(CommonRows)
                .Select(Converter.toEntity)
                .ToList();

            Console.WriteLine($"Number of lines after transformation: {ssb07849.Count}");
        }

        private static Object CommonRows(Ssb07849Raw x)
        {
            return new {x.TypeKjøring, x.DrivstoffType, x.År, x.StatistikkVariabel, x.RegistrerteKjøretøy};
        }
    }
}