using EasyCityBreakdown.Abstraction;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Muğla : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Muğla", "48", GeoLocation.From((37.2167, 28.3667))));
        public Muğla()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var requestBreakdowns = new RestRequest("https://www.admelektrik.com.tr/tr/api/outages/?format=json&page_size=1000");
            var requestDistricts = new RestRequest("https://www.admelektrik.com.tr/tr/api/districts/?city=9,20,48&format=json&page_size=1000");

            var responseBreakdowns = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestBreakdowns).ToString());
            var responseDistricts = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestDistricts).ToString());
            responseBreakdowns = ((IEnumerable)responseBreakdowns.results).Cast<dynamic>().Where(a => a.city == 48);
            foreach (var item in responseBreakdowns)
            {
                var district = ((IEnumerable)responseDistricts.results).Cast<dynamic>().FirstOrDefault(a => a.id == item.district);
                Breakdowns.Add(Breakdown.From((item.starts_at, item.ends_at, item.get_reason, district.name,item.manuel_zone)));
            }
            return Breakdowns;
        }
        public override List<Breakdown> GetBreakdowns()
        {
            return this.GetElectricBreakdowns();
        }
    }
}
