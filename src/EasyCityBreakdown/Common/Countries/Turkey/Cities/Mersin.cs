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
    public class Mersin : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Mersin", "33", GeoLocation.From((36.8, 34.6167))));
        public Mersin()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var districtsReq = new RestRequest("https://online.toroslaredas.com.tr/adres/ilceler?ilKodu=33");
            var districts = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(districtsReq).ToString()).result.ilceListe;

            foreach (var district in districts)
            {
                var breakdownRequest = new RestRequest("https://online.toroslaredas.com.tr/wkt-sorgulama");
                breakdownRequest.AddParameter("Kurum", "7500");
                breakdownRequest.AddParameter("SorguTipi", "2");
                breakdownRequest.AddParameter("IlKodu", "33");
                breakdownRequest.AddParameter("IlceKodu", (string)district.ilceKodu);
                var breakdown = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(breakdownRequest).ToString());
                var plannedBreakdownList = ((IEnumerable)breakdown.result.planlananKesintiListe).Cast<dynamic>();
                var unPlannedBreakdownList = ((IEnumerable)breakdown.result.mevcutKesintiListe).Cast<dynamic>();
                if (plannedBreakdownList.Count() > 0)
                {
                    foreach (var item in plannedBreakdownList)
                    {
                        DateTime startDate = startDate = DateTime.ParseExact((string)item.kesintiBaslangicTarihi, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan? time = null;
                        if ((string)item.kesintiBitisTarihi != "")
                        {
                            time = TimeSpan.Parse((string)item.kesintiBitisTarihi);
                        }

                        Breakdowns.Add(Breakdown.From((startDate, time.HasValue ? startDate.Date.AddHours(time.Value.TotalHours) : startDate, item.kesintiNedeni, district.ilceAdi, item.etkilenenCaddeSokak)));
                    }
                }
                if (unPlannedBreakdownList.Count() > 0)
                {
                    foreach (var item in unPlannedBreakdownList)
                    {
                        DateTime startDate = startDate = DateTime.ParseExact((string)item.kesintiBaslangicTarihi, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                        TimeSpan? time = null;
                        if ((string)item.kesintiBitisTarihi != "")
                        {
                            time = TimeSpan.Parse((string)item.kesintiBitisTarihi);
                        }
                        Breakdowns.Add(Breakdown.From((startDate, time.HasValue ? startDate.Date.AddHours(time.Value.TotalHours) : startDate, item.kesintiNedeni, district.ilceAdi, item.etkilenenCaddeSokak)));
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
