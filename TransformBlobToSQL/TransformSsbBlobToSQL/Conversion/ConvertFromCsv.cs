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
    class ConvertFromCsv
    {
        public IEnumerable<SsbKjøring> toSsbKjøringList(string csvString)
        {
            TextReader stream = new StringReader(csvString);
            var csvReader = new CsvReader(stream, CultureInfo.InvariantCulture);
            return csvReader.GetRecords<SsbKjøring>();
        }
    }
}
