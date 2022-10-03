using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Kars : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Kars", "36", GeoLocation.From((40.6078, 43.0958))));
        public Kars()
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
