CREATE TABLE Doktorlar (
    DoktorID INT PRIMARY KEY IDENTITY(1,1), -- Otomatik artýþ
    AdSoyad VARCHAR(100) NOT NULL,
    UzmanlikAlani VARCHAR(100) NOT NULL,
    Maas DECIMAL(10, 2) NOT NULL,
    Eposta VARCHAR(100),
    Telefon VARCHAR(15)
);

CREATE TABLE Hastalar (
    HastaID INT PRIMARY KEY IDENTITY(1,1),
    AdSoyad VARCHAR(100) NOT NULL,
    Telefon VARCHAR(15),
    DogumTarihi DATE,
    KanGrubu VARCHAR(5)
);

SET DATEFORMAT YMD;

CREATE TABLE Randevular (
    RandevuId INT PRIMARY KEY IDENTITY,
    RandevuTarihi DATETIME,
    HastaID INT,
    DoktorID INT,
    Sikayet VARCHAR(255),
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID)
);

CREATE TABLE Tahlil (
    TahlilID INT PRIMARY KEY IDENTITY(1,1),
    DoktorID INT,
    HastaID INT,
    KanveIdrarTahlili BIT DEFAULT 0,
    Tomografi BIT DEFAULT 0,
    Rontgen BIT DEFAULT 0,
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID)
);

CREATE TABLE Ilac (
    IlacID INT PRIMARY KEY,
    HastaID INT NOT NULL,
    DoktorID INT NOT NULL,
    Sikayet VARCHAR(255) NOT NULL,
	Ilac VARCHAR(255) NOT NULL,
    IlacFiyati DECIMAL(10, 2) DEFAULT 0,
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID),
	FOREIGN KEY (Sikayet) REFERENCES Randevular(Sikayet)
);

CREATE TABLE Fatura (
    HastaID INT NOT NULL,
    TahlilID INT NOT NULL,
	Tutar FLOAT,
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (TahlilID) REFERENCES Tahlil(TahlilID)
);

CREATE TABLE KanVeIdrarTahlili (
	TahlilID INT NOT NULL,
    HastaID INT NOT NULL,
    DoktorID INT NOT NULL,
    Demir FLOAT,
    Magnezyum FLOAT,
    eVitamini FLOAT,
    dVitamini FLOAT,
    TahlilFiyati DECIMAL(10, 2) DEFAULT 0,
	FOREIGN KEY (TahlilID) REFERENCES Tahlil(TahlilID),
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID)
);

CREATE TABLE Tomografi (
	TahlilID INT NOT NULL,
    HastaID INT NOT NULL,
    DoktorID INT NOT NULL,
	TahlilFiyati DECIMAL(10, 2) DEFAULT 0,
	FOREIGN KEY (TahlilID) REFERENCES Tahlil(TahlilID),
    FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID)
);

CREATE TABLE Rontgen (
	TahlilID INT NOT NULL,
	HastaID INT NOT NULL,
    DoktorID INT NOT NULL,
	TahlilFiyati DECIMAL(10, 2) DEFAULT 0,
	FOREIGN KEY (TahlilID) REFERENCES Tahlil(TahlilID),
	FOREIGN KEY (HastaID) REFERENCES Hastalar(HastaID),
    FOREIGN KEY (DoktorID) REFERENCES Doktorlar(DoktorID)
);

CREATE TABLE AralýklarveFiyatlar (
	vitaminIsmi VARCHAR(100) NOT NULL,
	Aralik VARCHAR(20) NOT NULL,
    Ilac VARCHAR(100) NOT NULL,
	Fiyat DECIMAL(10, 2) DEFAULT 0,
);

CREATE TABLE Sikayetler (
    SikayetID INT PRIMARY KEY,
    SikayetAdi VARCHAR(255) NOT NULL,
    UygunBolum VARCHAR(255) NOT NULL,
    Doktor VARCHAR(255) NOT NULL
);

CREATE TABLE Yetkili(
	YetkiliId int PRIMARY KEY,
	AdSoyad NVARCHAR(100) NOT NULL,
);

