using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Trabzon : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Trabzon", "61", GeoLocation.From((41.005, 39.7225))));
        public Trabzon()
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
