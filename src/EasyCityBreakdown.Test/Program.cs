using EasyCityBreakdown.Abstraction;
using EasyCityBreakdown.Common.Cities.Turkey;
using System;
using System.Linq;

namespace EasyCityBreakdown.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetBreakdowns();
            GetCityByIpAddress();
            GetCityByName();
            Console.ReadLine();
        }

        static void GetBreakdowns()
        {
            Console.WriteLine(İzmir.Information);
            var breakdowns = CityBreakdown.TurkeyAdapter.GetBreakdowns<İzmir>();
            if (breakdowns.Any())
            {
                breakdowns.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Hiç veri bulunamadı");
            }
        }
        static void GetCityByIpAddress()
        {
            var city = CityBreakdown.TurkeyAdapter.FindCity(IpAddress.From(("xx.xxx.xxx.xx")));
            Console.WriteLine(city);                                  
        }

        static void GetCityByName()
        {
            var city = CityBreakdown.TurkeyAdapter.FindCity("İzmir");
            Console.WriteLine(city);
        }
    }
}