INSERT INTO Doktorlar (AdSoyad, UzmanlikAlani, Maas, Eposta, Telefon)
VALUES 
('Dr. Ahmet Yýlmaz', 'Kardiyoloji', 60000, 'ahmet.yilmaz@hastane.com', '555-1112222'),
('Dr. Emre Yýldýz', 'Kardiyoloji', 65000, 'emre.yildiz@hastane.com', '555-5554444'),
('Dr. Engin Çelik', 'Kardiyoloji', 70000, 'engin.celik@hastane.com', '555-1114444'),
('Dr. Serhat Þimþek', 'Kardiyoloji', 71000, 'serhat.simsek@hastane.com', '555-2226666'),
('Dr. Ýpek Karaca', 'Kardiyoloji', 68000, 'ipek.karaca@hastane.com', '555-0001111'),
('Dr. Zeynep Öztürk', 'Kardiyoloji', 72000, 'zeynep.ozturk@hastane.com', '555-3332222'),
('Dr. Burak Eren', 'Kardiyoloji', 75000, 'burak.eren@hastane.com', '555-4447777'),
('Dr. Ayþe Kaya', 'Diþ Hekimliði', 62000, 'ayse.kaya@hastane.com', '555-3334444'),
('Dr. Mehmet Demir', 'Diþ Hekimliði', 63000, 'mehmet.demir@hastane.com', '555-5556666'),
('Dr. Okan Güneþ', 'Diþ Hekimliði', 63000, 'okan.gunes@hastane.com', '555-4445555'),
('Dr. Seda Öztürk', 'Diþ Hekimliði', 60000, 'seda.ozturk@hastane.com', '555-6667777'),
('Dr. Yeliz Akýn', 'Diþ Hekimliði', 60000, 'yeliz.akin@hastane.com', '555-8885555'),
('Dr. Canan Kara', 'Diþ Hekimliði', 65000, 'canan.kara@hastane.com', '555-7775555'),
('Dr. Kader Çelik', 'Diþ Hekimliði', 67000, 'kader.celik@hastane.com', '555-1117777'),
('Dr. Zeynep Çelik', 'Çocuk Saðlýðý', 65000, 'zeynep.celik@hastane.com', '555-7778888'),
('Dr. Pýnar Þahin', 'Çocuk Saðlýðý', 64000, 'pinar.sahin@hastane.com', '555-2223333'),
('Dr. Meltem Aksoy', 'Çocuk Saðlýðý', 68000, 'meltem.aksoy@hastane.com', '555-3336666'),
('Dr. Gül Ay', 'Çocuk Saðlýðý', 67000, 'gul.ay@hastane.com', '555-4448888'),
('Dr. Hülya Erdem', 'Çocuk Saðlýðý', 69000, 'hulya.erdem@hastane.com', '555-5557777'),
('Dr. Levent Aydýn', 'Çocuk Saðlýðý', 72000, 'levent.aydin@hastane.com', '555-1118888'),
('Dr. Gökhan Yýlmaz', 'Çocuk Saðlýðý', 73000, 'gokhan.yilmaz@hastane.com', '555-2224444'),
('Dr. Fatih Aslan', 'Psikiyatri', 60000, 'fatih.aslan@hastane.com', '555-9990000'),
('Dr. Hakan Uzun', 'Psikiyatri', 62000, 'hakan.uzun@hastane.com', '555-8889999'),
('Dr. Burak Eren', 'Psikiyatri', 66000, 'burak.eren@hastane.com', '555-3335555'),
('Dr. Can Özer', 'Psikiyatri', 69000, 'can.ozer@hastane.com', '555-4446666'),
('Dr. Gül Ay', 'Psikiyatri', 72000, 'gul.ay@hastane.com', '555-0005555'),
('Dr. Serhat Þimþek', 'Psikiyatri', 75000, 'serhat.simsek@hastane.com', '555-3334444'),
('Dr. Ayça Koç', 'Psikiyatri', 74000, 'ayca.koc@hastane.com', '555-7778888'),
('Dr. Cansu Tekin', 'Göz Hastalýklarý', 62000, 'cansu.tekin@hastane.com', '555-1113333'),
('Dr. Nilay Demir', 'Göz Hastalýklarý', 62000, 'nilay.demir@hastane.com', '555-7774444'),
('Dr. Engin Çelik', 'Göz Hastalýklarý', 65000, 'engin.celik@hastane.com', '555-2225555'),
('Dr. Tülay Gül', 'Göz Hastalýklarý', 67000, 'tulay.gul@hastane.com', '555-3332222'),
('Dr. Asuman Yalçýn', 'Göz Hastalýklarý', 68000, 'asuman.yalcin@hastane.com', '555-4443333'),
('Dr. Ekin Özdemir', 'Göz Hastalýklarý', 69000, 'ekin.ozdemir@hastane.com', '555-5556666'),
('Dr. Derya Ýnal', 'Göz Hastalýklarý', 70000, 'derya.inal@hastane.com', '555-6667777'),
('Dr. Ayþe Nur Savaþ', 'Kadýn Doðum ve Bebek', 75000, 'ayse.nur.savas@hastane.com', '555-1112233'),
('Dr. Murat Yýlmaz', 'Kadýn Doðum ve Bebek', 72000, 'murat.yilmaz@hastane.com', '555-4445566'),
('Dr. Selin Yýldýz', 'Kadýn Doðum ve Bebek', 70000, 'selin.yildiz@hastane.com', '555-2223444'),
('Dr. Ebru Gül', 'Kadýn Doðum ve Bebek', 68000, 'ebru.gul@hastane.com', '555-3332255'),
('Dr. Zeynep Aydýn', 'Kadýn Doðum ve Bebek', 72000, 'zeynep.aydin@hastane.com', '555-7774455'),
('Dr. Canan Öztürk', 'Kadýn Doðum ve Bebek', 71000, 'canan.ozturk@hastane.com', '555-5554433'),
('Dr. Gülten Kara', 'Kadýn Doðum ve Bebek', 69000, 'gulten.kara@hastane.com', '555-1113322'),
('Dr. Aylin Demir', 'Genel Cerrahi', 73000, 'aylin.demir@hastane.com', '555-1111122'),
('Dr. Zeynep Aksoy', 'Genel Cerrahi', 71000, 'zeynep.aksoy@hastane.com', '555-3332233'),
('Dr. Serkan Kara', 'Genel Cerrahi', 70000, 'serkan.kara@hastane.com', '555-4445555'),
('Dr. Fatma Yýlmaz', 'Genel Cerrahi', 69000, 'fatma.yilmaz@hastane.com', '555-7776633'),
('Dr. Cevdet Çelik', 'Genel Cerrahi', 68000, 'cevded.celik@hastane.com', '555-8887755'),
('Dr. Eda Kara', 'Genel Cerrahi', 74000, 'eda.kara@hastane.com', '555-2223334'),
('Dr. Emine Demir', 'Genel Cerrahi', 75000, 'emine.demir@hastane.com', '555-3334445');


