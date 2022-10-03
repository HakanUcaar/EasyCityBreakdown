using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Mardin : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Mardin", "47", GeoLocation.From((37.3131, 40.735))));
        public Mardin()
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
