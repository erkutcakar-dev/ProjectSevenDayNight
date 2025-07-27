-- Çeviri tabloları oluşturma script'i
-- Bu script mevcut tablolarınızı korur ve çeviri tabloları ekler

-- 1. About çeviri tablosu
CREATE TABLE AboutTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    AboutId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL, -- 'en', 'de'
    Title NVARCHAR(150),
    Subtitle NVARCHAR(150),
    Description NVARCHAR(MAX),
    BulletPoint1 NVARCHAR(100),
    BulletPoint2 NVARCHAR(100),
    BulletPoint3 NVARCHAR(100),
    ButtonText NVARCHAR(50),
    FOREIGN KEY (AboutId) REFERENCES About(AboutId),
    UNIQUE(AboutId, LanguageCode)
);

-- 2. Service çeviri tablosu
CREATE TABLE ServiceTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    ServiceId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    Title NVARCHAR(200),
    Subtitle NVARCHAR(200),
    CardTitle NVARCHAR(200),
    CardDescription NVARCHAR(MAX),
    FOREIGN KEY (ServiceId) REFERENCES Service(ServiceId),
    UNIQUE(ServiceId, LanguageCode)
);

-- 3. Employee çeviri tablosu
CREATE TABLE EmployeeTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    Title NVARCHAR(200),
    Subtitle NVARCHAR(200),
    NameSurname NVARCHAR(200),
    Job NVARCHAR(200),
    FOREIGN KEY (EmployeeId) REFERENCES Employee(EmployeeId),
    UNIQUE(EmployeeId, LanguageCode)
);

-- 4. FAQ çeviri tablosu
CREATE TABLE FaqTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    FaqId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    Title NVARCHAR(200),
    Subtitle NVARCHAR(200),
    Question NVARCHAR(MAX),
    Answer NVARCHAR(MAX),
    FOREIGN KEY (FaqId) REFERENCES Faq(FaqId),
    UNIQUE(FaqId, LanguageCode)
);

-- 5. Feature çeviri tablosu
CREATE TABLE FeatureTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    FeatureId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    Title NVARCHAR(200),
    Subtitle NVARCHAR(200),
    FOREIGN KEY (FeatureId) REFERENCES Feature(FeatureId),
    UNIQUE(FeatureId, LanguageCode)
);

-- 6. Category çeviri tablosu
CREATE TABLE CategoryTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    CategoryName NVARCHAR(50),
    FOREIGN KEY (CategoryId) REFERENCES TblCategory(CategoryId),
    UNIQUE(CategoryId, LanguageCode)
);

-- 7. Product çeviri tablosu
CREATE TABLE ProductTranslations (
    TranslationId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    LanguageCode NVARCHAR(5) NOT NULL,
    ProductName NVARCHAR(50),
    FOREIGN KEY (ProductId) REFERENCES TblProduct(ProductId),
    UNIQUE(ProductId, LanguageCode)
);

-- Örnek veriler ekleme (About tablosu için)
-- Önce About tablosunda veri olduğunu varsayalım
-- INSERT INTO AboutTranslations (AboutId, LanguageCode, Title, Subtitle, Description, BulletPoint1, BulletPoint2, BulletPoint3, ButtonText)
-- VALUES 
-- (1, 'de', 'Über uns', 'Wir sind hier, um Ihnen beim Aufbau Ihres Traums zu helfen', 'Professionelle Dienstleistungen für Ihr Unternehmen', 'Professionelles Team', 'Qualitätsservice', '24/7 Support', 'Mehr lesen');

-- Service tablosu için örnek
-- INSERT INTO ServiceTranslations (ServiceId, LanguageCode, Title, Subtitle, CardTitle, CardDescription)
-- VALUES 
-- (1, 'de', 'Unsere Dienstleistungen', 'Professionelle Lösungen für Ihr Unternehmen', 'Webentwicklung', 'Moderne und responsive Webanwendungen');

-- Employee tablosu için örnek
-- INSERT INTO EmployeeTranslations (EmployeeId, LanguageCode, Title, Subtitle, NameSurname, Job)
-- VALUES 
-- (1, 'de', 'Unser Team', 'Erfahrene Fachleute', 'Max Mustermann', 'Geschäftsführer');

-- FAQ tablosu için örnek
-- INSERT INTO FaqTranslations (FaqId, LanguageCode, Title, Subtitle, Question, Answer)
-- VALUES 
-- (1, 'de', 'Häufig gestellte Fragen', 'Finden Sie Antworten auf Ihre Fragen', 'Welche Dienstleistungen bieten Sie an?', 'Wir bieten umfassende IT-Dienstleistungen an');

-- Category tablosu için örnek
-- INSERT INTO CategoryTranslations (CategoryId, LanguageCode, CategoryName)
-- VALUES 
-- (1, 'de', 'Elektronik');

-- Product tablosu için örnek
-- INSERT INTO ProductTranslations (ProductId, LanguageCode, ProductName)
-- VALUES 
-- (1, 'de', 'Smartphone'); 