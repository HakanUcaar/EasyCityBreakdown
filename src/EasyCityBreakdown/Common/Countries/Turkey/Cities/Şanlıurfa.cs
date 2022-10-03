using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Şanlıurfa : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Şanlıurfa", "63", GeoLocation.From((37.1583, 38.7917))));
        public Şanlıurfa()
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
