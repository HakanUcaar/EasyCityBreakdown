# EasyCityBreakdown
Turkey city breakdowns and outages.

<details>
	<summary>Todo</summary>
 
  - [X] JSON serialize
  - [ ] Nuget package
  - [ ] Web deploy(open api)
  - [ ] Add more city
    - [ ] Turkey
      - [X] Adana
      - [ ] Adıyaman
      - [ ] Afyonkarahisar
      - [ ] Ağrı
      - [ ] Aksaray
      - [ ] Amasya
      - [X] Ankara
      - [X] Antalya
      - [ ] Ardahan
      - [ ] Artvin
      - [X] Aydın
      - [X] Balıkesir
      - [X] Bartın
      - [ ] Batman
      - [ ] Bayburt
      - [X] Bilecik
      - [ ] Bingöl
      - [ ] Bitlis
      - [X] Bolu
      - [X] Burdur
      - [X] Bursa
      - [X] Çanakkale
      - [X] Çankırı
      - [ ] Çorum
      - [X] Denizli
      - [ ] Diyarbakır
      - [X] Düzce
      - [X] Edirne
      - [ ] Elazığ
      - [ ] Erzincan
      - [ ] Erzurum
      - [ ] Eskişehir
      - [X] Gaziantep
      - [ ] Giresun
      - [ ] Gümüşhane
      - [ ] Hakkâri
      - [X] Hatay
      - [ ] Iğdır
      - [X] Isparta
      - [ ] Istanbul
      - [X] İzmir
      - [ ] Kahramanmaraş
      - [X] Karabük
      - [ ] Karaman
      - [ ] Kars
      - [X] Kastamonu
      - [ ] Kayseri
      - [X] Kırıkkale
      - [X] Kırklareli
      - [ ] Kırşehir
      - [X] Kilis
      - [X] Kocaeli
      - [ ] Konya
      - [ ] Kütahya
      - [ ] Malatya
      - [X] Manisa
      - [ ] Mardin
      - [X] Mersin
      - [X] Muğla
      - [ ] Muş
      - [ ] Nevşehir
      - [ ] Niğde
      - [ ] Ordu
      - [X] Osmaniye
      - [ ] Rize
      - [X] Sakarya
      - [ ] Samsun
      - [ ] Siirt
      - [ ] Sinop
      - [ ] Sivas
      - [ ] Şanlıurfa
      - [ ] Şırnak
      - [X] Tekirdağ
      - [ ] Tokat
      - [ ] Trabzon
      - [ ] Tunceli
      - [ ] Uşak
      - [ ] Van
      - [X] Yalova
      - [ ] Yozgat
      - [X] Zonguldak    
 
</details>

## Adapter List
- TurkeyAdapter

## Usage

### *Get Outages
``` csharp
  Console.WriteLine(Düzce.Information);
  CityBreakdown.TurkeyAdapter.GetBreakdowns<Düzce>().ForEach(x => Console.WriteLine(x));
```
Output
```
İl : Düzce - Plaka : 81
(14.09.2022 09:00:00, 14.09.2022 10:00:00, KESİNTİ ÖNLEME AMAÇLI GENEL BAKIM ONARIM ÇALIŞMASI-Planlı Kesinti No:35344, MERKEZ, 458. SK.)
(14.09.2022 09:00:00, 14.09.2022 10:00:00, KESİNTİ ÖNLEME AMAÇLI GENEL BAKIM ONARIM ÇALIŞMASI-Planlı Kesinti No:35344, MERKEZ, 464. SK.)
(14.09.2022 09:00:00, 14.09.2022 10:00:00, KESİNTİ ÖNLEME AMAÇLI GENEL BAKIM ONARIM ÇALIŞMASI-Planlı Kesinti No:35344, MERKEZ, 484. SK.)
(14.09.2022 09:00:00, 14.09.2022 10:00:00, KESİNTİ ÖNLEME AMAÇLI GENEL BAKIM ONARIM ÇALIŞMASI-Planlı Kesinti No:35344, MERKEZ, 5736. SK.)
(14.09.2022 09:00:00, 14.09.2022 10:00:00, KESİNTİ ÖNLEME AMAÇLI GENEL BAKIM ONARIM ÇALIŞMASI-Planlı Kesinti No:35344, MERKEZ, 5739. SK.)
```

### *Some Functions
``` csharp
CityBreakdown.TurkeyAdapter.FindCity(IpAddress.From(("xxx.xxx.xxx.xxx"))).Info.ToConsole();

Output

İl : İstanbul - Plaka : 34 - lat/lng : 41,01 , 28,9603
```

``` csharp
CityBreakdown.TurkeyAdapter.FindCity("İzmir").Info.ToConsole();

Output

İl : İzmir - Plaka : 35 - lat/lng : 38,4127 , 27,1384
```

