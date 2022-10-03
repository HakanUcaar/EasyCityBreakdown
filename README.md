# EasyCityBreakdown
Turkey city breakdowns and outages.

<details>
	<summary>Todo</summary>
 
  - [ ] JSON serialize
  - [ ] Nuget package
  - [ ] Web deploy(open api)
  - [ ] Add more city
    - [ ] Turkey
      - [ ] Adana
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
      - [ ] Gaziantep
      - [ ] Giresun
      - [ ] Gümüşhane
      - [ ] Hakkâri
      - [ ] Hatay
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
      - [ ] Kilis
      - [X] Kocaeli
      - [ ] Konya
      - [ ] Kütahya
      - [ ] Malatya
      - [X] Manisa
      - [ ] Mardin
      - [ ] Mersin
      - [X] Muğla
      - [ ] Muş
      - [ ] Nevşehir
      - [ ] Niğde
      - [ ] Ordu
      - [ ] Osmaniye
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
var city = CityBreakdown.TurkeyAdapter.FindCity(IpAddress.From(("xx.xxx.xxx.xx")));
Console.WriteLine(city);   

Output

İl : İstanbul - Plaka : 34 - lat/lng : 41,01 , 28,9603
```

``` csharp
var city = CityBreakdown.TurkeyAdapter.FindCity("İzmir");
Console.WriteLine(city);

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
