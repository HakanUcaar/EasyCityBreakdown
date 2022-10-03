using EasyCityBreakdown.Common.Cities.Turkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public abstract class AbstractCity : ICity
    {
        public City Info { get; set; }
        public abstract List<Breakdown> GetBreakdowns();
    }

    public abstract class AbstractCity<T> : AbstractCity where T : AbstractCity
    {
        public static T New()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
