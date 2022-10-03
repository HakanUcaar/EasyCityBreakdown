using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public class GeoLocation : ValueOf<(double latitude, double longitude), GeoLocation>
    {
        public double Latitude => Value.latitude;
        public double Longitude => Value.longitude;

        public override string ToString()
        {
            return $"lat/lng : {Value.latitude} , {Value.longitude}";
        }
    }
}
