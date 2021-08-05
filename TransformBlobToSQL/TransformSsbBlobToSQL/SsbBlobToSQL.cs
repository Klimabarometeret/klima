using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using MoreLinq;
using Serilog;
using TransformSsbBlobToSQL.Conversion;
using TransformSsbBlobToSQL.Data;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL
{
    public class SsbBlobToSQL
    {
        private readonly SsbContext _context;
        private readonly ILogger _logger;

        public SsbBlobToSQL(SsbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
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
            _logger.Warning($"Number of lines after transformation: {ssb07849.Count}");
            Console.WriteLine($"Number of lines after transformation: {ssb07849.Count}");

            await _context.AddRangeAsync(ssb07849);
            await _context.SaveChangesAsync();
            
            var allData = await _context.FindAsync<List<Ssb07849>>();
            
            Console.WriteLine($"Number of objects from DB: {allData.Count}");
        }

        private static object CommonRows(Ssb07849Raw x)
        {
            return new {x.TypeKj�ring, x.DrivstoffType, x.�r, x.StatistikkVariabel, x.RegistrerteKj�ret�y};
        }
    }
}