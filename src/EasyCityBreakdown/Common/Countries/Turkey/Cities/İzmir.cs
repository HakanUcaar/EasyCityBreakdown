using EasyCityBreakdown.Abstraction;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class İzmir : AbstractCity
    {        
        public static City Information => City.From(("İzmir", "35", GeoLocation.From((38.4127, 27.1384))));
        public İzmir()
        {
            Info = Information;
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var requestBreakdowns = new RestRequest("https://www.gdzelektrik.com.tr/tr/api/outages/?format=json&page_size=1000");
            var requestDistricts = new RestRequest("https://www.gdzelektrik.com.tr/tr/api/districts/?city=35,45&format=json&page_size=1000");

            var responseBreakdowns = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestBreakdowns).ToString());
            var responseDistricts = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestDistricts).ToString());
            responseBreakdowns = ((IEnumerable)responseBreakdowns.results).Cast<dynamic>().Where(a => a.city == 35);
            foreach (var item in responseBreakdowns)
            {
                var district = ((IEnumerable)responseDistricts.results).Cast<dynamic>().FirstOrDefault(a => a.id == item.district);
                Breakdowns.Add(Breakdown.From((item.starts_at, item.ends_at, item.get_reason, district.name, item.manuel_zone)));
            }
            return Breakdowns;
        }
        public override List<Breakdown> GetBreakdowns()
        {
            Breakdowns.Clear();
            GetElectricBreakdowns();         

            return base.GetBreakdowns(); 
        }
    }
}
