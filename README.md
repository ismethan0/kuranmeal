# Kuran Meal Uygulaması

Bu proje, Kuran-ı Kerim ayetlerini farklı meal çevirileriyle birlikte okumak ve aramak için geliştirilmiş bir ASP.NET Core MVC web uygulamasıdır.

## 🚀 Özellikler

- **Ayet Okuma**: Sure ve ayet numarasına göre Kuran ayetlerini okuma
- **Çoklu Meal Desteği**: 13 farklı meal çevirisi ile ayet okuma
- **Gelişmiş Arama**: Kelime, cümle ve sure bazında arama yapabilme
- **Navigasyon**: Önceki/sonraki ayet ve sure geçişleri
- **Responsive Tasarım**: Mobil ve masaüstü uyumlu arayüz

## 📚 Desteklenen Mealler

- Diyanet İşleri Başkanlığı (Yeni)
- Diyanet İşleri Başkanlığı (Eski)
- Elmalılı Muhammed Hamdi Yazır (Yenilenmiş)
- Elmalılı Muhammed Hamdi Yazır (Orijinal)
- Yaşar Nuri Öztürk
- Süleymaniye Vakfı
- Edip Yüksel
- Muhammed Esed
- Yusuf Ali (İngilizce)
- Anadolu Türkçesi
- Anonim
- Azeri Türkçesi
- Arapça Metin

## 🛠️ Teknoloji Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Veritabanı**: SQL Server
- **ORM**: Entity Framework Core 8.0.4
- **UI Bileşenleri**: QuickGrid
- **Dinamik Sorgular**: System.Linq.Dynamic.Core

## 📋 Gereksinimler

- .NET 8.0 SDK
- SQL Server (LocalDB veya tam sürüm)
- Visual Studio 2022 veya Visual Studio Code

## ⚙️ Kurulum

1. **Projeyi klonlayın**
   ```bash
   git clone [repository-url]
   cd kuranmealuygulaması
   ```

2. **Bağımlılıkları yükleyin**
   ```bash
   dotnet restore
   ```

3. **Veritabanı bağlantısını yapılandırın**
   
   `appsettings.json` dosyasında connection string'i güncelleyin:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=KuranDB;Trusted_Connection=true;"
     }
   }
   ```

4. **Veritabanı migration'larını çalıştırın**
   ```bash
   dotnet ef database update
   ```

5. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

   Uygulama `https://localhost:5001` adresinde çalışacaktır.

## 🗂️ Proje Yapısı

```
kuranmealuygulaması/
├── Controllers/           # MVC Controller'ları
│   ├── HomeController.cs     # Ana sayfa ve genel işlemler
│   ├── Ayetler.cs           # Ayet okuma ve navigasyon
│   ├── SearchController.cs   # Arama işlemleri
│   └── KelimeDuzenleme.cs   # Metin düzenleme yardımcıları
├── Models/               # Veri modelleri ve Entity Framework context
│   ├── KuranContext.cs      # Ana veritabanı context'i
│   ├── AyetModel.cs         # Ayet görüntüleme modeli
│   ├── SearchViewModel.cs   # Arama modeli
│   └── [Meal Models]/       # Her meal için ayrı model sınıfları
├── Views/                # Razor view dosyaları
├── wwwroot/             # Statik dosyalar (CSS, JS, resimler)
└── appsettings.json     # Uygulama yapılandırması
```

## 🔍 Kullanım

### Ayet Okuma
- Ana sayfadan istediğiniz sureyi seçin
- Ayet numarasını girin veya sırayla okuyun
- Önceki/Sonraki butonları ile navigasyon yapın

### Arama Yapma
- Arama sayfasından meal türünü seçin
- Arama seçeneklerini belirleyin:
  - **Tüm Kelimeler**: Girilen tüm kelimeleri içeren ayetler
  - **Herhangi Bir Kelime**: Girilen kelimelerden en az birini içeren ayetler
  - **Tam Eşleşme**: Girilen ifadeyi tam olarak içeren ayetler
- Sure filtresi uygulayabilirsiniz

**Not**: Bu uygulama eğitim ve kişisel kullanım amaçlıdır. Meal çevirileri ilgili kaynaklardan alınmıştır.
