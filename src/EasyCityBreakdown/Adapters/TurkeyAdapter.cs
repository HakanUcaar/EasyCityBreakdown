using EasyCityBreakdown.Abstraction;
using EasyCityBreakdown.Common.Cities.Turkey;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCityBreakdown.Adapters
{
    public class TurkeyAdapter : AbstractCountryAdapter
    {

        public TurkeyAdapter()
        {
            AddCity(AbstractCity<Adana>.New());
            AddCity(AbstractCity<Adıyaman>.New());
            AddCity(AbstractCity<Afyonkarahisar>.New());
            AddCity(AbstractCity<Ağrı>.New());
            AddCity(AbstractCity<Aksaray>.New());
            AddCity(AbstractCity<Amasya>.New());
            AddCity(AbstractCity<Ankara>.New());
            AddCity(AbstractCity<Antalya>.New());
            AddCity(AbstractCity<Ardahan>.New());
            AddCity(AbstractCity<Artvin>.New());
            AddCity(AbstractCity<Aydın>.New());
            AddCity(AbstractCity<Balıkesir>.New());
            AddCity(AbstractCity<Bartın>.New());
            AddCity(AbstractCity<Batman>.New());
            AddCity(AbstractCity<Bayburt>.New());
            AddCity(AbstractCity<Bilecik>.New());
            AddCity(AbstractCity<Bingöl>.New());
            AddCity(AbstractCity<Bitlis>.New());
            AddCity(AbstractCity<Bolu>.New());
            AddCity(AbstractCity<Burdur>.New());
            AddCity(AbstractCity<Bursa>.New());
            AddCity(AbstractCity<Çanakkale>.New());
            AddCity(AbstractCity<Çankırı>.New());
            AddCity(AbstractCity<Çorum>.New());
            AddCity(AbstractCity<Denizli>.New());
            AddCity(AbstractCity<Diyarbakır>.New());
            AddCity(AbstractCity<Düzce>.New());
            AddCity(AbstractCity<Edirne>.New());
            AddCity(AbstractCity<Elazığ>.New());
            AddCity(AbstractCity<Erzincan>.New());
            AddCity(AbstractCity<Erzurum>.New());
            AddCity(AbstractCity<Eskişehir>.New());
            AddCity(AbstractCity<Gaziantep>.New());
            AddCity(AbstractCity<Giresun>.New());
            AddCity(AbstractCity<Gümüşhane>.New());
            AddCity(AbstractCity<Hakkâri>.New());
            AddCity(AbstractCity<Hatay>.New());
            AddCity(AbstractCity<Iğdır>.New());
            AddCity(AbstractCity<Isparta>.New());
            AddCity(AbstractCity<İstanbul>.New());
            AddCity(AbstractCity<İzmir>.New());
            AddCity(AbstractCity<Kahramanmaraş>.New());
            AddCity(AbstractCity<Karabük>.New());
            AddCity(AbstractCity<Karaman>.New());
            AddCity(AbstractCity<Kars>.New());
            AddCity(AbstractCity<Kastamonu>.New());
            AddCity(AbstractCity<Kayseri>.New());
            AddCity(AbstractCity<Kırıkkale>.New());
            AddCity(AbstractCity<Kırklareli>.New());
            AddCity(AbstractCity<Kırşehir>.New());
            AddCity(AbstractCity<Kilis>.New());
            AddCity(AbstractCity<Kocaeli>.New());
            AddCity(AbstractCity<Konya>.New());
            AddCity(AbstractCity<Kütahya>.New());
            AddCity(AbstractCity<Malatya>.New());
            AddCity(AbstractCity<Manisa>.New());
            AddCity(AbstractCity<Mardin>.New());
            AddCity(AbstractCity<Mersin>.New());
            AddCity(AbstractCity<Muğla>.New());
            AddCity(AbstractCity<Muş>.New());
            AddCity(AbstractCity<Nevşehir>.New());
            AddCity(AbstractCity<Niğde>.New());
            AddCity(AbstractCity<Ordu>.New());
            AddCity(AbstractCity<Osmaniye>.New());
            AddCity(AbstractCity<Rize>.New());
            AddCity(AbstractCity<Sakarya>.New());
            //AddCity(AbstractCity<Samsun>.New());
            AddCity(AbstractCity<Siirt>.New());
            AddCity(AbstractCity<Sinop>.New());
            AddCity(AbstractCity<Sivas>.New());
            AddCity(AbstractCity<Şanlıurfa>.New());
            AddCity(AbstractCity<Şırnak>.New());
            AddCity(AbstractCity<Tekirdağ>.New());
            AddCity(AbstractCity<Tokat>.New());
            AddCity(AbstractCity<Trabzon>.New());
            AddCity(AbstractCity<Tunceli>.New());
            AddCity(AbstractCity<Uşak>.New());
            AddCity(AbstractCity<Van>.New());
            AddCity(AbstractCity<Yalova>.New());
            AddCity(AbstractCity<Yozgat>.New());
            AddCity(AbstractCity<Zonguldak>.New());
        }
        public override List<Breakdown> GetBreakdowns(ICity city)
        {
            return city.GetBreakdowns();
        }
        public override List<Breakdown> GetBreakdowns<T>() 
        {
            return ((ICity)Activator.CreateInstance<T>()).GetBreakdowns();
        }
        public override Task<List<Breakdown>> GetBreakdownsAsync<T>()
        {
            return ((ICity)Activator.CreateInstance<T>()).GetBreakdownsAsync();
        }
    }
}
