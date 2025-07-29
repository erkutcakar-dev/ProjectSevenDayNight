# 🌟 Project Seven Day Night

Modern ve dinamik bir web uygulaması - ASP.NET MVC ile geliştirilmiş çok dilli kurumsal web sitesi.

## 🚀 Özellikler

### ✨ Ana Özellikler
- **🌍 Çok Dilli Destek:** İngilizce ve Almanca dil desteği
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
│   ├── LifeSure-1.0.0/ # Main Theme Assets
│   │   └── img/        # Theme Images
│   ├── AiImages/        # AI Generated Images
│   └── EmployeeImages/  # Employee Photos
├── Scripts/             # JavaScript Files
├── Helpers/             # Utility Classes
└── App_GlobalResources/ # Localization Files
```

## 🖼️ Proje Görselleri

### 📸 LifeSure Theme Images (1-24)
1. **about-1.png** - Hakkımızda bölümü görseli
2. **bg-breadcrumb.jpg** - Breadcrumb arka plan görseli
3. **blog-1.png** - Blog görseli 1
4. **blog-2.png** - Blog görseli 2
5. **blog-3.png** - Blog görseli 3
6. **blog-4.png** - Blog görseli 4
7. **carousel-2.png** - Ana sayfa carousel görseli
8. **contact-img.png** - İletişim bölümü görseli
9. **instagram-footer-1.jpg** - Instagram footer görseli 1
10. **instagram-footer-2.jpg** - Instagram footer görseli 2
11. **instagram-footer-3.jpg** - Instagram footer görseli 3
12. **instagram-footer-4.jpg** - Instagram footer görseli 4
13. **instagram-footer-5.jpg** - Instagram footer görseli 5
14. **instagram-footer-6.jpg** - Instagram footer görseli 6
15. **team-1.jpg** - Ekip üyesi fotoğrafı 1
16. **team-2.jpg** - Ekip üyesi fotoğrafı 2
17. **team-3.jpg** - Ekip üyesi fotoğrafı 3
18. **team-4.jpg** - Ekip üyesi fotoğrafı 4
19. **testimonial-1.jpg** - Müşteri yorumu görseli 1
20. **testimonial-2.jpg** - Müşteri yorumu görseli 2
21. **testimonial-3.jpg** - Müşteri yorumu görseli 3
22. **erkut logo.png** - Proje logosu
23. **black-fotor-bg-remover-2025072912856.png** - Logo (BG removed)
24. **Thumbs.db** - Windows thumbnail cache

### 🤖 AI Generated Images (1-6)
1. **66212aca-1b0c-4caa-81db-9cd026bcf28b.png** - AI üretilen görsel 1
2. **79b0b1a2-a0d9-4b61-8bad-f3a5700f8b58.png** - AI üretilen görsel 2
3. **ba055c5b-a9bd-4447-9afc-37dd05162d18.png** - AI üretilen görsel 3
4. **dc8ec8e4-5c28-4527-b52e-ba15939c8c3f.png** - AI üretilen görsel 4
5. **e0b8a664-ebfa-44eb-9b67-7948c1d9163a.png** - AI üretilen görsel 5
6. **0bbeac5a-cf0a-4278-844c-5a414d08bdc3.png** - AI üretilen görsel 6

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
   git clone https://github.com/[erkutcakar-dev]/ProjectSevenDayNight.git
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

### Desteklenen Diller-
- 🇬🇧 **İngilizce**
- 🇩🇪 **Almanca**

### Çeviri Sistemi
- **Otomatik Çeviri:** Google Translate API entegrasyonu (İngilizce - Almanca) 
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


## 🙏 Teşekkürler

- **Bootstrap** - Responsive CSS framework
- **Font Awesome** - İkon kütüphanesi
- **RapidAPI** - ChatGPT API servisi
- **HuggingFace** - AI görsel üretimi
- **Google Translate** - Çeviri API'si

## 📞 İletişim

- **Email:** [erkutcakar@gmail.com]
- **GitHub:** [https://github.com/[erkutcakar-dev]]
- **LinkedIn:** [https://linkedin.com/in/[erkut-cakar]]

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın! 



<img width="1080" height="1743" alt="1" src="https://github.com/user-attachments/assets/1b69284e-eda5-4ce2-a58e-386608286a86" />

<img width="1080" height="1756" alt="2 " src="https://github.com/user-attachments/assets/cd4b3517-2869-48ba-a958-a6efaca1a2b0" />

<img width="1080" height="1745" alt="3" src="https://github.com/user-attachments/assets/9b6b2ceb-c13e-4f27-af44-ead69493ca63" />
<img width="1080" height="1748" alt="4" src="https://github.com/user-attachments/assets/1032d362-7230-4838-a963-6f5a86fc9e66" />
<img width="1920" height="602" alt="5" src="https://github.com/user-attachments/assets/e0db34c9-9abb-4dd3-a61c-c96ea6dd140a" />
<img width="1920" height="910" alt="6" src="https://github.com/user-attachments/assets/5bad7eb4-aeca-4a75-acbb-bbf663114cb7" />
<img width="1920" height="712" alt="7" src="https://github.com/user-attachments/assets/2a8137e7-3248-4576-be45-d05b33edcef5" />
<img width="1920" height="910" alt="18" src="https://github.com/user-attachments/assets/39f2cda0-1fdf-45e0-be15-984abd3676b5" />
<img width="1920" height="912" alt="17" src="https://github.com/user-attachments/assets/d1ad1419-6841-4571-9760-5e750053a8eb" />
<img width="1920" height="910" alt="16" src="https://github.com/user-attachments/assets/832e7fe9-350e-4b9e-bb26-2cca9ca89d8e" />
<img width="1920" height="912" alt="15" src="https://github.com/user-attachments/assets/bf363ded-6709-4860-93e1-4b8cc207a033" />
<img width="1920" height="1032" alt="14" src="https://github.com/user-attachments/assets/2e820f9d-22a5-4766-8bea-7ce4d2707abb" />
<img width="1920" height="1032" alt="13" src="https://github.com/user-attachments/assets/2038799f-0234-4ba8-abbd-1899372a93e8" />
<img width="1920" height="912" alt="12" src="https://github.com/user-attachments/assets/d3508041-856e-410d-987a-557b97b906c9" />
<img width="1920" height="1032" alt="11" src="https://github.com/user-attachments/assets/54ff1939-eea7-4034-89c5-3c320b2f3ed0" />
<img width="1310" height="569" alt="10" src="https://github.com/user-attachments/assets/261dd3de-3f55-4396-a48e-b0108f5bd81b" />
<img width="1920" height="915" alt="9" src="https://github.com/user-attachments/assets/94f568dc-b123-4fc3-8cc0-06a151112925" />
<img width="1920" height="909" alt="8" src="https://github.com/user-attachments/assets/d12ba806-3a7e-47cc-9de5-92fc0cb2f0e9" />
