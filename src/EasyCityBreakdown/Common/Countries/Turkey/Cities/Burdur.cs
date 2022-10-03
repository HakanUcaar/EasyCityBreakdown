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
    public class Burdur : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Burdur", "15", GeoLocation.From((37.7167, 30.2833))));
        public Burdur()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var dateRequest = new RestRequest("https://ws.ckenerji.com.tr/kesintiAedas/Home/getDates");
            var districtRequest = new RestRequest("https://ws.ckenerji.com.tr/kesintiAedas/Home/getSelectListValues");
            var dates = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(dateRequest).ToString());
            var districts = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(districtRequest).ToString());
            districts = ((IEnumerable)districts.adressSelectList).Cast<dynamic>().Where(a => a.UavtCode == "15");
            var breakdowns = new RestRequest("https://ws.ckenerji.com.tr/kesintiAedas/Home/getDates");

            foreach (var date in dates)
            {
                var city = ((IEnumerable)districts).Cast<dynamic>().FirstOrDefault();
                foreach (var district in city.addressList)
                {
                    var req = new
                    {
                        sehir = city.UavtText,
                        ilce = district.UavtText,
                        date = date.fullDate,
                        fix = "",
                        statu = "1",
                        poligonCheck = "1",
                        channelCheck = "MOBİLE"
                    };

                    var breakdownRequest = new RestRequest("https://ws.ckenerji.com.tr/kesintiaedas/Home/kesinti");
                    breakdownRequest.AddParameter("sehir", (string)city.UavtText);
                    breakdownRequest.AddParameter("ilce", (string)district.UavtText);
                    breakdownRequest.AddParameter("date", (string)date.fullDate);
                    breakdownRequest.AddParameter("statu", "1");
                    breakdownRequest.AddParameter("poligonCheck", "1");
                    breakdownRequest.AddParameter("channelCheck", "MOBİLE");
                    var breakdown = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(breakdownRequest).ToString());
                    var breakdownList = ((IEnumerable)breakdown.plannedOutageList).Cast<dynamic>();
                    if (breakdownList.Count() > 0)
                    {

                        foreach (var item in breakdownList)
                        {
                            Breakdowns.Add(Breakdown.From((item.startDateTime, item.endDateTime, item.reason, district.UavtText, item.message)));
                        }
                    }
                }
            }
            return Breakdowns;
        }
        public override List<Breakdown> GetBreakdowns()
        {
            return this.GetElectricBreakdowns();
        }
    }
}
