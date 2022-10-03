using EasyCityBreakdown.Abstraction;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Kırklareli : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Kırklareli", "39", GeoLocation.From((41.7347, 27.253))));
        public Kırklareli()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var getMainPage = new RestRequest("http://www.tredas.com.tr/Planlikesintiler/kırklareli-39");

            var html = client.Get(getMainPage).Content;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);


            var breakdowns = doc.DocumentNode.SelectNodes(@"//div[@class='kesintiler']//div[@class='col-lg-4 col-md-4 col-sm-4 col-xs-6']//a/@href");
            foreach (var breakdown in breakdowns)
            {
                var url = breakdown.Attributes["href"]?.Value;
                if (url is not null)
                {
                    var page = new RestRequest($"http://www.tredas.com.tr/{url}");
                    var itemHtml = client.Get(page).Content;
                    HtmlDocument breakdownDoc = new HtmlDocument();
                    breakdownDoc.LoadHtml(itemHtml);


                    var breakdownDistrict = breakdownDoc.DocumentNode.SelectSingleNode(@"//div[@class='kesinti-adres'][1]/p[2]/text()").InnerText.Trim();
                    var breakdownStart = breakdownDoc.DocumentNode.SelectSingleNode(@"//div[@class='kesinti-bilgi']//div[@class='kesinti-item'][2]/p[2]/text()").InnerText.Trim().Substring(0, 11);
                    var breakdownEnd = breakdownDoc.DocumentNode.SelectSingleNode(@"//div[@class='kesinti-bilgi']//div[@class='kesinti-item-content'][2]/p[2]/text()").InnerText.Trim().Substring(0, 11); ;
                    var breakdownRegion = breakdownDoc.DocumentNode.SelectSingleNode(@"//div[@class='kesinti-detay']").ChildNodes[4].InnerText.Trim();
                    var breakdownReason = breakdownDoc.DocumentNode.SelectSingleNode(@"//div[@class='kesinti-detay']//b[1]/text()").InnerText.Trim();

                    Breakdowns.Add(Breakdown.From((DateTime.Parse(breakdownStart), DateTime.Parse(breakdownEnd), breakdownReason, breakdownDistrict, breakdownRegion)));
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
