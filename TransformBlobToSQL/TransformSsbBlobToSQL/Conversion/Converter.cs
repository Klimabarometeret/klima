using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static Ssb07849 toEntity(Ssb07849Raw kjøringFraCsv)
        {
            return new Ssb07849(kjøringFraCsv.Region, kjøringFraCsv.TypeKjøring, kjøringFraCsv.DrivstoffType,
                kjøringFraCsv.År, kjøringFraCsv.DrivstoffType, kjøringFraCsv.RegistrerteKjøretøy);
        }
    }
}