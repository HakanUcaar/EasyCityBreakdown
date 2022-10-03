using EasyCityBreakdown.Abstraction;
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
    public class Düzce : AbstractCity
    {
        public readonly List<Breakdown> Breakdowns;
        public static City Information => City.From(("Düzce", "81", GeoLocation.From((40.8417, 31.1583))));
        public Düzce()
        {
            Info = Information;
            Breakdowns = new List<Breakdown>();
        }
        private List<Breakdown> GetElectricBreakdowns()
        {
            var requestXml = @"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:xsi ='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd = 'http://www.w3.org/2001/XMLSchema' xmlns:soap = 'http://schemas.xmlsoap.org/soap/envelope/'><soap:Body><GetPlanliKesinti xmlns='http://tempuri.org/'><basDate>"+DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")+"</basDate><bitDate>" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "</bitDate><plakaKodu>99</plakaKodu></GetPlanliKesinti></soap:Body></soap:Envelope>";
            var client = new RestClient();
            var request = new RestRequest("https://www.sedas.com/_vti_bin/Sedas/PlanliKesinti/PlanliKesinti.asmx");
            request.AddHeader("Content-Type", "text/xml");
            request.AddHeader("Accept", "text/xml");
            request.AddParameter("text/xml", requestXml, ParameterType.RequestBody);

            var xmlContent = client.Post(request).Content;


            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            var namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            namespaceManager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");

            var data = JsonConvert.DeserializeObject<dynamic>(xmlDoc.InnerText);
            var breakdowns = ((IEnumerable)data).Cast<dynamic>().Where(x => x.ZIL == "DÜZCE");

            foreach (var item in breakdowns)
            {
                var startDate = $"{item.TARIH} {((string)item.ZBASSAAT).Replace(".", ":")}:00";
                var endDate = $"{item.TARIH} {((string)item.ZBITSAAT).Replace(".", ":")}:00";
                Breakdowns.Add(Breakdown.From((DateTime.Parse(startDate), DateTime.Parse(endDate), item.ZNEDEN, item.ZILCE, item.ZYER)));
            }

            return Breakdowns;
        }
        public override List<Breakdown> GetBreakdowns()
        {
            return this.GetElectricBreakdowns();
        }
    }
}
