using EasyCityBreakdown.Common.Cities.Turkey;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public AbstractCity()
        {
            Breakdowns = new List<Breakdown>();
        }
        public AbstractCity(ISetting setting)
        {
            Setting = setting;
            Breakdowns = new List<Breakdown>();
        }
        public ISetting Setting { get; set; }
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
        public static T New(ISetting Setting = null)
        {
            var instance = Activator.CreateInstance<T>();
            instance.Setting = Setting;
            return instance;
        }
    }
    
}
