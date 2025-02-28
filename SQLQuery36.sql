CREATE TABLE Doktorlar (
    DoktorID INT PRIMARY KEY IDENTITY(1,1), -- Otomatik art��
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

CREATE TABLE Aral�klarveFiyatlar (
	vitaminIsmi VARCHAR(100) NOT NULL,
	Aralik VARCHAR(20) NOT NULL,
    Ilac VARCHAR(100) NOT NULL,
	Fiyat DECIMAL(10, 2) DEFAULT 0,
);

CREATE TABLE Sikayetler (
    SikayetID INT PRIMARY KEY,
    SikayetAdi VARCHAR(255) NOT NULL,
    UygunBolum VARCHAR(255) NOT NULL,
    Doktor VARCHAR(255)�NOT�NULL
);

CREATE TABLE Yetkili(
	YetkiliId int PRIMARY KEY,
	AdSoyad NVARCHAR(100) NOT NULL,
);

INSERT INTO Doktorlar (AdSoyad, UzmanlikAlani, Maas, Eposta, Telefon)
VALUES 
('Dr. Ahmet Y�lmaz', 'Kardiyoloji', 60000, 'ahmet.yilmaz@hastane.com', '555-1112222'),
('Dr. Emre Y�ld�z', 'Kardiyoloji', 65000, 'emre.yildiz@hastane.com', '555-5554444'),
('Dr. Engin �elik', 'Kardiyoloji', 70000, 'engin.celik@hastane.com', '555-1114444'),
('Dr. Serhat �im�ek', 'Kardiyoloji', 71000, 'serhat.simsek@hastane.com', '555-2226666'),
('Dr. �pek Karaca', 'Kardiyoloji', 68000, 'ipek.karaca@hastane.com', '555-0001111'),
('Dr. Zeynep �zt�rk', 'Kardiyoloji', 72000, 'zeynep.ozturk@hastane.com', '555-3332222'),
('Dr. Burak Eren', 'Kardiyoloji', 75000, 'burak.eren@hastane.com', '555-4447777'),
('Dr. Ay�e Kaya', 'Di� Hekimli�i', 62000, 'ayse.kaya@hastane.com', '555-3334444'),
('Dr. Mehmet Demir', 'Di� Hekimli�i', 63000, 'mehmet.demir@hastane.com', '555-5556666'),
('Dr. Okan G�ne�', 'Di� Hekimli�i', 63000, 'okan.gunes@hastane.com', '555-4445555'),
('Dr. Seda �zt�rk', 'Di� Hekimli�i', 60000, 'seda.ozturk@hastane.com', '555-6667777'),
('Dr. Yeliz Ak�n', 'Di� Hekimli�i', 60000, 'yeliz.akin@hastane.com', '555-8885555'),
('Dr. Canan Kara', 'Di� Hekimli�i', 65000, 'canan.kara@hastane.com', '555-7775555'),
('Dr. Kader �elik', 'Di� Hekimli�i', 67000, 'kader.celik@hastane.com', '555-1117777'),
('Dr. Zeynep �elik', '�ocuk Sa�l���', 65000, 'zeynep.celik@hastane.com', '555-7778888'),
('Dr. P�nar �ahin', '�ocuk Sa�l���', 64000, 'pinar.sahin@hastane.com', '555-2223333'),
('Dr. Meltem Aksoy', '�ocuk Sa�l���', 68000, 'meltem.aksoy@hastane.com', '555-3336666'),
('Dr. G�l Ay', '�ocuk Sa�l���', 67000, 'gul.ay@hastane.com', '555-4448888'),
('Dr. H�lya Erdem', '�ocuk Sa�l���', 69000, 'hulya.erdem@hastane.com', '555-5557777'),
('Dr. Levent Ayd�n', '�ocuk Sa�l���', 72000, 'levent.aydin@hastane.com', '555-1118888'),
('Dr. G�khan Y�lmaz', '�ocuk Sa�l���', 73000, 'gokhan.yilmaz@hastane.com', '555-2224444'),
('Dr. Fatih Aslan', 'Psikiyatri', 60000, 'fatih.aslan@hastane.com', '555-9990000'),
('Dr. Hakan Uzun', 'Psikiyatri', 62000, 'hakan.uzun@hastane.com', '555-8889999'),
('Dr. Burak Eren', 'Psikiyatri', 66000, 'burak.eren@hastane.com', '555-3335555'),
('Dr. Can �zer', 'Psikiyatri', 69000, 'can.ozer@hastane.com', '555-4446666'),
('Dr. G�l Ay', 'Psikiyatri', 72000, 'gul.ay@hastane.com', '555-0005555'),
('Dr. Serhat �im�ek', 'Psikiyatri', 75000, 'serhat.simsek@hastane.com', '555-3334444'),
('Dr. Ay�a Ko�', 'Psikiyatri', 74000, 'ayca.koc@hastane.com', '555-7778888'),
('Dr. Cansu Tekin', 'G�z Hastal�klar�', 62000, 'cansu.tekin@hastane.com', '555-1113333'),
('Dr. Nilay Demir', 'G�z Hastal�klar�', 62000, 'nilay.demir@hastane.com', '555-7774444'),
('Dr. Engin �elik', 'G�z Hastal�klar�', 65000, 'engin.celik@hastane.com', '555-2225555'),
('Dr. T�lay G�l', 'G�z Hastal�klar�', 67000, 'tulay.gul@hastane.com', '555-3332222'),
('Dr. Asuman Yal��n', 'G�z Hastal�klar�', 68000, 'asuman.yalcin@hastane.com', '555-4443333'),
('Dr. Ekin �zdemir', 'G�z Hastal�klar�', 69000, 'ekin.ozdemir@hastane.com', '555-5556666'),
('Dr. Derya �nal', 'G�z Hastal�klar�', 70000, 'derya.inal@hastane.com', '555-6667777'),
('Dr. Ay�e Nur Sava�', 'Kad�n Do�um ve Bebek', 75000, 'ayse.nur.savas@hastane.com', '555-1112233'),
('Dr. Murat Y�lmaz', 'Kad�n Do�um ve Bebek', 72000, 'murat.yilmaz@hastane.com', '555-4445566'),
('Dr. Selin Y�ld�z', 'Kad�n Do�um ve Bebek', 70000, 'selin.yildiz@hastane.com', '555-2223444'),
('Dr. Ebru G�l', 'Kad�n Do�um ve Bebek', 68000, 'ebru.gul@hastane.com', '555-3332255'),
('Dr. Zeynep Ayd�n', 'Kad�n Do�um ve Bebek', 72000, 'zeynep.aydin@hastane.com', '555-7774455'),
('Dr. Canan �zt�rk', 'Kad�n Do�um ve Bebek', 71000, 'canan.ozturk@hastane.com', '555-5554433'),
('Dr. G�lten Kara', 'Kad�n Do�um ve Bebek', 69000, 'gulten.kara@hastane.com', '555-1113322'),
('Dr. Aylin Demir', 'Genel Cerrahi', 73000, 'aylin.demir@hastane.com', '555-1111122'),
('Dr. Zeynep Aksoy', 'Genel Cerrahi', 71000, 'zeynep.aksoy@hastane.com', '555-3332233'),
('Dr. Serkan Kara', 'Genel Cerrahi', 70000, 'serkan.kara@hastane.com', '555-4445555'),
('Dr. Fatma Y�lmaz', 'Genel Cerrahi', 69000, 'fatma.yilmaz@hastane.com', '555-7776633'),
('Dr. Cevdet �elik', 'Genel Cerrahi', 68000, 'cevded.celik@hastane.com', '555-8887755'),
('Dr. Eda Kara', 'Genel Cerrahi', 74000, 'eda.kara@hastane.com', '555-2223334'),
('Dr. Emine Demir', 'Genel Cerrahi', 75000, 'emine.demir@hastane.com', '555-3334445');


INSERT INTO Hastalar (AdSoyad, Telefon, DogumTarihi, KanGrubu)
VALUES 
('Ali Can', '555-1234567', CONVERT(DATE, '1990-05-20', 120), 'A+'),
('Ay�e Y�lmaz', '555-2233445', CONVERT(DATE, '1984-03-05', 120), 'A+'),
('Mehmet �zdemir', '555-3344556', CONVERT(DATE, '1992-01-12', 120), 'A+'),
('Serkan Ta�', '555-4455667', CONVERT(DATE, '1990-07-08', 120), 'A+'),
('Zeynep Arslan', '555-5566778', CONVERT(DATE, '1988-12-24', 120), 'A+'),
('Murat �elik', '555-6677889', CONVERT(DATE, '1995-04-15', 120), 'A+'),
('Seda Tan', '555-7788990', CONVERT(DATE, '1991-09-20', 120), 'A+'),
('Emre K�l��', '555-1234567', CONVERT(DATE, '1985-11-03', 120), 'B+'),
('Hakan Y�ld�r�m', '555-2233445', CONVERT(DATE, '1987-08-17', 120), 'B+'),
('Murat Tan', '555-3344556', CONVERT(DATE, '1993-03-12', 120), 'B+'),
('Cansu Arslan', '555-4455667', CONVERT(DATE, '1990-02-01', 120), 'B+'),
('Selma Demircan', '555-5566778', CONVERT(DATE, '1980-05-10', 120), 'B+'),
('Kemal Demirta�', '555-6677889', CONVERT(DATE, '1986-07-23', 120), 'B+'),
('�brahim Y�ld�z', '555-7788990', CONVERT(DATE, '1992-05-18', 120), 'B+'),
('Ali �nal', '555-1234567', CONVERT(DATE, '1994-02-13', 120), '0+'),
('B��ra Demirta�', '555-2233445', CONVERT(DATE, '1989-06-10', 120), '0+'),
('Emine Demirta�', '555-3344556', CONVERT(DATE, '1987-09-14', 120), '0+'),
('R�za Ak', '555-4455667', CONVERT(DATE, '1993-01-22', 120), '0+'),
('Fatih K�l��', '555-5566778', CONVERT(DATE, '1995-08-19', 120), '0+'),
('Ayd�n Can', '555-6677889', CONVERT(DATE, '1992-12-07', 120), '0+'),
('�smail Tan', '555-7788990', CONVERT(DATE, '1988-10-25', 120), '0+'),
('Meryem Y�ld�z', '555-1234567', CONVERT(DATE, '1992-11-18', 120), 'AB+'),
('Cemre Y�ld�z', '555-2233445', CONVERT(DATE, '1991-04-30', 120), 'AB+'),
('Fatma �elik', '555-3344556', CONVERT(DATE, '1986-01-06', 120), 'AB+'),
('Serkan Ak', '555-4455667', CONVERT(DATE, '1984-06-22', 120), 'AB+'),
('Meltem K�l��', '555-5566778', CONVERT(DATE, '1990-02-14', 120), 'AB+'),
('Zeynep Aksoy', '555-6677889', CONVERT(DATE, '1985-11-25', 120), 'AB+'),
('B�lent Y�lmaz', '555-7788990', CONVERT(DATE, '1989-03-13', 120), 'AB+'),
('Emre Demirta�', '555-1234567', CONVERT(DATE, '1994-09-20', 120), 'A-'),
('H�seyin Y�lmaz', '555-2233445', CONVERT(DATE, '1987-12-16', 120), 'A-'),
('Nihal K�l��', '555-3344556', CONVERT(DATE, '1992-07-03', 120), 'A-'),
('Ahmet G�ler', '555-4455667', CONVERT(DATE, '1990-03-22', 120), 'A-'),
('Fatma Arslan', '555-5566778', CONVERT(DATE, '1995-10-11', 120), 'A-'),
('Ay�eg�l Ak', '555-6677889', CONVERT(DATE, '1989-08-09', 120), 'A-'),
('Murat Y�ld�z', '555-7788990', CONVERT(DATE, '1988-05-30', 120), 'A-'),
('Ahmet �elik', '555-1234567', CONVERT(DATE, '1991-11-22', 120), 'B-'),
('Seda Aksoy', '555-2233445', CONVERT(DATE, '1984-07-09', 120), 'B-'),
('�mer Y�lmaz', '555-3344556', CONVERT(DATE, '1990-06-15', 120), 'B-'),
('Tuba Y�ld�r�m', '555-4455667', CONVERT(DATE, '1986-09-20', 120), 'B-'),
('Ferhat Tan', '555-5566778', CONVERT(DATE, '1992-02-12', 120), 'B-'),
('Ay�e Ta�', '555-6677889', CONVERT(DATE, '1987-01-25', 120), 'B-'),
('Emine K�l��', '555-7788990', CONVERT(DATE, '1994-08-10', 120), 'B-'),
('Aylin Ak', '555-1234567', CONVERT(DATE, '1992-03-30', 120), 'AB-'),
('Hasan Y�ld�z', '555-2233445', CONVERT(DATE, '1985-05-12', 120), 'AB-'),
('Murat Arslan', '555-3344556', CONVERT(DATE, '1989-07-25', 120), 'AB-'),
('Feyza Demirta�', '555-4455667', CONVERT(DATE, '1993-12-10', 120), 'AB-'),
('Melis K�l��', '555-5566778', CONVERT(DATE, '1990-02-28', 120), 'AB-'),
('Cem Arslan', '555-6677889', CONVERT(DATE, '1987-10-01', 120), 'AB-'),
('B��ra Tan', '555-7788990', CONVERT(DATE, '1994-06-22', 120), 'AB-');

INSERT INTO Randevular (DoktorID, HastaID, RandevuTarihi, Sikayet)
VALUES 
(11, 1, '2024-12-19', 'Yirmilik di� �ekimi'),
(47, 2, '2024-12-13', 'Kafatas� �ekil bozuklu�u'),
(38, 3, '2024-12-20', 'Emzirme sorunlar�'),
(49, 4, '2024-12-15', 'Genel kontrol'),
(43, 5, '2024-12-12', 'Sin�zit'),
(48, 6, '2024-12-20', 'Dizde kire�lenme'),
(46, 7, '2024-12-18', 'Boyun d�zle�mesi'),
(12, 8, '2024-12-19', '��r�k di�'), 
(45, 9, '2024-12-20', 'Omurga ��kmas�'),
(2, 10, '2024-12-20', 'S�k s�k �ks�r�k'),
(2, 11, '2024-12-22', 'So�uk terleme'),
(2, 12, '2024-12-19', 'Ritim bozuklu�u'),
(2, 13, '2024-12-24', 'Solunum zorlu�u'),
(2, 14, '2024-12-25', '�dem'),
(36, 15, '2024-12-26', 'Regl d�zensizli�i'),
(42, 16, '2024-12-27', 'Yumurtal�k kisti'),
(41, 17, '2024-12-19', 'Menopoz belirtisi'),
(37, 18, '2024-12-29', 'Bebeklerde y�ksek ate�'),
(11, 19, '2024-12-30', 'Di� Beyazlatma'),
(39, 20, '2024-12-20', 'Pelvik a�r�'),
(38, 21, '2024-12-19', 'Gebelikte �i�lik'),
(1, 22, '2025-01-02', '��tahs�zl�k'),
(5, 23, '2025-01-03', 'Refl� (Mide yanmas�)'),
(7, 24, '2025-01-04', 'A��r� kilo kayb�'),
(3, 25, '2025-01-05', 'Mide bulant�s�'),
(2, 26, '2025-01-06', 'D��k�da kan olmas�'),
(6, 27, '2025-01-07', 'Karaci�er b�y�mesi'),
(4, 28, '2025-01-08', 'G�rtlakta �i�lik'),
(26, 29, '2025-01-09', 'Depresyon'),
(28, 30, '2025-01-10', 'Anksiyete'),
(23, 31, '2025-01-11', 'Panik atak'),
(24, 32, '2025-01-12', 'Alkol ba��ml�l���'),
(22, 33, '2025-01-13', '�ntihar d���ncesi'),
(25, 34, '2025-01-14', 'Fobiler'),
(27, 35, '2025-01-15', 'OKB'),
(19, 36, '2025-01-16', '��tah kayb�'),
(17, 37, '2025-01-17', 'Di� ��karmada zorluk'),
(21, 38, '2025-01-18', 'Kas ve b�y�me problemleri'),
(15, 39, '2025-01-19', 'Geli�me gerili�i'),
(18, 40, '2025-01-20', 'S�rekli �ks�r�k ya da hap��r�k'),
(20, 41, '2025-01-21', 'Israrla kusma'),
(16, 42, '2025-01-22', 'Kar�n a�r�s�'),
(34, 43, '2025-01-23', 'Bulan�k g�rme'),
(33, 44, '2025-01-24', 'G�zlerde ka��nt�'),
(35, 45, '2025-01-25', 'Lazer ameliyat�'),
(31, 46, '2025-01-26', 'Korneada opakl�k'),
(30, 47, '2025-01-27', 'G�z kapa�� d��mesi'),
(32, 48, '2025-01-28', 'Sar� nokta hastal��� belirtileri'),
(29, 49, '2025-01-29', 'Katarakt ameliyat�');

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
(1, 1, 11, 'Yirmilik di� �ekimi', 'Parol (A�r� kesici)',25),
(2, 2, 47, 'Kafatas� �ekil bozuklu�u', 'Calcimax D3 (Kalsiyum deste�i)',85),
(3, 3, 38, 'Emzirme sorunlar�', 'Motilium (S�t art�r�c� destek)',50),
(4, 4, 49, 'Genel kontrol', 'Multivitamin �urubu',70),
(5, 5, 43, 'Sin�zit', 'Aferin Sin�s',35),
(6, 6, 48, 'Dizde kire�lenme', 'Glukozamin (Kondroitin deste�i)',120),
(7, 7, 46, 'Boyun d�zle�mesi', 'Muscoflex (Kas gev�etici)',90),
(8, 8, 12, '��r�k di�', 'Klorhex (Antibakteriyel gargara)',45),
(9, 9, 45, 'Omurga ��kmas�', 'Dex-Forte (A�r� kesici/iltihap giderici)',95);


INSERT INTO Aral�klarveFiyatlar (vitaminIsmi, Aralik, Ilac, Fiyat)
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
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-dis-1.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 1;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-kafatasi-2.png', SINGLE_BLOB) AS image)
WHERE HastaID = 2;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-gogus-3.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 3;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-tum-vucut-4.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 4;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-kafatasi-5.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 5;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-diz-6.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 6;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-boyun-7.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 7;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-dis-8.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 8;

UPDATE Rontgen
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-omurga-9.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 9;


ALTER TABLE Tomografi
ADD images VARBINARY(MAX);

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-dis-1.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 1;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-kafatasi-2.png', SINGLE_BLOB) AS image)
WHERE HastaID = 2;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-gogus-3.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 3;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-tum-vucut-4.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 4;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-kafatasi-5.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 5;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\rontgen\rontgen-diz-6.jpg', SINGLE_BLOB) AS image)
WHERE HastaID = 6;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-boyun-7.png', SINGLE_BLOB) AS image)
WHERE HastaID = 7;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-dis-8.png', SINGLE_BLOB) AS image)
WHERE HastaID = 8;

UPDATE Tomografi
SET images = (SELECT * FROM OPENROWSET(BULK 'C:\Users\huawei\source\repos\HASTANEVER�TABANIPROJES�\tomografi\tomografi-omurga-9.jpg', SINGLE_BLOB) AS image)
WHERE�HastaID�=�9;



INSERT INTO Sikayetler (SikayetID, SikayetAdi, UygunBolum, Doktor)
VALUES
(1, 'Yirmilik di� �ekimi', 'Di� Hekimli�i', 'Dr. Seda �zt�rk'),
(2, 'Kafatas� �ekil bozuklu�u', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(3, 'Emzirme sorunlar�', 'Kad�n Do�um ve Bebek', 'Dr. Ebru G�l'),
(4, 'Genel kontrol', 'Genel Cerrahi', 'Dr. Zeynep Aksoy'),
(5, 'Sin�zit', 'Genel Cerrahi', 'Dr. Fatma Y�lmaz'),
(6, 'Dizde kire�lenme', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(7, 'Boyun d�zle�mesi', 'Genel Cerrahi', 'Dr. Aylin Demir'),
(8, '��r�k di�', 'Di� Hekimli�i', 'Dr. Mehmet Demir'),
(9, 'Omurga ��kmas�', 'Genel Cerrahi', 'Dr. Emine Demir'),
(10, 'S�k s�k �ks�r�k', 'Kardiyoloji', 'Dr. Ahmet Y�lmaz'),
(11, 'So�uk terleme', 'Kardiyoloji', 'Dr. Ahmet Y�lmaz'),
(12, 'Ritim bozuklu�u', 'Kardiyoloji', 'Dr. Ahmet Y�lmaz'),
(13, 'Solunum zorlu�u', 'Kardiyoloji', 'Dr. Ahmet Y�lmaz'),
(14, '�dem', 'Kardiyoloji', 'Dr. Ahmet Y�lmaz'),
(15, 'Regl d�zensizli�i', 'Kad�n Do�um ve Bebek', 'Dr. Ay�e Nur Sava�'),
(16, 'Yumurtal�k kisti', 'Kad�n Do�um ve Bebek', 'Dr. Selin Y�ld�z'),
(17, 'Menopoz belirtisi', 'Kad�n Do�um ve Bebek', 'Dr. Ebru G�l'),
(18, 'Bebeklerde y�ksek ate�', '�ocuk Sa�l���', 'Dr. P�nar �ahin'),
(19, 'Di� Beyazlatma', 'Di� Hekimli�i', 'Dr. Seda �zt�rk'),
(20, 'Pelvik a�r�', 'Kad�n Do�um ve Bebek', 'Dr. G�lten Kara'),
(21, 'Gebelikte �i�lik', 'Kad�n Do�um ve Bebek', 'Dr. Ay�e Nur Sava�'),
(22, '��tahs�zl�k', '�ocuk Sa�l���', 'Dr. Zeynep �elik'),
(23, 'Refl� (Mide yanmas�)', 'Genel Cerrahi', 'Dr. Serkan Kara'),
(24, 'A��r� kilo kayb�', 'Genel Cerrahi', 'Dr. Fatma Y�lmaz'),
(25, 'Mide bulant�s�', 'Genel Cerrahi', 'Dr. Eda Kara'),
(26, 'D��k�da kan olmas�', 'Genel Cerrahi', 'Dr. Zeynep Aksoy'),
(27, 'Karaci�er b�y�mesi', 'Genel Cerrahi', 'Dr. Fatma Y�lmaz'),
(28, 'G�rtlakta �i�lik', 'Genel Cerrahi', 'Dr. Aylin Demir'),
(29, 'Depresyon', 'Psikiyatri', 'Dr. Fatih Aslan'),
(30, 'Anksiyete', 'Psikiyatri', 'Dr. Hakan Uzun'),
(31, 'Panik atak', 'Psikiyatri', 'Dr. Burak Eren'),
(32, 'Alkol ba��ml�l���', 'Psikiyatri', 'Dr. G�l Ay'),
(33, '�ntihar d���ncesi', 'Psikiyatri', 'Dr. Serhat �im�ek'),
(34, 'Fobiler', 'Psikiyatri', 'Dr. Ay�a Ko�'),
(35, 'OKB', 'Psikiyatri', 'Dr. Serhat �im�ek'),
(36, '��tah kayb�', '�ocuk Sa�l���', 'Dr. G�khan Y�lmaz'),
(37, 'Di� ��karmada zorluk', '�ocuk Sa�l���', 'Dr. G�l Ay'),
(38, 'Kas ve b�y�me problemleri', '�ocuk Sa�l���', 'Dr. Levent Ayd�n'),
(39, 'Geli�me gerili�i', '�ocuk Sa�l���', 'Dr. P�nar �ahin'),
(40, 'S�rekli �ks�r�k ya da hap��r�k', '�ocuk Sa�l���', 'Dr. Meltem Aksoy'),
(41, 'Israrla kusma', '�ocuk Sa�l���', 'Dr. H�lya Erdem'),
(42, 'Kar�n a�r�s�', '�ocuk Sa�l���', 'Dr. Levent Ayd�n'),
(43, 'Bulan�k g�rme', 'G�z Hastal�klar�', 'Dr. Cansu Tekin'),
(44, 'G�zlerde ka��nt�', 'G�z Hastal�klar�', 'Dr. Nilay Demir'),
(45, 'Lazer ameliyat�', 'G�z Hastal�klar�', 'Dr. Engin �elik'),
(46, 'Korneada opakl�k', 'G�z Hastal�klar�', 'Dr. T�lay G�l'),
(47, 'G�z kapa�� d��mesi', 'G�z Hastal�klar�', 'Dr. Asuman Yal��n'),
(48, 'Sar� nokta hastal��� belirtileri', 'G�z Hastal�klar�', 'Dr. Ekin �zdemir'),
(49, 'Katarakt ameliyat�', 'G�z Hastal�klar�', 'Dr.�Derya��nal');

INSERT INTO Yetkili (YetkiliId, AdSoyad)
VALUES 
(53, 'Ahmet Y�lmaz'),
(34, 'Mehmet Demir'),
(55, 'Ay�e Kara'),
(61, 'Fatma �elik'),
(79,�'Ali�Can');


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
    FROM Aral�klarveFiyatlar
    WHERE vitaminIsmi = @vitaminIsmi;
END;




