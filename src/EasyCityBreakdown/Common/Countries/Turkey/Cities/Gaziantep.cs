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
    public class Gaziantep : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Gaziantep", "27", GeoLocation.From((37.0667, 37.3833))));
        public Gaziantep()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var districtsReq = new RestRequest("https://online.toroslaredas.com.tr/adres/ilceler?ilKodu=27");
            var districts = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(districtsReq).ToString()).result.ilceListe;

            foreach (var district in districts)
            {
                var breakdownRequest = new RestRequest("https://online.toroslaredas.com.tr/wkt-sorgulama");
                breakdownRequest.AddParameter("Kurum", "7500");
                breakdownRequest.AddParameter("SorguTipi", "2");
                breakdownRequest.AddParameter("IlKodu", "27");
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
