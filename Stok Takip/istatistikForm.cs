using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip
{
    public partial class istatistikForm : Form
    {
        public Form1 AnaForm { get; set; }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SPMU3G3;Initial Catalog=StokTakip;Integrated Security=True");
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
        public istatistikForm()
        {
            InitializeComponent();
        }

        private void istatistikForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Günlük satış ve kar
                baglanti.Open();
                SqlCommand komutSatis = new SqlCommand(@"
        SELECT COUNT(*) AS GunlukSatisSayisi,
               SUM(SatisFiyati) AS GunlukToplamKazanc,
               SUM(Kar) AS GunlukKar
        FROM SatisTablo
        WHERE CAST(IslemTarihi AS DATE) = CAST(GETDATE() AS DATE);", baglanti);

                using (SqlDataReader dr = komutSatis.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var turkCulture = new System.Globalization.CultureInfo("tr-TR");
                        lblGunlukKazanc.Text = string.Format(turkCulture, "{0:N2}", dr["GunlukToplamKazanc"]);
                        lblGunlukKar.Text = string.Format(turkCulture, "{0:N2}", dr["GunlukKar"]);
                        lblGunlukSatis.Text = Convert.ToInt32(dr["GunlukSatisSayisi"]).ToString("N0", turkCulture);
                    }
                }
                baglanti.Close();

                // Günlük kullanıcı kaydı
                baglanti.Open();
                SqlCommand komutKullanici = new SqlCommand(@"
        SELECT COUNT(*) AS GunlukKayitSayisi
        FROM Kullanicilar
        WHERE CAST(KayitTarihi AS DATE) = CAST(GETDATE() AS DATE);", baglanti);
                lblGunlukKayit.Text = komutKullanici.ExecuteScalar().ToString();
                baglanti.Close();

                // Günlük ürün girişi
                baglanti.Open();
                SqlCommand komutUrun = new SqlCommand(@"
        SELECT COUNT(*) AS GunlukEklenenUrun
        FROM StokTabloSatici
        WHERE CAST(EklenmeTarihi AS DATE) = CAST(GETDATE() AS DATE);", baglanti);
                lblGunlukUrun.Text = komutUrun.ExecuteScalar().ToString();
                baglanti.Close();

                // Bilgisayarın tarih ve saatini gösterelim
                lblTarihSaat.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                timer1.Interval = 1000; // 1 saniye
        timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
                baglanti.Close();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AnaForm.Show(); // Form1’i tekrar göster
            this.Close();   // istatistikForm’u kapat
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaForm.Show(); // Form1’i tekrar göster
            this.Close();   // istatistikForm’u kapat
        }

        private void btnPdfKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Dosyası|*.pdf",
                    Title = "PDF Olarak Kaydet",
                    FileName = "GunlukRapor.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Türkçe karakter destekli Arial fontu
                        string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        BaseFont bfArialUniCode = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font arialFont = new iTextSharp.text.Font(bfArialUniCode, 12, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font arialBoldFont = new iTextSharp.text.Font(bfArialUniCode, 16, iTextSharp.text.Font.BOLD);

                        // Başlık ve içerik
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Stok Takip Raporu", arialBoldFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Tarih: " + DateTime.Now.ToString("dd.MM.yyyy"), arialFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph(" "));

                        // Verileri float dönüşümüyle kontrol et
                        float gunlukSatis = 0;
                        float gunlukKazanc = 0;
                        float gunlukKar = 0;
                        int gunlukKayit = 0;
                        int gunlukUrun = 0;

                        float.TryParse(lblGunlukSatis.Text, out gunlukSatis);
                        float.TryParse(lblGunlukKazanc.Text, out gunlukKazanc);
                        float.TryParse(lblGunlukKar.Text, out gunlukKar);
                        int.TryParse(lblGunlukKayit.Text, out gunlukKayit);
                        int.TryParse(lblGunlukUrun.Text, out gunlukUrun);

                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Satış Sayısı: " + gunlukSatis.ToString("N2"), arialFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Toplam Kazanç: " + gunlukKazanc.ToString("N2") + " TL", arialFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Kâr: " + gunlukKar.ToString("N2") + " TL", arialFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Kullanıcı Kaydı: " + gunlukKayit.ToString(), arialFont));
                        pdfDoc.Add(new iTextSharp.text.Paragraph("Günlük Eklenen Ürün: " + gunlukUrun.ToString(), arialFont));

                        pdfDoc.Close();
                        stream.Close();

                        MessageBox.Show("PDF başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
