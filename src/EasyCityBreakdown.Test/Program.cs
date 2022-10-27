using EasyCityBreakdown.Abstraction;
using EasyCityBreakdown.Common.Cities.Turkey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetBreakdownsSample();
            //GetAsynchronBreakdownsSample();
            //GetCityByIpAddressSample();
            //GetCityByNameSample();
            //GeoLocationSample();
            //JsonSample();
            SettingSample();
            Console.ReadLine();
        }

        static void GetBreakdownsSample()
        {
            var breakdowns = CityBreakdown.TurkeyAdapter.GetBreakdowns<Tokat>();
            if (breakdowns.Any())
            {
                breakdowns.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Hiç veri bulunamadı");
            }
        }
        static void GetAsynchronBreakdownsSample()
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
        static void GetCityByIpAddressSample()
        {
            CityBreakdown.TurkeyAdapter.FindCity(IpAddress.From(("xxx.xxx.xxx.xxx"))).Info.ToConsole();                    
        }
        static void GetCityByNameSample()
        {
            CityBreakdown.TurkeyAdapter.FindCity("İzmir").Info.ToConsole();
        }
        static void GeoLocationSample()
        {
            CityBreakdown.TurkeyAdapter.FindCity("Ankara").Info.GeoLocation.ToConsole();
        }
        static void JsonSample()
        {
            CityBreakdown.TurkeyAdapter.AddOption<DataSetting>(option => option.Limit = 3);
            CityBreakdown.TurkeyAdapter.FindCity("İzmir").GetJsonBreakdowns().ToConsole();            
        }
        static void SettingSample()
        {
            CityBreakdown.TurkeyAdapter.AddOption<JsonSetting>(option => option.JsonDateFormat = "yyyy-MM-dd");
            CityBreakdown.TurkeyAdapter.AddOption<DataSetting>(option => option.Limit = 3);

            CityBreakdown.TurkeyAdapter.FindCity("İzmir").GetJsonBreakdowns().ToConsole();
        }
    }
}
