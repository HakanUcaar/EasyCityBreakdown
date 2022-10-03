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

### *Get Currencies
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
