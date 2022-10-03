using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Muş : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Muş", "49", GeoLocation.From((38.7333, 41.4911))));
        public Muş()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        public override List<Breakdown> GetBreakdowns()
        {
            throw new NotImplementedException();
        }
    }
}
