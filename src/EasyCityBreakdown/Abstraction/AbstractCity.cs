using EasyCityBreakdown.Common.Cities.Turkey;
using Newtonsoft.Json;
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
        public virtual Task<List<Breakdown>> GetBreakdownsAsync()
        {
            return Task.Run(() => GetBreakdowns());
        }

        public string GetJsonBreakdowns()
        {
            return JsonConvert.SerializeObject(GetBreakdowns(),Formatting.Indented);
        }
    }

    public abstract class AbstractCity<T> : AbstractCity where T : AbstractCity
    {
        public static T New()
        {
            return Activator.CreateInstance<T>();
        }
    }
    
}
