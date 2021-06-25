using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace TransformSsbBlobToSQL.Models
{
    class SsbKjøring
    {
        // public int Id { get; set; }
        [Name("region")]
        public string Region { get; set; }

        [Name("type kjøring")]
        public string TypeKjøring { get; set; }

        [Name("drivstofftype")]
        public string DrivstoffType  { get; set; }

        [Name("år")]
        public int År { get; set; }

        [Name("statistikkvariabel")]
        public string StatistikkVariabel { get; set; }

        [Name("07849: Registrerte kjøretøy,")]
        public int RegistrerteKjøretøy { get; set; }
    }
}
