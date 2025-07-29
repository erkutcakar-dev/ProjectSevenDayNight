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

<img width="1920" height="910" alt="18" src="https://github.com/user-attachments/assets/929e6f58-6360-453c-8266-7ce5284a57c7" />
<img width="1920" height="912" alt="17" src="https://github.com/user-attachments/assets/0ef4a880-d9f1-4f40-9bfe-5eb7482bd038" />
<img width="1920" height="910" alt="16" src="https://github.com/user-attachments/assets/7d4d8b5e-9afa-43eb-acf5-7675953e5c97" />
<img width="1920" height="912" alt="15" src="https://github.com/user-attachments/assets/74d03af0-cc62-4a48-9e3d-1d37b320356e" />
<img width="1920" height="1032" alt="14" src="https://github.com/user-attachments/assets/9f5dd058-4512-4aa0-ad6e-0556f5e2c9ba" />
<img width="1920" height="1032" alt="13" src="https://github.com/user-attachments/assets/b9896f47-14a0-4d41-ad68-7a0f5286c2cb" />
<img width="1920" height="912" alt="12" src="https://github.com/user-attachments/assets/cc07095e-a681-42a3-95dc-b887345cb96f" />
<img width="1920" height="1032" alt="11" src="https://github.com/user-attachments/assets/e8339a0d-0513-4c26-a26f-9575e50fd763" />
<img width="1310" height="569" alt="10" src="https://github.com/user-attachments/assets/cd3d16ed-d1df-4d73-9c8f-f241e91057b9" />
<img width="1920" height="915" alt="9" src="https://github.com/user-attachments/assets/6ef1e814-cbc0-4c1e-98af-16f1b3f712c4" />
<img width="1920" height="909" alt="8" src="https://github.com/user-attachments/assets/9c37ef4b-bf4e-44aa-b87d-35e483a0ecbe" />
<img width="1920" height="712" alt="7" src="https://github.com/user-attachments/assets/ff1fef89-7a73-4d91-abf1-d528272d82cb" />
<img width="1920" height="910" alt="6" src="https://github.com/user-attachments/assets/d4c53989-7c34-4fe8-8e7b-06c3501c93e7" />
<img width="1920" height="602" alt="5" src="https://github.com/user-attachments/assets/4259867d-65db-46d2-9fdd-3f9613d806a0" />
<img width="1080" height="1748" alt="4" src="https://github.com/user-attachments/assets/e0a39259-3cae-4072-9a3f-2717c23a3430" />
<img width="1080" height="1745" alt="3" src="https://github.com/user-attachments/assets/47962990-cd71-47fd-97b1-3f42d116f8a7" />
<img width="1080" height="1756" alt="2 " src="https://github.com/user-attachments/assets/5d4b672f-d693-48f4-a4e2-2f0a7c788677" />
<img width="1080" height="1743" alt="1" src="https://github.com/user-attachments/assets/97a8f640-f9e4-4703-ac25-8e1cd5d3ee68" />






