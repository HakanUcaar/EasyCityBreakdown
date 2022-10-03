using EasyCityBreakdown.Adapters;
using System;

namespace EasyCityBreakdown
{
    public static class CityBreakdown
    {
        public static readonly TurkeyAdapter TurkeyAdapter;

        static CityBreakdown()
        {
            TurkeyAdapter = new TurkeyAdapter();
        }
    }
}
