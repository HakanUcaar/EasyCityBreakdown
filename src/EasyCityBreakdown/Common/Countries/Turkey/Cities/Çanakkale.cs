using EasyCityBreakdown.Abstraction;
using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EasyCityBreakdown.Common.Cities.Turkey
{
    public class Çanakkale : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Çanakkale", "17", GeoLocation.From((40.15, 26.4))));
        public Çanakkale()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var client = new RestClient();
            var mainPageRequest = new RestRequest("https://www.uedas.com.tr/tr/kesintiler");

            var html = client.Get(mainPageRequest).Content;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var script = doc.DocumentNode.Descendants().Where(n => n.Name == "script").ToArray()[9].InnerText.Trim();
            script = script.Substring(5, script.IndexOf("$(function()") - 5);
            var cities = JsonConvert.DeserializeObject<dynamic>(script);
            var city = ((IEnumerable)cities).Cast<dynamic>().Where(a => a.id == 17).FirstOrDefault();
            var districts = ((IEnumerable)city.alt).Cast<dynamic>().Select(x => x.id);

            foreach (var item in districts)
            {
                var breakdownRequest = new RestRequest("https://www.uedas.com.tr/planli-kesintiler/sec.asp");
                breakdownRequest.AddParameter("ilce", (string)item);
                var xml = client.Post(breakdownRequest).Content;
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                HtmlDocument doc2 = new HtmlDocument();
                doc2.LoadHtml(xmlDoc.InnerText);
                var breakdowns = doc2.DocumentNode.SelectNodes(@"/tr");
                if (breakdowns is not null)
                {
                    foreach (var breakdown in breakdowns)
                    {
                        if (breakdown.ChildNodes[0].InnerText != "")
                        {
                            var date = DateTime.Parse(breakdown.ChildNodes[0].InnerText.Trim());
                            var time = breakdown.ChildNodes[1].InnerText.Trim();
                            var start = date.AddHours(Convert.ToInt16(time.Substring(0, 2)));
                            var end = date.AddHours(Convert.ToInt16(time.Substring(6, 2)));
                            var reason = breakdown.ChildNodes[2].InnerText.Trim();
                            var district = breakdown.ChildNodes[4].InnerText.Trim();
                            var region = breakdown.ChildNodes[5].InnerText.Trim() + " " + breakdown.ChildNodes[6].InnerText.Trim();

                            Breakdowns.Add(Breakdown.From((start, end, reason, district, region)));
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
