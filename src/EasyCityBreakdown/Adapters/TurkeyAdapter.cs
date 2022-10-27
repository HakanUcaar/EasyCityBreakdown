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
            AddCity(AbstractCity<Adana>.New(this));
            AddCity(AbstractCity<Adıyaman>.New(this));
            AddCity(AbstractCity<Afyonkarahisar>.New(this));
            AddCity(AbstractCity<Ağrı>.New(this));
            AddCity(AbstractCity<Aksaray>.New(this));
            AddCity(AbstractCity<Amasya>.New(this));
            AddCity(AbstractCity<Ankara>.New(this));
            AddCity(AbstractCity<Antalya>.New(this));
            AddCity(AbstractCity<Ardahan>.New(this));
            AddCity(AbstractCity<Artvin>.New(this));
            AddCity(AbstractCity<Aydın>.New(this));
            AddCity(AbstractCity<Balıkesir>.New(this));
            AddCity(AbstractCity<Bartın>.New(this));
            AddCity(AbstractCity<Batman>.New(this));
            AddCity(AbstractCity<Bayburt>.New(this));
            AddCity(AbstractCity<Bilecik>.New(this));
            AddCity(AbstractCity<Bingöl>.New(this));
            AddCity(AbstractCity<Bitlis>.New(this));
            AddCity(AbstractCity<Bolu>.New(this));
            AddCity(AbstractCity<Burdur>.New(this));
            AddCity(AbstractCity<Bursa>.New(this));
            AddCity(AbstractCity<Çanakkale>.New(this));
            AddCity(AbstractCity<Çankırı>.New(this));
            AddCity(AbstractCity<Çorum>.New(this));
            AddCity(AbstractCity<Denizli>.New(this));
            AddCity(AbstractCity<Diyarbakır>.New(this));
            AddCity(AbstractCity<Düzce>.New(this));
            AddCity(AbstractCity<Edirne>.New(this));
            AddCity(AbstractCity<Elazığ>.New(this));
            AddCity(AbstractCity<Erzincan>.New(this));
            AddCity(AbstractCity<Erzurum>.New(this));
            AddCity(AbstractCity<Eskişehir>.New(this));
            AddCity(AbstractCity<Gaziantep>.New(this));
            AddCity(AbstractCity<Giresun>.New(this));
            AddCity(AbstractCity<Gümüşhane>.New(this));
            AddCity(AbstractCity<Hakkâri>.New(this));
            AddCity(AbstractCity<Hatay>.New(this));
            AddCity(AbstractCity<Iğdır>.New(this));
            AddCity(AbstractCity<Isparta>.New(this));
            AddCity(AbstractCity<İstanbul>.New(this));
            AddCity(AbstractCity<İzmir>.New(this));
            AddCity(AbstractCity<Kahramanmaraş>.New(this));
            AddCity(AbstractCity<Karabük>.New(this));
            AddCity(AbstractCity<Karaman>.New(this));
            AddCity(AbstractCity<Kars>.New(this));
            AddCity(AbstractCity<Kastamonu>.New(this));
            AddCity(AbstractCity<Kayseri>.New(this));
            AddCity(AbstractCity<Kırıkkale>.New(this));
            AddCity(AbstractCity<Kırklareli>.New(this));
            AddCity(AbstractCity<Kırşehir>.New(this));
            AddCity(AbstractCity<Kilis>.New(this));
            AddCity(AbstractCity<Kocaeli>.New(this));
            AddCity(AbstractCity<Konya>.New(this));
            AddCity(AbstractCity<Kütahya>.New(this));
            AddCity(AbstractCity<Malatya>.New(this));
            AddCity(AbstractCity<Manisa>.New(this));
            AddCity(AbstractCity<Mardin>.New(this));
            AddCity(AbstractCity<Mersin>.New(this));
            AddCity(AbstractCity<Muğla>.New(this));
            AddCity(AbstractCity<Muş>.New(this));
            AddCity(AbstractCity<Nevşehir>.New(this));
            AddCity(AbstractCity<Niğde>.New(this));
            AddCity(AbstractCity<Ordu>.New(this));
            AddCity(AbstractCity<Osmaniye>.New(this));
            AddCity(AbstractCity<Rize>.New(this));
            AddCity(AbstractCity<Sakarya>.New(this));
            //AddCity(AbstractCity<Samsun>.New(this));
            AddCity(AbstractCity<Siirt>.New(this));
            AddCity(AbstractCity<Sinop>.New(this));
            AddCity(AbstractCity<Sivas>.New(this));
            AddCity(AbstractCity<Şanlıurfa>.New(this));
            AddCity(AbstractCity<Şırnak>.New(this));
            AddCity(AbstractCity<Tekirdağ>.New(this));
            AddCity(AbstractCity<Tokat>.New(this));
            AddCity(AbstractCity<Trabzon>.New(this));
            AddCity(AbstractCity<Tunceli>.New(this));
            AddCity(AbstractCity<Uşak>.New(this));
            AddCity(AbstractCity<Van>.New(this));
            AddCity(AbstractCity<Yalova>.New(this));
            AddCity(AbstractCity<Yozgat>.New(this));
            AddCity(AbstractCity<Zonguldak>.New(this));
        }
     }
}