INSERT INTO Hastalar (AdSoyad, Telefon, DogumTarihi, KanGrubu)
VALUES 
('Ali Can', '555-1234567', CONVERT(DATE, '1990-05-20', 120), 'A+'),
('Ayþe Yýlmaz', '555-2233445', CONVERT(DATE, '1984-03-05', 120), 'A+'),
('Mehmet Özdemir', '555-3344556', CONVERT(DATE, '1992-01-12', 120), 'A+'),
('Serkan Taþ', '555-4455667', CONVERT(DATE, '1990-07-08', 120), 'A+'),
('Zeynep Arslan', '555-5566778', CONVERT(DATE, '1988-12-24', 120), 'A+'),
('Murat Çelik', '555-6677889', CONVERT(DATE, '1995-04-15', 120), 'A+'),
('Seda Tan', '555-7788990', CONVERT(DATE, '1991-09-20', 120), 'A+'),
('Emre Kýlýç', '555-1234567', CONVERT(DATE, '1985-11-03', 120), 'B+'),
('Hakan Yýldýrým', '555-2233445', CONVERT(DATE, '1987-08-17', 120), 'B+'),
('Murat Tan', '555-3344556', CONVERT(DATE, '1993-03-12', 120), 'B+'),
('Cansu Arslan', '555-4455667', CONVERT(DATE, '1990-02-01', 120), 'B+'),
('Selma Demircan', '555-5566778', CONVERT(DATE, '1980-05-10', 120), 'B+'),
('Kemal Demirtaþ', '555-6677889', CONVERT(DATE, '1986-07-23', 120), 'B+'),
('Ýbrahim Yýldýz', '555-7788990', CONVERT(DATE, '1992-05-18', 120), 'B+'),
('Ali Ünal', '555-1234567', CONVERT(DATE, '1994-02-13', 120), '0+'),
('Büþra Demirtaþ', '555-2233445', CONVERT(DATE, '1989-06-10', 120), '0+'),
('Emine Demirtaþ', '555-3344556', CONVERT(DATE, '1987-09-14', 120), '0+'),
('Rýza Ak', '555-4455667', CONVERT(DATE, '1993-01-22', 120), '0+'),
('Fatih Kýlýç', '555-5566778', CONVERT(DATE, '1995-08-19', 120), '0+'),
('Aydýn Can', '555-6677889', CONVERT(DATE, '1992-12-07', 120), '0+'),
('Ýsmail Tan', '555-7788990', CONVERT(DATE, '1988-10-25', 120), '0+'),
('Meryem Yýldýz', '555-1234567', CONVERT(DATE, '1992-11-18', 120), 'AB+'),
('Cemre Yýldýz', '555-2233445', CONVERT(DATE, '1991-04-30', 120), 'AB+'),
('Fatma Çelik', '555-3344556', CONVERT(DATE, '1986-01-06', 120), 'AB+'),
('Serkan Ak', '555-4455667', CONVERT(DATE, '1984-06-22', 120), 'AB+'),
('Meltem Kýlýç', '555-5566778', CONVERT(DATE, '1990-02-14', 120), 'AB+'),
('Zeynep Aksoy', '555-6677889', CONVERT(DATE, '1985-11-25', 120), 'AB+'),
('Bülent Yýlmaz', '555-7788990', CONVERT(DATE, '1989-03-13', 120), 'AB+'),
('Emre Demirtaþ', '555-1234567', CONVERT(DATE, '1994-09-20', 120), 'A-'),
('Hüseyin Yýlmaz', '555-2233445', CONVERT(DATE, '1987-12-16', 120), 'A-'),
('Nihal Kýlýç', '555-3344556', CONVERT(DATE, '1992-07-03', 120), 'A-'),
('Ahmet Güler', '555-4455667', CONVERT(DATE, '1990-03-22', 120), 'A-'),
('Fatma Arslan', '555-5566778', CONVERT(DATE, '1995-10-11', 120), 'A-'),
('Ayþegül Ak', '555-6677889', CONVERT(DATE, '1989-08-09', 120), 'A-'),
('Murat Yýldýz', '555-7788990', CONVERT(DATE, '1988-05-30', 120), 'A-'),
('Ahmet Çelik', '555-1234567', CONVERT(DATE, '1991-11-22', 120), 'B-'),
('Seda Aksoy', '555-2233445', CONVERT(DATE, '1984-07-09', 120), 'B-'),
('Ömer Yýlmaz', '555-3344556', CONVERT(DATE, '1990-06-15', 120), 'B-'),
('Tuba Yýldýrým', '555-4455667', CONVERT(DATE, '1986-09-20', 120), 'B-'),
('Ferhat Tan', '555-5566778', CONVERT(DATE, '1992-02-12', 120), 'B-'),
('Ayþe Taþ', '555-6677889', CONVERT(DATE, '1987-01-25', 120), 'B-'),
('Emine Kýlýç', '555-7788990', CONVERT(DATE, '1994-08-10', 120), 'B-'),
('Aylin Ak', '555-1234567', CONVERT(DATE, '1992-03-30', 120), 'AB-'),
('Hasan Yýldýz', '555-2233445', CONVERT(DATE, '1985-05-12', 120), 'AB-'),
('Murat Arslan', '555-3344556', CONVERT(DATE, '1989-07-25', 120), 'AB-'),
('Feyza Demirtaþ', '555-4455667', CONVERT(DATE, '1993-12-10', 120), 'AB-'),
('Melis Kýlýç', '555-5566778', CONVERT(DATE, '1990-02-28', 120), 'AB-'),
('Cem Arslan', '555-6677889', CONVERT(DATE, '1987-10-01', 120), 'AB-'),
('Büþra Tan', '555-7788990', CONVERT(DATE, '1994-06-22', 120), 'AB-');

