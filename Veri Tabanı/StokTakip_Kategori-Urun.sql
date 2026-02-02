INSERT INTO KategoriTablo (Kategori) VALUES 
('Elektronik'),
('Kýrtasiye'),
('Temizlik'),
('Gýda'),
('Giyim'),
('Ev Dekorasyon'),
('Spor Malzemeleri'),
('Bahçe Ürünleri'),
('Oyuncak'),
('Kozmetik');

-- Ürünleri ekleyelim (StokKodu yok)
INSERT INTO StokTabloSatici (StokAdi, KalanMiktar, AlisFiyati, SatisFiyati, KategoriNo, EklenmeTarihi)
VALUES
-- Elektronik
('Laptop', 120, 4000, 5000, 1, GETDATE()),
('Telefon', 150, 2000, 2500, 1, GETDATE()),
('Tablet', 130, 1500, 2000, 1, GETDATE()),
('Kamera', 140, 1000, 1500, 1, GETDATE()),
('Hoparlör', 160, 500, 800, 1, GETDATE()),
('Klavye', 170, 200, 300, 1, GETDATE()),
('Mouse', 180, 100, 200, 1, GETDATE()),
('Monitör', 190, 700, 900, 1, GETDATE()),
('Powerbank', 110, 150, 250, 1, GETDATE()),
('Akýllý Saat', 105, 600, 850, 1, GETDATE()),

-- Kýrtasiye
('Defter', 200, 5, 8, 2, GETDATE()),
('Kalem', 250, 1, 2, 2, GETDATE()),
('Silgi', 300, 0.5, 1, 2, GETDATE()),
('Cetvel', 220, 2, 3, 2, GETDATE()),
('Dosya', 230, 3, 5, 2, GETDATE()),
('Makas', 210, 4, 6, 2, GETDATE()),
('Yapýþtýrýcý', 240, 1.5, 2.5, 2, GETDATE()),
('Ders Kitabý', 190, 20, 30, 2, GETDATE()),
('Çizim Kalemi', 170, 10, 15, 2, GETDATE()),
('Ajanda', 160, 12, 20, 2, GETDATE()),

-- Temizlik
('Çamaþýr Suyu', 150, 8, 12, 3, GETDATE()),
('Yer Bezi', 140, 3, 5, 3, GETDATE()),
('Bulaþýk Deterjaný', 130, 7, 10, 3, GETDATE()),
('Cam Sil', 160, 6, 9, 3, GETDATE()),
('Tuvalet Kaðýdý', 170, 15, 20, 3, GETDATE()),
('Peçete', 180, 2, 3, 3, GETDATE()),
('Sývý Sabun', 200, 4, 6, 3, GETDATE()),
('Dezenfektan', 210, 10, 15, 3, GETDATE()),
('Çöp Torbasý', 120, 1, 2, 3, GETDATE()),
('Banyo Deterjaný', 115, 9, 13, 3, GETDATE()),

-- Gýda
('Makarna', 180, 2, 3, 4, GETDATE()),
('Pirinç', 160, 4, 6, 4, GETDATE()),
('Mercimek', 140, 3, 5, 4, GETDATE()),
('Þeker', 170, 5, 7, 4, GETDATE()),
('Tuz', 150, 1, 2, 4, GETDATE()),
('Zeytinyaðý', 120, 20, 30, 4, GETDATE()),
('Un', 190, 8, 12, 4, GETDATE()),
('Çay', 200, 15, 20, 4, GETDATE()),
('Kahve', 210, 18, 25, 4, GETDATE()),
('Bisküvi', 220, 3, 5, 4, GETDATE()),

-- Giyim
('Tiþört', 130, 30, 50, 5, GETDATE()),
('Pantolon', 140, 50, 80, 5, GETDATE()),
('Ceket', 150, 100, 150, 5, GETDATE()),
('Kazak', 160, 60, 90, 5, GETDATE()),
('Etek', 170, 40, 60, 5, GETDATE()),
('Gömlek', 180, 35, 55, 5, GETDATE()),
('Þapka', 120, 15, 25, 5, GETDATE()),
('Çorap', 200, 5, 8, 5, GETDATE()),
('Mont', 210, 120, 180, 5, GETDATE()),
('Ayakkabý', 220, 80, 120, 5, GETDATE()),

