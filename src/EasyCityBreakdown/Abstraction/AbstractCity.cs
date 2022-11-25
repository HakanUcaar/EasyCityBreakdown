using EasyCityBreakdown.Common.Cities.Turkey;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Optionable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public abstract class AbstractCity : ICity
    {
        public readonly List<Breakdown> Breakdowns;
        public ICountryAdapter Adapter;
        public AbstractCity()
        {
            Breakdowns = new List<Breakdown>();
        }
        public AbstractCity(ICountryAdapter adapter)
        {
            Adapter = adapter;
            Breakdowns = new List<Breakdown>();
        }
        public City Info { get; set; }
        public virtual List<Breakdown> GetBreakdowns()
        {
            var dataSetting = Adapter.GetOption<DataSetting>();
            if (dataSetting is not null)
            {
                return Breakdowns.Take(dataSetting.Limit).ToList();
            }
            return Breakdowns;
        }
        public virtual Task<List<Breakdown>> GetBreakdownsAsync()
        {
            return Task.Run(() => GetBreakdowns());
        }
        public string GetJsonBreakdowns()
        {
            var jsonSetting = Adapter.GetOption<JsonSetting>();
            if(jsonSetting is not null)
            {
                return JsonConvert.SerializeObject(GetBreakdowns(),Formatting.Indented, new IsoDateTimeConverter() { DateTimeFormat = jsonSetting.JsonDateFormat });
            }
            
            return JsonConvert.SerializeObject(GetBreakdowns(),Formatting.Indented);
            
        }
    }

    public abstract class AbstractCity<T> : AbstractCity where T : AbstractCity
    {
        public static T New(ICountryAdapter adapter)
        {
            var instance = Activator.CreateInstance<T>();
            instance.Adapter = adapter;
            return instance;
        }
    }
    
}