INSERT INTO Randevular (DoktorID, HastaID, RandevuTarihi, Sikayet)
VALUES 
(11, 1, '2024-12-19', 'Yirmilik diþ çekimi'),
(47, 2, '2024-12-13', 'Kafatasý þekil bozukluðu'),
(38, 3, '2024-12-20', 'Emzirme sorunlarý'),
(49, 4, '2024-12-15', 'Genel kontrol'),
(43, 5, '2024-12-12', 'Sinüzit'),
(48, 6, '2024-12-20', 'Dizde kireçlenme'),
(46, 7, '2024-12-18', 'Boyun düzleþmesi'),
(12, 8, '2024-12-19', 'Çürük diþ'), 
(45, 9, '2024-12-20', 'Omurga çýkmasý'),
(2, 10, '2024-12-20', 'Sýk sýk öksürük'),
(2, 11, '2024-12-22', 'Soðuk terleme'),
(2, 12, '2024-12-19', 'Ritim bozukluðu'),
(2, 13, '2024-12-24', 'Solunum zorluðu'),
(2, 14, '2024-12-25', 'Ödem'),
(36, 15, '2024-12-26', 'Regl düzensizliði'),
(42, 16, '2024-12-27', 'Yumurtalýk kisti'),
(41, 17, '2024-12-19', 'Menopoz belirtisi'),
(37, 18, '2024-12-29', 'Bebeklerde yüksek ateþ'),
(11, 19, '2024-12-30', 'Diþ Beyazlatma'),
(39, 20, '2024-12-20', 'Pelvik aðrý'),
(38, 21, '2024-12-19', 'Gebelikte þiþlik'),
(1, 22, '2025-01-02', 'Ýþtahsýzlýk'),
(5, 23, '2025-01-03', 'Reflü (Mide yanmasý)'),
(7, 24, '2025-01-04', 'Aþýrý kilo kaybý'),
(3, 25, '2025-01-05', 'Mide bulantýsý'),
(2, 26, '2025-01-06', 'Dýþkýda kan olmasý'),
(6, 27, '2025-01-07', 'Karaciðer büyümesi'),
(4, 28, '2025-01-08', 'Gýrtlakta þiþlik'),
(26, 29, '2025-01-09', 'Depresyon'),
(28, 30, '2025-01-10', 'Anksiyete'),
(23, 31, '2025-01-11', 'Panik atak'),
(24, 32, '2025-01-12', 'Alkol baðýmlýlýðý'),
(22, 33, '2025-01-13', 'Ýntihar düþüncesi'),
(25, 34, '2025-01-14', 'Fobiler'),
(27, 35, '2025-01-15', 'OKB'),
(19, 36, '2025-01-16', 'Ýþtah kaybý'),
(17, 37, '2025-01-17', 'Diþ çýkarmada zorluk'),
(21, 38, '2025-01-18', 'Kas ve büyüme problemleri'),
(15, 39, '2025-01-19', 'Geliþme geriliði'),
(18, 40, '2025-01-20', 'Sürekli öksürük ya da hapþýrýk'),
(20, 41, '2025-01-21', 'Israrla kusma'),
(16, 42, '2025-01-22', 'Karýn aðrýsý'),
(34, 43, '2025-01-23', 'Bulanýk görme'),
(33, 44, '2025-01-24', 'Gözlerde kaþýntý'),
(35, 45, '2025-01-25', 'Lazer ameliyatý'),
(31, 46, '2025-01-26', 'Korneada opaklýk'),
(30, 47, '2025-01-27', 'Göz kapaðý düþmesi'),
(32, 48, '2025-01-28', 'Sarý nokta hastalýðý belirtileri'),
(29, 49, '2025-01-29', 'Katarakt ameliyatý');