-- Ev Dekorasyon
('Vazo', 130, 25, 40, 6, GETDATE()),
('Mum', 140, 10, 15, 6, GETDATE()),
('Lamba', 150, 50, 75, 6, GETDATE()),
('Perde', 160, 80, 120, 6, GETDATE()),
('Halý', 170, 200, 300, 6, GETDATE()),
('Ayna', 180, 100, 150, 6, GETDATE()),
('Raf', 120, 60, 90, 6, GETDATE()),
('Kitaplýk', 200, 150, 220, 6, GETDATE()),
('Sandalye', 210, 70, 100, 6, GETDATE()),
('Masa', 220, 200, 300, 6, GETDATE()),

-- Spor Malzemeleri
('Futbol Topu', 150, 50, 80, 7, GETDATE()),
('Basketbol Topu', 160, 60, 90, 7, GETDATE()),
('Dumbell', 170, 100, 150, 7, GETDATE()),
('Koþu Bandý', 180, 3000, 4000, 7, GETDATE()),
('Bisiklet', 120, 1500, 2000, 7, GETDATE()),
('Yoga Matý', 130, 30, 50, 7, GETDATE()),
('Atlama Ýpi', 140, 10, 15, 7, GETDATE()),
('Aðýrlýk Seti', 190, 500, 750, 7, GETDATE()),
('Tenis Raketi', 200, 400, 600, 7, GETDATE()),
('Kondisyon Aleti', 210, 2000, 2500, 7, GETDATE()),

-- Bahçe Ürünleri
('Bahçe Makasý', 150, 20, 30, 8, GETDATE()),
('Sulama Kabý', 160, 15, 25, 8, GETDATE()),
('Çim Biçme Makinesi', 170, 800, 1200, 8, GETDATE()),
('Bahçe Hortumu', 180, 50, 70, 8, GETDATE()),
('Bahçe Sandalyesi', 190, 100, 150, 8, GETDATE()),
('Bahçe Masasý', 200, 200, 300, 8, GETDATE()),
('Toprak', 120, 10, 15, 8, GETDATE()),
('Saksý', 130, 5, 8, 8, GETDATE()),
('Çiçek', 140, 3, 5, 8, GETDATE()),
('Týrmýk', 160, 15, 25, 8, GETDATE()),

-- Oyuncak
('Lego Seti', 150, 100, 150, 9, GETDATE()),
('Puzzle', 160, 50, 80, 9, GETDATE()),
('Oyuncak Araba', 170, 30, 50, 9, GETDATE()),
('Bebek', 180, 40, 60, 9, GETDATE()),
('Peluþ Ayý', 190, 35, 55, 9, GETDATE()),
('Robot', 200, 120, 180, 9, GETDATE()),
('Kukla', 120, 20, 30, 9, GETDATE()),
('Masa Oyunu', 130, 80, 120, 9, GETDATE()),
('Kum Seti', 140, 15, 25, 9, GETDATE()),
('Top', 160, 10, 20, 9, GETDATE()),

-- Kozmetik
('Ruj', 130, 30, 50, 10, GETDATE()),
('Fondöten', 140, 40, 60, 10, GETDATE()),
('Maskara', 150, 20, 30, 10, GETDATE()),
('Allýk', 160, 25, 35, 10, GETDATE()),
('Nemlendirici', 170, 50, 70, 10, GETDATE()),
('Göz Kalemi', 180, 15, 25, 10, GETDATE()),
('Cilt Serumu', 120, 100, 150, 10, GETDATE()),
('Güneþ Kremi', 200, 70, 100, 10, GETDATE()),
('Parfüm', 210, 120, 180, 10, GETDATE()),
('El Kremi', 220, 10, 20, 10, GETDATE());

-- Stok negatife düþmesin diye
ALTER TABLE StokTabloSatici
ADD CONSTRAINT CHK_KalanMiktar_Pozitif CHECK (KalanMiktar >= 0);
