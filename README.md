# 🌟 Project Seven Day Night

Modern ve dinamik bir web uygulaması - ASP.NET MVC ile geliştirilmiş çok dilli kurumsal web sitesi.

## 🚀 Özellikler

### ✨ Ana Özellikler
- **🌍 Çok Dilli Destek:** Türkçe, İngilizce ve Almanca dil desteği
- **🤖 AI Entegrasyonu:** ChatGPT API ile otomatik FAQ oluşturma
- **🎨 AI Görsel Üretimi:** HuggingFace API ile dinamik görsel oluşturma
- **📱 Responsive Tasarım:** Bootstrap ile mobil uyumlu arayüz
- **🔧 Admin Paneli:** Kolay içerik yönetimi
- **📊 Dinamik İçerik:** Veritabanı tabanlı içerik yönetimi

### 🛠️ Teknolojiler
- **Backend:** ASP.NET MVC 5 (C#)
- **Veritabanı:** SQL Server (Entity Framework)
- **Frontend:** HTML5, CSS3, JavaScript, Bootstrap 5
- **AI API'ları:** 
  - RapidAPI (ChatGPT-42)
  - HuggingFace (FLUX.1-dev)
- **Çeviri:** Otomatik Google Translate entegrasyonu

## 📋 Proje Yapısı

```
ProjectSevenDayNight/
├── Controllers/          # MVC Controllers
├── Models/              # Data Models & ViewModels
├── Views/               # Razor Views
├── Content/             # Static Files (CSS, JS, Images)
├── Scripts/             # JavaScript Files
├── Helpers/             # Utility Classes
└── App_GlobalResources/ # Localization Files
```

## 🎯 Bölümler

### 🏠 Ana Sayfa
- **Hero Section:** Dinamik carousel
- **Hakkımızda:** Şirket bilgileri ve istatistikler
- **Hizmetler:** AI ile görsel üretimi destekli hizmet kartları
- **Özellikler:** Şirket özellikleri ve avantajları
- **Ekibimiz:** Çalışan profilleri ve fotoğrafları
- **SSS:** AI destekli soru-cevap sistemi
- **İletişim:** İletişim bilgileri ve form

### 🔧 Admin Paneli
- **Dashboard:** Genel yönetim arayüzü
- **İçerik Yönetimi:** Tüm bölümlerin CRUD işlemleri
- **Çeviri Yönetimi:** Otomatik çok dilli çeviri sistemi
- **Dosya Yönetimi:** Görsel yükleme ve yönetimi

## 🚀 Kurulum

### Gereksinimler
- Visual Studio 2019/2022
- .NET Framework 4.8
- SQL Server 2016+
- IIS Express veya IIS

### Adımlar
1. **Repository'yi klonlayın:**
   ```bash
   git clone https://github.com/[username]/ProjectSevenDayNight.git
   ```

2. **Veritabanını oluşturun:**
   - SQL Server'da yeni veritabanı oluşturun
   - `DayNightDb` adını verin
   - Connection string'i `Web.config`'de güncelleyin

3. **NuGet paketlerini yükleyin:**
   ```bash
   nuget restore
   ```

4. **API Anahtarlarını ayarlayın:**
   - RapidAPI anahtarınızı `FaqController.cs`'de güncelleyin
   - HuggingFace API anahtarınızı `ServiceController.cs`'de güncelleyin

5. **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```

## 🔧 Konfigürasyon

### API Anahtarları
```csharp
// FaqController.cs
string apiKey = "YOUR-RAPIDAPI-KEY";

// ServiceController.cs  
string apiKey = "YOUR-HUGGINGFACE-API-KEY";
```

### Veritabanı Bağlantısı
```xml
<!-- Web.config -->
<connectionStrings>
  <add name="DayNightDbEntities" 
       connectionString="Data Source=.;Initial Catalog=DayNightDb;Integrated Security=True" />
</connectionStrings>
```

## 📊 Veritabanı Yapısı

### Ana Tablolar
- **About:** Hakkımızda bilgileri
- **Service:** Hizmet bilgileri
- **Employee:** Çalışan profilleri
- **Faq:** Soru-cevap sistemi
- **Feature:** Özellik kartları
- **Contact:** İletişim bilgileri
- **CompanyStats:** Şirket istatistikleri
- **Crausel:** Ana sayfa carousel

### Çeviri Tabloları
- **AboutTranslations**
- **ServiceTranslations**
- **EmployeeTranslations**
- **FaqTranslations**
- **FeatureTranslations**
- **ContactTranslations**
- **CompanyStatsTranslations**
- **CrauselTranslations**

## 🤖 AI Özellikleri

### FAQ Oluşturma
- **API:** RapidAPI ChatGPT-42
- **Özellik:** Otomatik soru-cevap üretimi
- **Kullanım:** Admin panelinden tek tıkla FAQ oluşturma

### Görsel Üretimi
- **API:** HuggingFace FLUX.1-dev
- **Özellik:** Metin açıklamasından görsel oluşturma
- **Kullanım:** Hizmet kartları için dinamik görseller

## 🌍 Çok Dilli Destek

### Desteklenen Diller
- 🇹🇷 **Türkçe** (Varsayılan)
- 🇬🇧 **İngilizce**
- 🇩🇪 **Almanca**

### Çeviri Sistemi
- **Otomatik Çeviri:** Google Translate API entegrasyonu
- **Manuel Çeviri:** Admin panelinden düzenleme
- **Dinamik Dil Değiştirme:** URL tabanlı dil değiştirme

## 📱 Responsive Tasarım

### Bootstrap 5 Bileşenleri
- **Grid System:** Mobil-first yaklaşım
- **Components:** Accordion, Carousel, Cards
- **Utilities:** Spacing, Colors, Typography
- **JavaScript:** Collapse, Modal, Tooltip

## 🔒 Güvenlik

### Uygulanan Güvenlik Önlemleri
- **Input Validation:** Model validation
- **XSS Protection:** HTML encoding
- **CSRF Protection:** Anti-forgery tokens
- **File Upload Security:** Dosya türü kontrolü

## 📈 Performans

### Optimizasyonlar
- **Bundle & Minification:** CSS/JS sıkıştırma
- **Image Optimization:** Görsel optimizasyonu
- **Caching:** Browser ve server cache
- **Database Indexing:** Veritabanı indeksleme

## 🧪 Test

### Test Edilen Özellikler
- ✅ CRUD işlemleri
- ✅ API entegrasyonları
- ✅ Çok dilli sistem
- ✅ Responsive tasarım
- ✅ Dosya yükleme
- ✅ Form validasyonları

## 🤝 Katkıda Bulunma

1. **Fork yapın**
2. **Feature branch oluşturun** (`git checkout -b feature/AmazingFeature`)
3. **Değişikliklerinizi commit edin** (`git commit -m 'Add some AmazingFeature'`)
4. **Branch'inizi push edin** (`git push origin feature/AmazingFeature`)
5. **Pull Request oluşturun**

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

## 👨‍💻 Geliştirici

**Erkut** - [GitHub Profili](https://github.com/[username])

## 🙏 Teşekkürler

- **Bootstrap** - Responsive CSS framework
- **Font Awesome** - İkon kütüphanesi
- **RapidAPI** - ChatGPT API servisi
- **HuggingFace** - AI görsel üretimi
- **Google Translate** - Çeviri API'si

## 📞 İletişim

- **Email:** [email@example.com]
- **GitHub:** [https://github.com/[username]]
- **LinkedIn:** [https://linkedin.com/in/[username]]

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın! 