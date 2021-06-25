using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TransformSsbBlobToSQL.Conversion;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL
{
    public static class SsbBlobToSQL
    {
        [Function("SsbBlobToSQL")]
        public static void Run([BlobTrigger("ssbdata/{name}", Connection = "")] string ssbBlob, string name,
            FunctionContext context)
        {
            var csvConverter = new ConvertFromCsv();
            var data = csvConverter.toSsbKjøringList(ssbBlob);

            // Midlertidlig utskrift for å vise at konvertering er vellykket
            foreach (var ssbKjøring in data.Take(5))
            {
                Console.WriteLine(ssbKjøring);
            }
        }
    }
}