INSERT INTO Tahlil (DoktorID, HastaID, KanveIdrarTahlili, Tomografi, Rontgen)
VALUES 
(11, 1,  1, 1, 1),
(47, 2,  1, 1, 1),
(38, 3,  1, 1, 1),
(49, 4,  1, 1, 1),
(43, 5,  1, 1, 1),
(48, 6,  1, 1, 1),
(46, 7,  1, 1, 1),
(12, 8,  1, 1, 1),
(45, 9,  1, 1, 1),
(2, 10,  0, 0, 0),
(2, 11,  0, 0, 0),
(2, 12,  0, 0, 0),
(2, 13,  0, 0, 0),
(2, 14,  0, 0, 0),
(36, 15, 0, 0, 0),
(42, 16, 0, 0, 0),
(41, 17, 0, 0, 0),
(37, 18, 0, 0, 0),
(11, 19, 0, 0, 0),
(39, 20, 0, 0, 0),
(38, 21, 0, 0, 0),
(1, 22,  0, 0, 0),
(5, 23,  0, 0, 0),
(7, 24,  0, 0, 0),
(3, 25,  0, 0, 0),
(2, 26,  0, 0, 0),
(6, 27,  0, 0, 0),
(4, 28,  0, 0, 0),
(26, 29, 0, 0, 0),
(28, 30, 0, 0, 0),
(23, 31, 0, 0, 0),
(24, 32, 0, 0, 0),
(22, 33, 0, 0, 0),
(25, 34, 0, 0, 0),
(27, 35, 0, 0, 0),
(19, 36, 0, 0, 0),
(17, 37, 0, 0, 0),
(21, 38, 0, 0, 0),
(15, 39, 0, 0, 0),
(18, 40, 0, 0, 0),
(20, 41, 0, 0, 0),
(16, 42, 0, 0, 0),
(34, 43, 0, 0, 0),
(33, 44, 0, 0, 0),
(35, 45, 0, 0, 0),
(31, 46, 0, 0, 0),
(30, 47, 0, 0, 0),
(32, 48, 0, 0, 0),
(29, 49, 0, 0, 0);