### *Asynchronous
``` csharp
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
```
```
Output

İl : İzmir - Plaka : 35 - lat/lng : 38,4127 , 27,1384
(4.10.2022 09:00:00, 4.10.2022 10:00:00, ŞEBEKE İŞLETMECİSİ, KONAK, AZİZİYE MAHALLESİ,574-575-576-628-657-659-660-661-663-666-668-669-670-671-672-675-713-714-721-747-753-754-756-757 SOKAKLAR VE CİVARI)
(4.10.2022 09:00:00, 4.10.2022 17:00:00, OG ŞEBEKE BAKIM ÇALIŞMASI NEDENİYLE, FOÇA, YENİ FOÇA FEVZİ ÇAKMAK MAHALLESİ ORUÇ REİS CADDESİ BİR BÖLÜMÜ, HİLAL, DOĞAN, ÇİNGİL, SICAKDERE, SOĞUKSU, SUSAM SOKAKLARI VE CİVARLARI)
-----------------
İl : Manisa - Plaka : 45 - lat/lng : 38,6333 , 27,4167
(4.10.2022 08:45:00, 4.10.2022 09:00:00, ARIZA ONARIM BAKIM, SARUHANLI, BAHADIR,SARIÇAM,ÇALTEPE,SARISIĞIRLI,HATIPLAR,AYDINLAR  MAHALELLERİ İLE İŞLETME VE TARIM SULAMA ALANLARI)
(4.10.2022 09:00:00, 4.10.2022 17:00:00, ŞEBEKE BAKIM ÇALIŞMASI, KIRKAĞAÇ, DUALAR SAYARLAR DERE MAH ARDIÇLI HELİMLER MAH ARMUTÇUK HACET ÇOBANLAR VE ÖZEL TRAFOLAR)
-----------------
İl : Aydın - Plaka : 09 - lat/lng : 37,8481 , 27,8453
(4.10.2022 09:00:00, 4.10.2022 12:00:00, Arıza Onarım Ve Bakım Nedeniyle, KUŞADASI, YAVANSU MAHALLESINDE BULUNAN;  YEŞIL SITE (ALT KISIM))
(4.10.2022 09:00:00, 4.10.2022 15:00:00, Arıza Onarım Ve Bakım Nedeniyle, KUŞADASI, DAVUTLAR MAHALLESINDE BULUNAN; CENGIZ TOPEL CADDESI, ADNAN KAHVECI CADDESI, ETE SITESI, YEŞIL CENNET TUR SITESI, SÖKE DENIZKENT SITESI, GÖKSUN SITESI, YÖREKENT SITESI, ALTINAY SITESI, AKTUNA SITESI, KARDEŞEVLER SITESI, ÖZÇELIK SITESI GENÇLIK SPOR MÜDÜRLÜĞÜ KAMPI, SENDIKA OTELI)
-----------------
```
### *City GeoLocation
``` csharp
CityBreakdown.TurkeyAdapter.FindCity("Ankara").Info.GeoLocation.ToConsole();
```
```
Output
lat/lng : 39.93 , 32.85
```
#### Picture
![alt text for screen readers](https://github.com/HakanUcaar/EasyCityBreakdown/blob/main/GeoLocation.png?raw=true "City Center GeoLocation").

### *JSON
``` csharp
CityBreakdown.TurkeyAdapter.FindCity("İzmir").GetJsonBreakdowns().ToConsole();
```
```
Output
[
  {
    "StartDate": "2022-10-04T09:00:00",
    "EndDate": "2022-10-04T10:00:00",
    "Reason": "ŞEBEKE İŞLETMECİSİ",
    "District": "KONAK",
    "Region": "AZİZİYE MAHALLESİ,574-575-576-628-657-659-660-661-663-666-668-669-670-671-672-675-713-714-721-747-753-754-756-757 SOKAKLAR VE CİVARI"
  },
  {
    "StartDate": "2022-10-04T09:00:00",
    "EndDate": "2022-10-04T17:00:00",
    "Reason": "OG ŞEBEKE BAKIM ÇALIŞMASI NEDENİYLE",
    "District": "FOÇA",
    "Region": "YENİ FOÇA FEVZİ ÇAKMAK MAHALLESİ ORUÇ REİS CADDESİ BİR BÖLÜMÜ, HİLAL, DOĞAN, ÇİNGİL, SICAKDERE, SOĞUKSU, SUSAM SOKAKLARI VE CİVARLARI"
  }
]
```

### *Setting
``` csharp
CityBreakdown.TurkeyAdapter.Setting.Limit = 3;
CityBreakdown.TurkeyAdapter.Setting.JsonDateFormat = "dd.MM.yyyy HH:mm";
CityBreakdown.TurkeyAdapter.FindCity("İzmir").GetJsonBreakdowns().ToConsole();
```
```
Output
[
  {
    "StartDate": "05.10.2022 09:00",
    "EndDate": "05.10.2022 17:00",
    "Reason": "ŞEBEKE İŞLETMECİSİ",
    "District": "BAYRAKLI",
    "Region": "OSMANGAZİ MAHALLESİ,YAVUZ,DUMLUPINAR,İBRAHİM GALİP CADDELERİ,597,616, 597/1 SOKAKLAR VE CİVARI"
  },
  {
    "StartDate": "05.10.2022 09:00",
    "EndDate": "05.10.2022 17:00",
    "Reason": "ŞEBEKE İŞLETMECİSİ",
    "District": "BAYRAKLI",
    "Region": "OSMANGAZİ MAHALLESİ,YAVUZ CADDESİ,591,592 SOKAKLAR VE CİVARI"
  },
  {
    "StartDate": "05.10.2022 09:00",
    "EndDate": "05.10.2022 17:00",
    "Reason": "ŞEBEKE İŞLETMECİSİ",
    "District": "BAYRAKLI",
    "Region": "ZEYTİNLİK MAHALLESİ,592/1,592/11,592/12 592/10 - 592/9 - 592/6 -592/2 - 592/3 - 592/8 SOKAKLAR VE CİVARI"
  }
]
```

