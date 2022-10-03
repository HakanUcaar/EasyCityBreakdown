using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class İstanbul : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("İstanbul", "34", GeoLocation.From((41.01, 28.9603))));
        public İstanbul()
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
