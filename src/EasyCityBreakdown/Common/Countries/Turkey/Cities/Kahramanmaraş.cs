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
    public class Kahramanmaraş : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Kahramanmaraş", "46", GeoLocation.From((37.5875, 36.9453))));
        public Kahramanmaraş()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }

        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var datesRequest = new RestRequest("https://www.akedasdagitim.com.tr/getData.php?draw=2&columns[0][data]=0&columns[0][name]=&columns[0][searchable]=true&columns[0][orderable]=true&columns[0][search][value]=&columns[0][search][regex]=false&columns[1][data]=1&columns[1][name]=&columns[1][searchable]=true&columns[1][orderable]=true&columns[1][search][value]=&columns[1][search][regex]=false&columns[2][data]=2&columns[2][name]=&columns[2][searchable]=true&columns[2][orderable]=true&columns[2][search][value]=&columns[2][search][regex]=false&columns[3][data]=3&columns[3][name]=&columns[3][searchable]=true&columns[3][orderable]=true&columns[3][search][value]=&columns[3][search][regex]=false&columns[4][data]=4&columns[4][name]=&columns[4][searchable]=true&columns[4][orderable]=true&columns[4][search][value]=&columns[4][search][regex]=false&columns[5][data]=5&columns[5][name]=&columns[5][searchable]=true&columns[5][orderable]=true&columns[5][search][value]=&columns[5][search][regex]=false&columns[6][data]=6&columns[6][name]=&columns[6][searchable]=true&columns[6][orderable]=true&columns[6][search][value]=&columns[6][search][regex]=false&order[0][column]=0&order[0][dir]=asc&start=0&length=100&search[value]=&search[regex]=false&_=1667802615234");
            var breakdowns = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(datesRequest).ToString()).data;
            var breakdownList = ((IEnumerable)breakdowns).Cast<dynamic>().Where(a => a[0] == "Kahramanmaraş");

            foreach (var breakdown in breakdownList)
            {
                string expectedFormat = "yyyy-MM-dd HH:mm";
                DateTime startDate;
                DateTime endDate;
                DateTime.TryParseExact(
                    (string)($"{breakdown[2]} {breakdown[4]}"),
                    expectedFormat,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out startDate);

                DateTime.TryParseExact(
                      (string)($"{breakdown[2]} {breakdown[5]}"),
                      expectedFormat,
                      System.Globalization.CultureInfo.InvariantCulture,
                      System.Globalization.DateTimeStyles.None,
                      out endDate);

                Breakdowns.Add(Breakdown.From((startDate, endDate, breakdown[3], breakdown[1], breakdown[6])));
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
