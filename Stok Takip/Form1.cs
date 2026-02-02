using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SPMU3G3;Initial Catalog=StokTakip;Integrated Security=True");
        public string kullaniciAdi { get; set; }
        public string KullaniciTuru { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Temizle()
        {
            txtStokKod.Text = "";
            txtStokAd.Text = "";
            txtKalanMiktar.Text = "";
            cmbKategoriSec.SelectedIndex = -1;  
            txtSatisFiyati.Text = "";
            txtAlisFiyati.Text = "";
        }
        private void Yenile()
        {
            if (KullaniciTuru == "Admin")
            {
                button2.Visible = true;
                baglanti.Open();
                string Select = "Select s1.StokKodu As [Ürün Kodu], s1.StokAdi As [Ürün Adı], s1.KalanMiktar As [Kalan Miktar], s1.AlisFiyati As [Alış Fiyatı], s1.SatisFiyati As [Fiyatı],s1.KategoriNo As [Kategori No],s2.IslemTarihi As [İşlem Tarihi],s2.Kar From StokTabloSatici s1 inner join SatisTablo s2 on s1.StokKodu = s2.StokKodu";
                SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
                DataTable df = new DataTable();
                da.Fill(df);
                dataGridView1.DataSource = df;
                baglanti.Close();
            }
            else if (KullaniciTuru == "Satıcı")
            {
                button2.Visible = true;
                baglanti.Open();
                string Select = "Select StokKodu As [Ürün Kodu],StokAdi As [Ürün Adı],KalanMiktar As [Kalan Miktar],AlisFiyati As [Alış Fiyatı],SatisFiyati As Fiyatı,KategoriNo As [Kategori No] From StokTabloSatici";
                SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
                DataTable df = new DataTable();
                da.Fill(df);
                dataGridView1.DataSource = df;
                baglanti.Close();
            }
            else if (KullaniciTuru == "Müşteri")
            {
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label6.Visible = false;
                txtAlisFiyati.Visible = false;

                baglanti.Open();
                string Select = "Select StokKodu As [Ürün Kodu],StokAdi As [Ürün Adı],KalanMiktar As [Kalan Miktar],SatisFiyati As Fiyatı,KategoriNo As [Kategori No] From StokTabloSatici";
                SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
                DataTable df = new DataTable();
                da.Fill(df);
                dataGridView1.DataSource = df;
                baglanti.Close();
            }
            FormatDataGridView();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            lblKisi.Text = kullaniciAdi;
            lblKisiTuru.Text = KullaniciTuru;

            if (KullaniciTuru == "Satıcı" || KullaniciTuru == "Admin")
            {
                buttonSatısYap.Text = "Satış Yap";
            }
            else if (KullaniciTuru == "Müşteri")
            {
                buttonSatısYap.Text = "Satın Al";
            }

            Yenile();
            KategorileriYukle();
            KategorileriComboBoxaYukle();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtStokKod.Text = row.Cells["Ürün Kodu"].Value?.ToString();
                txtStokAd.Text = row.Cells["Ürün Adı"].Value?.ToString();
                txtKalanMiktar.Text = row.Cells["Kalan Miktar"].Value?.ToString();

                // Kategori combobox'u güncelle
                cmbKategoriSec.SelectedValue = row.Cells["Kategori No"].Value;

                var fiyat = row.Cells["Fiyatı"].Value;
                txtSatisFiyati.Text = fiyat != null ? Convert.ToDecimal(fiyat).ToString("N2") : "";

                if (KullaniciTuru != "Müşteri" && row.Cells["Alış Fiyatı"] != null)
                {
                    var alis = row.Cells["Alış Fiyatı"].Value;
                    txtAlisFiyati.Text = alis != null ? Convert.ToDecimal(alis).ToString("N2") : "";
                }
                else
                {
                    txtAlisFiyati.Text = "";
                }
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (KullaniciTuru == "Müşteri")
            {
                // Müşteri için Satın Al işlemleri
                MusteriSatinAl();
            }
            else if (KullaniciTuru == "Satıcı" || KullaniciTuru == "Admin")
            {
                // Satıcı için Satış Yap işlemleri
                SaticiSatisYap();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (txtStokAd.Text == "" || txtKalanMiktar.Text == "" || cmbKategoriSec.SelectedValue == null || txtSatisFiyati.Text == "" || txtAlisFiyati.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Değerleri Eksiksiz Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    var culture = new System.Globalization.CultureInfo("en-US");

                    string stokAd = txtStokAd.Text;
                    int kalanMiktar = int.Parse(txtKalanMiktar.Text);
                    int kategoriNo = Convert.ToInt32(cmbKategoriSec.SelectedValue); // ComboBox'tan kategori no alıyoruz
                    float satisFiyati = float.Parse(txtSatisFiyati.Text, culture);
                    float alisFiyati = float.Parse(txtAlisFiyati.Text, culture);

                    baglanti.Open();
                    string islem5 = "INSERT INTO StokTabloSatici (StokAdi, KalanMiktar, KategoriNo, SatisFiyati, AlisFiyati, EklenmeTarihi) VALUES (@a1, @a2, @a3, @a4, @a5, @a6)";
                    SqlCommand komut5 = new SqlCommand(islem5, baglanti);
                    komut5.Parameters.AddWithValue("@a1", stokAd);
                    komut5.Parameters.AddWithValue("@a2", kalanMiktar);
                    komut5.Parameters.AddWithValue("@a3", kategoriNo);
                    komut5.Parameters.AddWithValue("@a4", satisFiyati);
                    komut5.Parameters.AddWithValue("@a5", alisFiyati);
                    komut5.Parameters.AddWithValue("@a6", DateTime.Now); // Ürün ekleme tarihi

                    komut5.ExecuteNonQuery();

                    MessageBox.Show(stokAd + " stoklara eklenmiştir.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    Yenile();
                    Temizle();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Fiyat veya miktar alanlarına geçerli sayı girin. Örn: 123.45", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (txtStokAd.Text == "" || txtKalanMiktar.Text == "" || cmbKategoriSec.SelectedValue == null || txtSatisFiyati.Text == "" || txtAlisFiyati.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Değerleri Eksiksiz Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    var culture = new System.Globalization.CultureInfo("en-US");

                    string stokAdi = txtStokAd.Text;
                    int kalanMiktar = int.Parse(txtKalanMiktar.Text);
                    float alisFiyati = float.Parse(txtAlisFiyati.Text, culture);
                    float satisFiyati = float.Parse(txtSatisFiyati.Text, culture);
                    int kategoriNo = Convert.ToInt32(cmbKategoriSec.SelectedValue); // Combobox'tan kategori no alıyoruz
                    string stokKodu = txtStokKod.Text;

                    baglanti.Open();
                    string islem7 = "UPDATE StokTabloSatici SET StokAdi = @a1, KalanMiktar = @a2, AlisFiyati = @a3, SatisFiyati = @a4, KategoriNo = @a5 WHERE StokKodu = @kod";

                    SqlCommand komut7 = new SqlCommand(islem7, baglanti);
                    komut7.Parameters.AddWithValue("@a1", stokAdi);
                    komut7.Parameters.AddWithValue("@a2", kalanMiktar);
                    komut7.Parameters.AddWithValue("@a3", alisFiyati);
                    komut7.Parameters.AddWithValue("@a4", satisFiyati);
                    komut7.Parameters.AddWithValue("@a5", kategoriNo);
                    komut7.Parameters.AddWithValue("@kod", stokKodu);

                    komut7.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show(stokAdi + " ürünü güncellenmiştir.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Yenile();
                    Temizle();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lütfen geçerli sayı girin. Örn: 123.45", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (txtStokKod.Text == "")
            {
                MessageBox.Show("Lütfen Ürün Kodu Değerini Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();

                string islem9 = "Delete From StokTabloSatici where StokKodu = '" + txtStokKod.Text + "'";
                SqlCommand komut9 = new SqlCommand(islem9, baglanti);
                komut9.ExecuteNonQuery();
                MessageBox.Show(txtStokAd.Text + "  Ürünü Başarıyla Silindi.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);


                baglanti.Close();
                Yenile();
                Temizle();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istatistikForm frm = new istatistikForm();
            frm.AnaForm = this;  // Form1 referansını gönderiyoruz!
            frm.Show();
            this.Hide();
        }

        private void FormatDataGridView()
        {
            // Alış Fiyatı sütunu varsa
            if (dataGridView1.Columns.Contains("Alış Fiyatı"))
            {
                dataGridView1.Columns["Alış Fiyatı"].DefaultCellStyle.Format = "N2"; // 1.000,00
            }

            // Satış Fiyatı sütunu varsa (bazı yerde sadece "Fiyatı" diye geçiyor)
            if (dataGridView1.Columns.Contains("Fiyatı"))
            {
                dataGridView1.Columns["Fiyatı"].DefaultCellStyle.Format = "N2";
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Oturumu kapatmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.Hide(); // Form1'i gizle
                Form2 girisFormu = new Form2();
                girisFormu.Show(); // Form2'yi göster
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void AramaYap()
        {
            if (radioStokKodu.Checked || radioUrunAdi.Checked)
            {
                string tip = radioStokKodu.Checked ? "StokKodu" : "StokAdi";

                string kategoriFiltre = "";

                if (checkBox1.Checked && comboBox1.SelectedValue != null)
                {
                    kategoriFiltre = $" AND KategoriNo = '{comboBox1.SelectedValue}'";
                }

                baglanti.Open();
                string query = $"SELECT StokKodu AS [Ürün Kodu], StokAdi AS [Ürün Adı], KalanMiktar AS [Kalan Miktar], AlisFiyati AS [Alış Fiyatı], SatisFiyati AS [Fiyatı], KategoriNo AS [Kategori No] " +
                               $"FROM StokTabloSatici " +
                               $"WHERE {tip} LIKE @deger {kategoriFiltre}";

                SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@deger", $"{txtAra.Text}%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

                FormatDataGridView();
            }
        }

        private void KategorileriYukle()
        {
            try
            {
                baglanti.Open();

                // DataSource ve Items temizle
                comboBox1.DataSource = null;
                comboBox1.Items.Clear();

                string query = "SELECT KategoriNo, Kategori FROM KategoriTablo";
                SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DisplayMember = "Kategori";
                comboBox1.ValueMember = "KategoriNo";
                comboBox1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori listesi yüklenirken hata: " + ex.Message);
                baglanti.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtStokKod.Text = row.Cells["Ürün Kodu"].Value?.ToString();
                txtStokAd.Text = row.Cells["Ürün Adı"].Value?.ToString();
                txtKalanMiktar.Text = row.Cells["Kalan Miktar"].Value?.ToString();

                // Kategori No combobox'ı
                cmbKategoriSec.SelectedValue = row.Cells["Kategori No"].Value;

                // Satış Fiyatı
                var fiyat = row.Cells["Fiyatı"].Value;
                txtSatisFiyati.Text = fiyat != null ? Convert.ToDecimal(fiyat).ToString("N2") : "";

                // Alış Fiyatı (Müşteri değilse gösterir)
                if (KullaniciTuru != "Müşteri" && row.Cells["Alış Fiyatı"] != null)
                {
                    var alis = row.Cells["Alış Fiyatı"].Value;
                    txtAlisFiyati.Text = alis != null ? Convert.ToDecimal(alis).ToString("N2") : "";
                }
                else
                {
                    txtAlisFiyati.Text = "";
                }
            }
        }

        private void KategorileriComboBoxaYukle()
        {
            try
            {
                baglanti.Open();

                cmbKategoriSec.DataSource = null;
                cmbKategoriSec.Items.Clear();

                string query = "SELECT KategoriNo, Kategori FROM KategoriTablo";
                SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategoriSec.DisplayMember = "Kategori";     // Görünen isim
                cmbKategoriSec.ValueMember = "KategoriNo";     // Seçilen değer
                cmbKategoriSec.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori listesi yüklenirken hata: " + ex.Message);
                baglanti.Close();
            }
        }

        private void SaticiSatisYap()
        {
            if (txtStokKod.Text == "")
            {
                MessageBox.Show("Lütfen önce listeden satılacak ürünü seçiniz!", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialog = MessageBox.Show(txtStokAd.Text + " ürününü satacaksınız. Onaylıyor musunuz?", "Stok Takip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        // KalanMiktar kontrolü
                        baglanti.Open();
                        SqlCommand stokKontrol = new SqlCommand("SELECT KalanMiktar FROM StokTabloSatici WHERE StokKodu = @stokKodu", baglanti);
                        stokKontrol.Parameters.AddWithValue("@stokKodu", txtStokKod.Text);
                        int kalanMiktar = Convert.ToInt32(stokKontrol.ExecuteScalar());
                        baglanti.Close();

                        if (kalanMiktar > 0)
                        {
                            var culture = new System.Globalization.CultureInfo("en-US");

                            // Stoktan 1 adet düş
                            baglanti.Open();
                            SqlCommand komut3 = new SqlCommand("UPDATE StokTabloSatici SET KalanMiktar = KalanMiktar - 1 WHERE StokKodu = @stokKodu", baglanti);
                            komut3.Parameters.AddWithValue("@stokKodu", txtStokKod.Text);
                            komut3.ExecuteNonQuery();
                            baglanti.Close();

                            // Stok kodu ve alış fiyatı al
                            string koddd = "", alisss = "";
                            baglanti.Open();
                            SqlCommand ata = new SqlCommand("SELECT StokKodu, AlisFiyati FROM StokTabloSatici WHERE StokKodu = @stokKodu", baglanti);
                            ata.Parameters.AddWithValue("@stokKodu", txtStokKod.Text);
                            SqlDataReader oku22 = ata.ExecuteReader();
                            if (oku22.Read())
                            {
                                koddd = oku22["StokKodu"].ToString();
                                alisss = oku22["AlisFiyati"].ToString();
                            }
                            baglanti.Close();

                            txtAlisFiyati.Text = alisss;

                            // Satış kaydı ekle
                            var turkCulture = new CultureInfo("tr-TR");
                            double satisFiyati = double.Parse(txtSatisFiyati.Text, turkCulture);
                            double alisFiyati = double.Parse(alisss, turkCulture);
                            double kar = satisFiyati - alisFiyati;
                            int kalanUrun = kalanMiktar - 1;

                            baglanti.Open();
                            SqlCommand komut6 = new SqlCommand("INSERT INTO SatisTablo (IslemTarihi, SatisFiyati, Kar, KalanUrun, StokKodu) VALUES (@a1, @a2, @a3, @a4, @a5)", baglanti);
                            komut6.Parameters.AddWithValue("@a1", DateTime.Now);
                            komut6.Parameters.AddWithValue("@a2", satisFiyati);
                            komut6.Parameters.AddWithValue("@a3", kar);
                            komut6.Parameters.AddWithValue("@a4", kalanUrun);
                            komut6.Parameters.AddWithValue("@a5", koddd);
                            komut6.ExecuteNonQuery();
                            baglanti.Close();

                            // Kritik stok kontrolü
                            if (kalanUrun <= 5)
                            {
                                MessageBox.Show(txtStokAd.Text + " ürününden stoğunuz 5'in altına inmiştir.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            MessageBox.Show("Satış başarılı!", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Temizle();
                            Yenile();
                        }
                        else
                        {
                            MessageBox.Show("Stok yetersiz! Satış yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Lütfen fiyat alanlarına geçerli bir sayı girin. (örn. 123.45)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ürünü satmaktan vazgeçtiniz.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MusteriSatinAl()
        {
            if (txtStokKod.Text == "")
            {
                MessageBox.Show("Lütfen önce listeden satın alacağınız ürünü seçiniz!", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    // KalanMiktar kontrolü
                    baglanti.Open();
                    SqlCommand stokKontrol = new SqlCommand("SELECT KalanMiktar FROM StokTabloSatici WHERE StokKodu = @stokKodu", baglanti);
                    stokKontrol.Parameters.AddWithValue("@stokKodu", txtStokKod.Text);
                    int kalanMiktar = Convert.ToInt32(stokKontrol.ExecuteScalar());
                    baglanti.Close();

                    if (kalanMiktar > 0)
                    {
                        baglanti.Open();
                        SqlCommand komut3 = new SqlCommand("UPDATE StokTabloSatici SET KalanMiktar = KalanMiktar - 1 WHERE StokKodu = @stokKodu", baglanti);
                        komut3.Parameters.AddWithValue("@stokKodu", txtStokKod.Text);
                        komut3.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Satın alma başarılı!", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Temizle();
                        Yenile();
                    }
                    else
                    {
                        MessageBox.Show("Stok yetersiz! Satın alma yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }
        }
    }
}
