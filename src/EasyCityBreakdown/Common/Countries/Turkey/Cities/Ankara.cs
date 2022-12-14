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
    public class Ankara : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Ankara", "06", GeoLocation.From((39.93, 32.85))));
        public Ankara()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }

        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();

            var requestIlceler = new RestRequest("https://online.baskentedas.com.tr/adres/ilceler?ilKodu=06");
            var ilceSerialize = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestIlceler).ToString());
            var ilceler = ((IEnumerable)ilceSerialize.result.ilceListe).Cast<dynamic>().Select(x=>x.ilceKodu);

            foreach (var ilce in ilceler)
            {
                var requestBreakdowns = new RestRequest("https://online.baskentedas.com.tr/wkt-sorgulama");
                requestBreakdowns.AddParameter("Kurum", "1000");
                requestBreakdowns.AddParameter("SorguTipi", "2");
                requestBreakdowns.AddParameter("IlKodu", "06");
                requestBreakdowns.AddParameter("IlceKodu", (string)ilce);
                var brekdownSerialize = JsonConvert.DeserializeObject<dynamic>(client.Post<dynamic>(requestBreakdowns).ToString());

                var breakdowns1 = ((IEnumerable)brekdownSerialize.result.planlananKesintiListe).Cast<dynamic>();
                var breakdowns2 = ((IEnumerable)brekdownSerialize.result.mevcutKesintiListe).Cast<dynamic>();
                var breakdownsUnion = breakdowns1.Concat(breakdowns2);
                foreach (var breakdown in breakdownsUnion)
                {
                    DateTime startDate =  startDate = DateTime.ParseExact((string)breakdown.kesintiBaslangicTarihi, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    TimeSpan? time = null;
                    if ((string)breakdown.kesintiBitisTarihi != "")
                    {
                        time = TimeSpan.Parse((string)breakdown.kesintiBitisTarihi);
                    }
                    
                    Breakdowns.Add(Breakdown.From((startDate, time.HasValue ? startDate.Date.AddHours(time.Value.TotalHours) : startDate, breakdown.kesintiNedeni, breakdown.ilceAdi, breakdown.etkilenenCaddeSokak)));
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
