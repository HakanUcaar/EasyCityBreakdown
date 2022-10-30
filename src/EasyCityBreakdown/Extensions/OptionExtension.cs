using EasyCityBreakdown.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown
{
    public static class OptionExtension
    {
        public static ICountryAdapter AddOption<T>(this ICountryAdapter adapter, Action<T> option) where T : IOption
        {
            var optInstance = Activator.CreateInstance<T>();
            option(optInstance);
            adapter.Options.Add(optInstance);
            return adapter;
        }

        public static T GetOption<T>(this ICountryAdapter adapter) where T : IOption
        {
            return (T)adapter.Options.FirstOrDefault(x => x.GetType() == typeof(T));
        }
    }
}