INSERT INTO Ilac (IlacID, HastaID, DoktorID, Sikayet, Ilac, IlacFiyati)
VALUES
(1, 1, 11, 'Yirmilik diþ çekimi', 'Parol (Aðrý kesici)',25),
(2, 2, 47, 'Kafatasý þekil bozukluðu', 'Calcimax D3 (Kalsiyum desteði)',85),
(3, 3, 38, 'Emzirme sorunlarý', 'Motilium (Süt artýrýcý destek)',50),
(4, 4, 49, 'Genel kontrol', 'Multivitamin Þurubu',70),
(5, 5, 43, 'Sinüzit', 'Aferin Sinüs',35),
(6, 6, 48, 'Dizde kireçlenme', 'Glukozamin (Kondroitin desteði)',120),
(7, 7, 46, 'Boyun düzleþmesi', 'Muscoflex (Kas gevþetici)',90),
(8, 8, 12, 'Çürük diþ', 'Klorhex (Antibakteriyel gargara)',45),
(9, 9, 45, 'Omurga çýkmasý', 'Dex-Forte (Aðrý kesici/iltihap giderici)',95);


INSERT INTO AralýklarveFiyatlar (vitaminIsmi, Aralik, Ilac, Fiyat)
VALUES
('Demir', '50 - 65', 'Ferro Sanol Duodenal',125),
('Magnezyum', '1.7 - 2.3', 'Magne-B6',150),
('E Vitamini', '5 - 20', 'Evicap 400 mg',100),
('D Vitamini', '20 - 50', 'Devit-3 Damla',40);


INSERT INTO Fatura (HastaID, TahlilID, Tutar)
VALUES
(1, 1, 5900),
(2, 2, 5900),
(3, 3, 5990),
(4, 4, 6025),
(5, 5, 5965),
(6, 6, 6175),
(7, 7, 6090),
(8, 8, 5965),
(9, 9, 5990);


INSERT INTO KanVeIdrarTahlili (TahlilID, HastaID, DoktorID, Demir, Magnezyum, eVitamini, dVitamini, TahlilFiyati)
VALUES
(1, 1, 11, 55, 1.3, 15, 25, 2000),   -- 0 0 1 0       100
(2, 2, 47, 60, 1.8, 4, 35, 2000),   -- 0 0 1 0        100
(3, 3, 38, 44, 1.5, 13, 56, 2000),   --0 1 0 1        190
(4, 4, 49, 30, 1.9, 22, 28, 2000),   -- 1 0 1 0      225
(5, 5, 43, 73, 2.1, 17, 63, 2000),   -- 1 0 0 1      165
(6, 6, 48, 25, 2.5, 33, 41, 2000),  -- 1 1 1 0      375
(7, 7, 46, 55, 1.2, 24, 76, 2000),  -- 0 1 1 1      290
(8, 8, 12, 37, 1.8, 13, 19, 2000),  -- 1 0 0 1      165
(9, 9, 45, 52, 2.9, 14, 56, 2000);  -- 0 1 0 1      190


