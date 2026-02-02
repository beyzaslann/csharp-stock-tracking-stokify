# Stokify – Stock Tracking App (C# WinForms + SQL)


Stokify is a C# Windows Forms (WinForms) desktop application for basic stock tracking.  
It uses an SQL database and includes scripts to create tables and optionally insert sample category/product data.

### Key Features
- WinForms multi-form UI (Product/Category management, user-related screens, statistics screen)
- SQL database integration
- DataSet-based structure (multiple `StokTakipDataSet*` schemas)
- Simple desktop workflow for stock/category operations

### Project Structure
- `Stok Takip.sln` – Visual Studio solution
- `Stok Takip/` – Main WinForms project (`.csproj`, forms, datasets)
- `Veri Tabanì/` – Database scripts
  - `StokTakip_VeriTabanì.sql` – Creates DB schema (tables/columns)
  - `StokTakip_Kategori-Urun.sql` – Optional sample data (categories/products)
- `Rapor.docx` – Project report/documentation

### Database Setup (Import Order)
1. Run `Veri Tabanì/StokTakip_VeriTabanì.sql` first (creates tables and schema)
2. (Optional) Run `Veri Tabanì/StokTakip_Kategori-Urun.sql` (inserts example data)

### How to Run
1. Open `Stok Takip.sln` with Visual Studio
2. Restore NuGet packages (if prompted)
3. Press **Start (F5)**

### Notes
- `bin/`, `obj/`, `.vs/`, and `packages/` are ignored because they are build/cache folders.
- If the database connection string is defined in `App.config`, update it according to your local SQL setup.

---


Stokify, temel stok takibi işlemleri için geliştirilmiş C# Windows Forms (WinForms) masaüstü uygulamasıdır.  
SQL veritabanı kullanır ve tabloları oluşturmak ile isteğe bağlı örnek kategori/ürün verisi eklemek için scriptler içerir.

### Temel Özellikler
- Çok formlu WinForms arayüz (ürün/kategori, kullanıcı ekranları, istatistik ekranı)
- SQL veritabanı entegrasyonu
- DataSet tabanlı yapı (birden fazla `StokTakipDataSet*` şeması)
- Stok/kategori işlemleri için basit masaüstü akışı

### Proje Yapısı
- `Stok Takip.sln` – Visual Studio solution
- `Stok Takip/` – Ana WinForms proje klasörü (`.csproj`, formlar, dataset dosyaları)
- `Veri Tabanì/` – Veritabanı scriptleri
  - `StokTakip_VeriTabanì.sql` – Veritabanı şemasını oluşturur
  - `StokTakip_Kategori-Urun.sql` – (Opsiyonel) örnek veri ekler
- `Rapor.docx` – Proje raporu/döküman

### Veritabanı Kurulumu (Import Sırası)
1. Önce `Veri Tabanì/StokTakip_VeriTabanì.sql` çalıştırılır (tabloları oluşturur)
2. (İsteğe bağlı) `Veri Tabanì/StokTakip_Kategori-Urun.sql` çalıştırılır (örnek veri ekler)

### Çalıştırma
1. Visual Studio ile `Stok Takip.sln` dosyasını açın
2. Gerekirse NuGet paketlerini geri yükleyin (Restore)
3. **Başlat (F5)** ile çalıştırın

### Notlar
- `bin/`, `obj/`, `.vs/` ve `packages/` klasörleri derleme/cache olduğu için Git’e eklenmez.
- Bağlantı bilgisi `App.config` içinde ise kendi SQL ortamınıza göre güncelleyin.
