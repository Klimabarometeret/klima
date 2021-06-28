using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformSsbBlobToSQL.Models
{
    class Ssb07849
    {
        public int Id { get; set; }

        public Region Region { get; set; }

        public string TypeKjøring { get; set; }

        public string Drivstofftype { get; set; }

        public int År { get; set; }

        public string Statistikkvariabel { get; set; }

        public int Antall { get; set; }

        public DateTime Dato { get; set; }

        public Ssb07849(string region, string typeKjøring, string drivstofftype, int år, string statistikkvariabel,
            int antall)
        {
            Region = GetRegionFromString(region);
            TypeKjøring = typeKjøring;
            Drivstofftype = drivstofftype;
            År = år;
            Statistikkvariabel = statistikkvariabel;
            Antall = antall;
            Dato = DateTime.Parse($"01-01-{år}");
        }

        public Region GetRegionFromString(string regionStr)
        {
            switch (regionStr)
            {
                case "0 Hele landet":
                    return Region.Norge;
                case "4204 Kristiansand":
                    return Region.Kristiansand;
                case "1001 Kristiansand (-2019)":
                    return Region.KristiansandFør2020;
                case "1018 Søgne (-2019)":
                    return Region.Søgne;
                case "1420 Sogndal (-2019)":
                    return Region.Sogndal;
                default:
                    throw new Exception("Uforventet region ble sendt inn");
            }
        }
    }

    enum Region
    {
        Norge,
        Kristiansand,
        KristiansandFør2020,
        Søgne,
        Sogndal
    }
}