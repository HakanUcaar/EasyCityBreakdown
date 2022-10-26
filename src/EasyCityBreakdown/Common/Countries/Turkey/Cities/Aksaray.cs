using EasyCityBreakdown.Abstraction;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Aksaray : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Aksaray", "68", GeoLocation.From((38.3686, 34.0297))));
        public Aksaray()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var districtsReq = new RestRequest("https://cc.meramedas.com.tr/services/publicdata.ashx?m=mrm_gb1_ilce&il=68");
            var districts = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(districtsReq).ToString());

            foreach (var district in districts)
            {
                var breakdownRequest = new RestRequest($"https://cc.meramedas.com.tr/services/publicdata.ashx?m=mrm_gb1&il=68&ilce={(string)district.Name}&mahalle=&ay=&yil=");
                var breakdown = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(breakdownRequest).ToString());
                var breakdownList = ((IEnumerable)breakdown).Cast<dynamic>();
                breakdownList = breakdownList.GroupBy(x => new { x.PlanlananBaslangic, x.PlanlananBitis, x.IlanTipi, x.IlceAdi }).Select(x => new
                {
                    x.Key.PlanlananBaslangic,
                    x.Key.PlanlananBitis,
                    x.Key.IlanTipi,
                    x.Key.IlceAdi,
                    regions = string.Join(",",x.Select(y=>(string)y.MahalleKoyAdi).Distinct())
                });
                foreach (var item in breakdownList)
                {
                    Breakdowns.Add(Breakdown.From((item.PlanlananBaslangic, item.PlanlananBitis, item.IlanTipi, item.IlceAdi, item.regions)));
                }
            }
            return Breakdowns;
        }

        public override List<Breakdown> GetBreakdowns()
        {
            Breakdowns.Clear();
            return this.GetElectricBreakdowns();
        }
    }
}