INSERT INTO Tomografi (TahlilID, HastaID, DoktorID, TahlilFiyati)
VALUES
(1, 1, 11, 1700),
(2, 2, 47, 1700),
(3, 3, 38, 1700),
(4, 4, 49, 1700),
(5, 5, 43, 1700),
(6, 6, 48, 1700),
(7, 7, 46, 1700),
(8, 8, 12, 1700),
(9, 9, 45, 1700);


INSERT INTO Rontgen (TahlilID, HastaID, DoktorID, TahlilFiyati)
VALUES
(1, 1, 11, 2100),
(2, 2, 47, 2100),
(3, 3, 38, 2100),
(4, 4, 49, 2100),
(5, 5, 43, 2100),
(6, 6, 48, 2100),
(7, 7, 46, 2100),
(8, 8, 12, 2100),
(9, 9, 45, 2100);


ALTER TABLE Rontgen
ADD images VARBINARY(MAX);

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-dis-1.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 1;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-kafatasi-2.png', SINGLE_BLOB) AS image)
WHERE HastaID = 2;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-gogus-3.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 3;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-tum-vucut-4.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 4;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-kafatasi-5.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 5;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-diz-6.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 6;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-boyun-7.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 7;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-dis-8.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 8;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-omurga-9.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 9;


ALTER TABLE Tomografi
ADD images VARBINARY(MAX);

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-dis-1.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 1;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-kafatasi-2.png', SINGLE_BLOB) AS image)
WHERE HastaID = 2;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-gogus-3.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 3;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-tum-vucut-4.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 4;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-kafatasi-5.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 5;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\rontgen\rontgen-diz-6.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 6;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-boyun-7.png', SINGLE_BLOB) AS image)
WHERE HastaID = 7;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-dis-8.png', SINGLE_BLOB) AS image)
WHERE HastaID = 8;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVERÝTABANIPROJESÝ\tomografi\tomografi-omurga-9.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 9;



