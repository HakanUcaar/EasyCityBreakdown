using EasyCityBreakdown.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public class City : ValueOf<(string name, string plateCode, GeoLocation geoLocation), City>
    {
        public string Name => Value.name;
        public string PlateCode => Value.plateCode;
        public GeoLocation GeoLocation => Value.geoLocation;

        public override string ToString()
        {
            return $"İl : {Value.name} - Plaka : {Value.plateCode} - {Value.geoLocation}";
        }
    }
}
