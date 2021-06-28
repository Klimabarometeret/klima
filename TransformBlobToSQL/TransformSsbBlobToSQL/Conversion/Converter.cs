using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL.Conversion
{
    class Converter
    {
        public static IEnumerable<Ssb07849Raw> fromCsv(string csvString)
        {
            TextReader stream = new StringReader(csvString);
            var csvReader = new CsvReader(stream, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<Ssb07849Raw>();
        }

        public static Ssb07849 toEntity(Ssb07849Raw data)
        {
            return new Ssb07849(data.Region, data.TypeKjøring, data.DrivstoffType,
                data.År, data.DrivstoffType, data.RegistrerteKjøretøy);
        }
    }
}