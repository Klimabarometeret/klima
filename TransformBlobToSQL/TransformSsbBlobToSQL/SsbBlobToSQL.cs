using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using MoreLinq;
using TransformSsbBlobToSQL.Conversion;
using TransformSsbBlobToSQL.Data;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL
{
    public class SsbBlobToSQL
    {
        private readonly SsbContext _context;

        public SsbBlobToSQL(SsbContext context)
        {
            _context = context;
        }

        [Function("SsbBlobToSQL")]
        public async Task Run([BlobTrigger("ssbdata/{name}", Connection = "")]
            string ssbBlob, string name,
            FunctionContext context)
        {
            var ssb07849 = Converter.fromCsv(ssbBlob)
                .DistinctBy(CommonRows)
                .Select(Converter.toEntity)
                .ToList();

            Console.WriteLine($"Number of lines after transformation: {ssb07849.Count}");

            // await _context.AddRangeAsync(ssb07849);
            // await _context.SaveChangesAsync();
            //
            // var allData = await _context.FindAsync<List<Ssb07849>>();
            //
            // Console.WriteLine($"Number of objects from DB: {allData.Count}");
        }

        private static object CommonRows(Ssb07849Raw x)
        {
            return new {x.TypeKjøring, x.DrivstoffType, x.År, x.StatistikkVariabel, x.RegistrerteKjøretøy};
        }
    }
}