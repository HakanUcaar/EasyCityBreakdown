using EasyCityBreakdown.Abstraction;
using EasyCityBreakdown.Common.Cities.Turkey;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetAsynchronBreakdowns();
            //GetBreakdowns();
            //GetCityByIpAddress();
            //GetCityByName();
            GetCityGeoLocation();
            Console.ReadLine();
        }

        static void GetBreakdowns()
        {
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
        static void GetAsynchronBreakdowns()
        {
            var izmir = CityBreakdown.TurkeyAdapter.GetBreakdownsAsync<İzmir>();
            var manisa = CityBreakdown.TurkeyAdapter.GetBreakdownsAsync<Manisa>();
            var aydın = CityBreakdown.TurkeyAdapter.GetBreakdownsAsync<Aydın>();

            Console.WriteLine(İzmir.Information);
            izmir.Result.Take(2).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------------");

            Console.WriteLine(Manisa.Information);
            manisa.Result.Take(2).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------------");

            Console.WriteLine(Aydın.Information);
            aydın.Result.Take(2).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------------");
        }
        static void GetCityByIpAddress()
        {
            var city = CityBreakdown.TurkeyAdapter.FindCity(IpAddress.From(("xxx.xxx.xxx.xxx")));
            Console.WriteLine(city);                                  
        }
        static void GetCityByName()
        {
            var city = CityBreakdown.TurkeyAdapter.FindCity("İzmir");
            Console.WriteLine(city);
        }
        static void GetCityGeoLocation()
        {
            var city = CityBreakdown.TurkeyAdapter.FindCity("Ankara");
            Console.WriteLine(city.GeoLocation);
        }
    }
}
