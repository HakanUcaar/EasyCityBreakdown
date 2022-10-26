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
    public class Sivas : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Sivas", "58", GeoLocation.From((39.75, 37.0167))));
        public Sivas()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var datesRequest = new RestRequest("https://ws.ckenerji.com.tr/kesintiCedas/Home/getDates");
            var dates = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(datesRequest).ToString());

            var districtsReq = new RestRequest("https://ws.ckenerji.com.tr/kesintiCedas/Home/getSelectListValues");
            var districts = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(districtsReq).ToString()).adressSelectList;
            var districtList = (((IEnumerable)districts).Cast<dynamic>()).FirstOrDefault(x => x.UavtCode == 58).addressList;

            foreach (var date in dates)
            {
                foreach (var district in districtList)
                {
                    var breakdownRequest = new RestRequest($"https://ws.ckenerji.com.tr/kesintiCedas/Home/kesinti");
                    breakdownRequest.AddParameter("sehir", "SİVAS");
                    breakdownRequest.AddParameter("ilce", (string)district.UavtText);
                    breakdownRequest.AddParameter("date", (string)date.fullDate);
                    breakdownRequest.AddParameter("poligonCheck", "1");
                    breakdownRequest.AddParameter("channelCheck", "MOBİLE");

                    var breakdown = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(breakdownRequest).ToString()).plannedOutageList;
                    var breakdownList = ((IEnumerable)breakdown).Cast<dynamic>();
                    foreach (var item in breakdownList)
                    {
                        Breakdowns.Add(Breakdown.From((item.startDateTime, item.endDateTime, item.reason, item.county, item.message)));
                    }
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