INSERT INTO Sikayetler (SikayetID, SikayetAdi, UygunBolum, Doktor)
VALUES
(1, 'Yirmilik diþ çekimi', 'Diþ Hekimliði', 'Dr. Seda Öztürk'),
(2, 'Kafatasý þekil bozukluðu', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(3, 'Emzirme sorunlarý', 'Kadýn Doðum ve Bebek', 'Dr. Ebru Gül'),
(4, 'Genel kontrol', 'Genel Cerrahi', 'Dr. Zeynep Aksoy'),
(5, 'Sinüzit', 'Genel Cerrahi', 'Dr. Fatma Yýlmaz'),
(6, 'Dizde kireçlenme', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(7, 'Boyun düzleþmesi', 'Genel Cerrahi', 'Dr. Aylin Demir'),
(8, 'Çürük diþ', 'Diþ Hekimliði', 'Dr. Mehmet Demir'),
(9, 'Omurga çýkmasý', 'Genel Cerrahi', 'Dr. Emine Demir'),
(10, 'Sýk sýk öksürük', 'Kardiyoloji', 'Dr. Ahmet Yýlmaz'),
(11, 'Soðuk terleme', 'Kardiyoloji', 'Dr. Ahmet Yýlmaz'),
(12, 'Ritim bozukluðu', 'Kardiyoloji', 'Dr. Ahmet Yýlmaz'),
(13, 'Solunum zorluðu', 'Kardiyoloji', 'Dr. Ahmet Yýlmaz'),
(14, 'Ödem', 'Kardiyoloji', 'Dr. Ahmet Yýlmaz'),
(15, 'Regl düzensizliði', 'Kadýn Doðum ve Bebek', 'Dr. Ayþe Nur Savaþ'),
(16, 'Yumurtalýk kisti', 'Kadýn Doðum ve Bebek', 'Dr. Selin Yýldýz'),
(17, 'Menopoz belirtisi', 'Kadýn Doðum ve Bebek', 'Dr. Ebru Gül'),
(18, 'Bebeklerde yüksek ateþ', 'Çocuk Saðlýðý', 'Dr. Pýnar Þahin'),
(19, 'Diþ Beyazlatma', 'Diþ Hekimliði', 'Dr. Seda Öztürk'),
(20, 'Pelvik aðrý', 'Kadýn Doðum ve Bebek', 'Dr. Gülten Kara'),
(21, 'Gebelikte þiþlik', 'Kadýn Doðum ve Bebek', 'Dr. Ayþe Nur Savaþ'),
(22, 'Ýþtahsýzlýk', 'Çocuk Saðlýðý', 'Dr. Zeynep Çelik'),
(23, 'Reflü (Mide yanmasý)', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(24, 'Aþýrý kilo kaybý', 'Genel Cerrahi', 'Dr. Fatma Yýlmaz'),
(25, 'Mide bulantýsý', 'Genel Cerrahi', 'Dr. Eda Kara'),
(26, 'Dýþkýda kan olmasý', 'Genel Cerrahi', 'Dr. Zeynep Aksoy'),
(27, 'Karaciðer büyümesi', 'Genel Cerrahi', 'Dr. Fatma Yýlmaz'),
(28, 'Gýrtlakta þiþlik', 'Genel Cerrahi', 'Dr. Aylin Demir'),
(29, 'Depresyon', 'Psikiyatri', 'Dr. Fatih Aslan'),
(30, 'Anksiyete', 'Psikiyatri', 'Dr. Hakan Uzun'),
(31, 'Panik atak', 'Psikiyatri', 'Dr. Burak Eren'),
(32, 'Alkol baðýmlýlýðý', 'Psikiyatri', 'Dr. Gül Ay'),
(33, 'Ýntihar düþüncesi', 'Psikiyatri', 'Dr. Serhat Þimþek'),
(34, 'Fobiler', 'Psikiyatri', 'Dr. Ayça Koç'),
(35, 'OKB', 'Psikiyatri', 'Dr. Serhat Þimþek'),
(36, 'Ýþtah kaybý', 'Çocuk Saðlýðý', 'Dr. Gökhan Yýlmaz'),
(37, 'Diþ çýkarmada zorluk', 'Çocuk Saðlýðý', 'Dr. Gül Ay'),
(38, 'Kas ve büyüme problemleri', 'Çocuk Saðlýðý', 'Dr. Levent Aydýn'),
(39, 'Geliþme geriliði', 'Çocuk Saðlýðý', 'Dr. Pýnar Þahin'),
(40, 'Sürekli öksürük ya da hapþýrýk', 'Çocuk Saðlýðý', 'Dr. Meltem Aksoy'),
(41, 'Israrla kusma', 'Çocuk Saðlýðý', 'Dr. Hülya Erdem'),
(42, 'Karýn aðrýsý', 'Çocuk Saðlýðý', 'Dr. Levent Aydýn'),
(43, 'Bulanýk görme', 'Göz Hastalýklarý', 'Dr. Cansu Tekin'),
(44, 'Gözlerde kaþýntý', 'Göz Hastalýklarý', 'Dr. Nilay Demir'),
(45, 'Lazer ameliyatý', 'Göz Hastalýklarý', 'Dr. Engin Çelik'),
(46, 'Korneada opaklýk', 'Göz Hastalýklarý', 'Dr. Tülay Gül'),
(47, 'Göz kapaðý düþmesi', 'Göz Hastalýklarý', 'Dr. Asuman Yalçýn'),
(48, 'Sarý nokta hastalýðý belirtileri', 'Göz Hastalýklarý', 'Dr. Ekin Özdemir'),
(49, 'Katarakt ameliyatý', 'Göz Hastalýklarý', 'Dr. Derya Ýnal');

INSERT INTO Yetkili (YetkiliId, AdSoyad)
VALUES 
(53, 'Ahmet Yýlmaz'),
(34, 'Mehmet Demir'),
(55, 'Ayþe Kara'),
(61, 'Fatma Çelik'),
(79, 'Ali Can');


CREATE PROCEDURE GetIlaclarByHastaID
    @HastaID INT
AS
BEGIN
    SELECT Ilac, IlacFiyati
    FROM Ilac
    WHERE HastaID = @HastaID;
END;

CREATE PROCEDURE GetVitaminTahlilByHastaID
    @HastaID INT
AS
BEGIN
    SELECT Demir, Magnezyum, eVitamini, dVitamini
    FROM KanVeIdrarTahlili
    WHERE HastaID = @HastaID;
END;

CREATE PROCEDURE GetVitaminAralikByIsmi
    @vitaminIsmi VARCHAR(50)
AS
BEGIN
    SELECT Aralik
    FROM AralýklarveFiyatlar
    WHERE vitaminIsmi = @vitaminIsmi;
END;




