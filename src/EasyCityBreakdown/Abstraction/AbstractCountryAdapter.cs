using EasyCityBreakdown.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Abstraction
{
    public abstract class AbstractCountryAdapter: ICountryAdapter
    {
        public List<ICity> Cities { get; protected set; } = new List<ICity>();
        public List<Breakdown> Breakdowns { get; protected set; } = new List<Breakdown>();

        public void AddCity(ICity city)
        {
            Cities.Add(city);
        }
        public ICity FindCity(IpAddress IpAdress)
        {
            var client = new RestClient();
            var requestIpInfo = new RestRequest($"https://geo.ipify.org/api/v2/country,city?apiKey=at_dpm6765qoMPl5PPAIeTP4S3QSyKpv&ipAddress={IpAdress}");
            var response = JsonConvert.DeserializeObject<dynamic>(client.Get<dynamic>(requestIpInfo).ToString());
            var cityName = (string)response.location.region;
            var city = Cities.FirstOrDefault(x => x.Info.Name == cityName);
            if (city is null)
            {
                throw new CityNotFoundException();
            }
            return city;
        }
        public ICity FindCity(string Name)
        {
            var city = Cities.FirstOrDefault(x => x.Info.Name == Name);
            if (city is null)
            {
                throw new CityNotFoundException();
            }
            return city;
        }
        public virtual List<Breakdown> GetBreakdowns(ICity city)
        {
            if (!Cities.Any(x=>x == city))
            {
                throw new CityNotFoundException();
            }

            return city.GetBreakdowns();
        }
        public virtual Task<List<Breakdown>> GetBreakdownsAsync(ICity city)
        {
            if (!Cities.Any(x => x == city))
            {
                throw new CityNotFoundException();
            }

            return Task.Run(()=>city.GetBreakdowns());
        }
        public virtual List<Breakdown> GetBreakdowns<T>() where T : ICity
        {
            return new List<Breakdown>();
        }
        public virtual Task<List<Breakdown>> GetBreakdownsAsync<T>() where T : ICity
        {
            return Task.Run(()=>new List<Breakdown>());
        }
    }
}
