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
            AddCity(AbstractCity<Adana>.New(Setting));
            AddCity(AbstractCity<Adıyaman>.New(Setting));
            AddCity(AbstractCity<Afyonkarahisar>.New(Setting));
            AddCity(AbstractCity<Ağrı>.New(Setting));
            AddCity(AbstractCity<Aksaray>.New(Setting));
            AddCity(AbstractCity<Amasya>.New(Setting));
            AddCity(AbstractCity<Ankara>.New(Setting));
            AddCity(AbstractCity<Antalya>.New(Setting));
            AddCity(AbstractCity<Ardahan>.New(Setting));
            AddCity(AbstractCity<Artvin>.New(Setting));
            AddCity(AbstractCity<Aydın>.New(Setting));
            AddCity(AbstractCity<Balıkesir>.New(Setting));
            AddCity(AbstractCity<Bartın>.New(Setting));
            AddCity(AbstractCity<Batman>.New(Setting));
            AddCity(AbstractCity<Bayburt>.New(Setting));
            AddCity(AbstractCity<Bilecik>.New(Setting));
            AddCity(AbstractCity<Bingöl>.New(Setting));
            AddCity(AbstractCity<Bitlis>.New(Setting));
            AddCity(AbstractCity<Bolu>.New(Setting));
            AddCity(AbstractCity<Burdur>.New(Setting));
            AddCity(AbstractCity<Bursa>.New(Setting));
            AddCity(AbstractCity<Çanakkale>.New(Setting));
            AddCity(AbstractCity<Çankırı>.New(Setting));
            AddCity(AbstractCity<Çorum>.New(Setting));
            AddCity(AbstractCity<Denizli>.New(Setting));
            AddCity(AbstractCity<Diyarbakır>.New(Setting));
            AddCity(AbstractCity<Düzce>.New(Setting));
            AddCity(AbstractCity<Edirne>.New(Setting));
            AddCity(AbstractCity<Elazığ>.New(Setting));
            AddCity(AbstractCity<Erzincan>.New(Setting));
            AddCity(AbstractCity<Erzurum>.New(Setting));
            AddCity(AbstractCity<Eskişehir>.New(Setting));
            AddCity(AbstractCity<Gaziantep>.New(Setting));
            AddCity(AbstractCity<Giresun>.New(Setting));
            AddCity(AbstractCity<Gümüşhane>.New(Setting));
            AddCity(AbstractCity<Hakkâri>.New(Setting));
            AddCity(AbstractCity<Hatay>.New(Setting));
            AddCity(AbstractCity<Iğdır>.New(Setting));
            AddCity(AbstractCity<Isparta>.New(Setting));
            AddCity(AbstractCity<İstanbul>.New(Setting));
            AddCity(AbstractCity<İzmir>.New(Setting));
            AddCity(AbstractCity<Kahramanmaraş>.New(Setting));
            AddCity(AbstractCity<Karabük>.New(Setting));
            AddCity(AbstractCity<Karaman>.New(Setting));
            AddCity(AbstractCity<Kars>.New(Setting));
            AddCity(AbstractCity<Kastamonu>.New(Setting));
            AddCity(AbstractCity<Kayseri>.New(Setting));
            AddCity(AbstractCity<Kırıkkale>.New(Setting));
            AddCity(AbstractCity<Kırklareli>.New(Setting));
            AddCity(AbstractCity<Kırşehir>.New(Setting));
            AddCity(AbstractCity<Kilis>.New(Setting));
            AddCity(AbstractCity<Kocaeli>.New(Setting));
            AddCity(AbstractCity<Konya>.New(Setting));
            AddCity(AbstractCity<Kütahya>.New(Setting));
            AddCity(AbstractCity<Malatya>.New(Setting));
            AddCity(AbstractCity<Manisa>.New(Setting));
            AddCity(AbstractCity<Mardin>.New(Setting));
            AddCity(AbstractCity<Mersin>.New(Setting));
            AddCity(AbstractCity<Muğla>.New(Setting));
            AddCity(AbstractCity<Muş>.New(Setting));
            AddCity(AbstractCity<Nevşehir>.New(Setting));
            AddCity(AbstractCity<Niğde>.New(Setting));
            AddCity(AbstractCity<Ordu>.New(Setting));
            AddCity(AbstractCity<Osmaniye>.New(Setting));
            AddCity(AbstractCity<Rize>.New(Setting));
            AddCity(AbstractCity<Sakarya>.New(Setting));
            //AddCity(AbstractCity<Samsun>.New(Setting));
            AddCity(AbstractCity<Siirt>.New(Setting));
            AddCity(AbstractCity<Sinop>.New(Setting));
            AddCity(AbstractCity<Sivas>.New(Setting));
            AddCity(AbstractCity<Şanlıurfa>.New(Setting));
            AddCity(AbstractCity<Şırnak>.New(Setting));
            AddCity(AbstractCity<Tekirdağ>.New(Setting));
            AddCity(AbstractCity<Tokat>.New(Setting));
            AddCity(AbstractCity<Trabzon>.New(Setting));
            AddCity(AbstractCity<Tunceli>.New(Setting));
            AddCity(AbstractCity<Uşak>.New(Setting));
            AddCity(AbstractCity<Van>.New(Setting));
            AddCity(AbstractCity<Yalova>.New(Setting));
            AddCity(AbstractCity<Yozgat>.New(Setting));
            AddCity(AbstractCity<Zonguldak>.New(Setting));
        }
     }
}
