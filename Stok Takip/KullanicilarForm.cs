using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Takip
{
    public partial class KullanicilarForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SPMU3G3;Initial Catalog=StokTakip;Integrated Security=True");
        public KullanicilarForm()
        {
            InitializeComponent();
        }

        private void KullanicilarForm_Load(object sender, EventArgs e)
        {
            Yenile();
            KategoriTablosunuGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtKullaniciId.Text = dataGridView1.Rows[secilen].Cells["KullaniciId"].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells["Ad"].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells["Soyad"].Value.ToString();
            txtKullaniciTuru.Text = dataGridView1.Rows[secilen].Cells["KullaniciTuru"].Value.ToString();
            txtKullaniciAdi.Text = dataGridView1.Rows[secilen].Cells["KullaniciAdi"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[secilen].Cells["Email"].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells["Sifre"].Value.ToString();
            txtSirket.Text = dataGridView1.Rows[secilen].Cells["Sirket"].Value.ToString();

            if(dataGridView1.Rows[secilen].Cells["Cinsiyet"].Value.ToString() == "True")
            {
                radioErkek.Checked = true;
            }
            else
            {
                radioBayan.Checked = true;
            }
        }
        private void Yenile()
        {
            baglanti.Open();
            string Select = "Select * From Kullanicilar";
            SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
            DataTable df = new DataTable();
            da.Fill(df);

            df.Columns.Add("CinsiyetString", typeof(string));

            foreach (DataRow row in df.Rows)
            {
                if (row["Cinsiyet"] != DBNull.Value && (bool)row["Cinsiyet"])
                    row["CinsiyetString"] = "Erkek";
                else
                    row["CinsiyetString"] = "Kadın";
            }

            
            dataGridView1.DataSource = df;
            dataGridView1.Columns["Cinsiyet"].Visible = false; 
            dataGridView1.Columns["CinsiyetString"].HeaderText = "Cinsiyet"; 
            dataGridView1.Columns["CinsiyetString"].DisplayIndex = 3; 
            baglanti.Close();
        }
        private void Temizle()
        {
            txtKullaniciId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKullaniciTuru.Text = "";
            txtKullaniciAdi.Text = "";
            txtEmail.Text = "";
            txtSifre.Text = "";
            txtSirket.Text = "";
            radioBayan.Checked = false;
            radioErkek.Checked = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private bool KullaniciAdiKontrol()
        {
            baglanti.Open();
            string kod2 = "Select KullaniciAdi From Kullanicilar where KullaniciAdi ='" + txtKullaniciAdi.Text + "'";
            SqlCommand comand = new SqlCommand(kod2, baglanti);
            SqlDataReader oku = comand.ExecuteReader();

            if (oku.Read())
            {
                baglanti.Close();
                MessageBox.Show(txtKullaniciAdi.Text + " Kullanıcı Adı Alınmış Lütfen Başka bir Kullanıcı Adı Giriniz !","StokTakip",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            else
            {
                baglanti.Close();
                return true;
            }
            baglanti.Close();
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtKullaniciTuru.Text == "" || txtKullaniciAdi.Text == "" || txtEmail.Text == "" || txtSifre.Text == "" || txtSirket.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Değerleri Eksiksiz Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(KullaniciAdiKontrol() == false)
                {

                }
                else
                {
                    baglanti.Open();

                    string kod1 = "insert into Kullanicilar(Ad,Soyad,KullaniciTuru,KullaniciAdi,Email,Sifre,Sirket,Cinsiyet) Values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8)";
                    SqlCommand komut1 = new SqlCommand(kod1,baglanti);
                    komut1.Parameters.AddWithValue("@a1", txtAd.Text);
                    komut1.Parameters.AddWithValue("@a2", txtSoyad.Text);
                    komut1.Parameters.AddWithValue("@a3", txtKullaniciTuru.Text);
                    komut1.Parameters.AddWithValue("@a4", txtKullaniciAdi.Text);
                    komut1.Parameters.AddWithValue("@a5", txtEmail.Text);
                    komut1.Parameters.AddWithValue("@a6", txtSifre.Text);
                    komut1.Parameters.AddWithValue("@a7", txtSirket.Text);
                    if(radioErkek.Checked == true)
                    {
                        komut1.Parameters.AddWithValue("@a8", 1);
                    }
                    else
                    {
                        komut1.Parameters.AddWithValue("@a8", 0);
                    }
                    komut1.ExecuteNonQuery();

                    MessageBox.Show(txtAd.Text + "  Kullanıcısı Başarıyla Kaydedilmiştir.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    Temizle();
                    Yenile();
                    
                }
               
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtKullaniciId.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Id Değerini Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                baglanti.Open();

                string islem9 = "Delete From Kullanicilar where KullaniciId = '" + txtKullaniciId.Text + "'";
                SqlCommand komut9 = new SqlCommand(islem9, baglanti);
                komut9.ExecuteNonQuery();
                MessageBox.Show(txtKullaniciAdi.Text + "  Kullanıcısı Başarıyla Silindi.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglanti.Close();
                Yenile();
                Temizle();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || txtKullaniciTuru.Text == "" || txtKullaniciAdi.Text == "" || txtEmail.Text == "" || txtSifre.Text == "" || txtSirket.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Değerleri Eksiksiz Giriniz !", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ////////////

                baglanti.Open();
                string kod2 = "Select KullaniciAdi From Kullanicilar where KullaniciId != '"+ txtKullaniciId.Text +"' AND KullaniciAdi ='" + txtKullaniciAdi.Text + "'";
                SqlCommand comand = new SqlCommand(kod2, baglanti);
                SqlDataReader oku = comand.ExecuteReader();

                if (oku.Read())
                {
                    baglanti.Close();
                    MessageBox.Show(txtKullaniciAdi.Text + " Kullanıcı Adı Alınmış Lütfen Başka bir Kullanıcı Adı Giriniz !","Stok Takip",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    baglanti.Close();
                    // güncelleme
                    baglanti.Open();

                    string kod = "Update Kullanicilar Set Ad = @a1, Soyad = @a2, KullaniciTuru = @a3, KullaniciAdi = @a4, Email = @a5, Sifre = @a6, Sirket = @a7, Cinsiyet = @a8 where KullaniciId = '" + txtKullaniciId.Text + "'";
                    SqlCommand komut = new SqlCommand(kod,baglanti);

                    komut.Parameters.AddWithValue("@a1", txtAd.Text);
                    komut.Parameters.AddWithValue("@a2", txtSoyad.Text);
                    komut.Parameters.AddWithValue("@a3", txtKullaniciTuru.Text);
                    komut.Parameters.AddWithValue("@a4", txtKullaniciAdi.Text);
                    komut.Parameters.AddWithValue("@a5", txtEmail.Text);
                    komut.Parameters.AddWithValue("@a6", txtSifre.Text);
                    komut.Parameters.AddWithValue("@a7", txtSirket.Text);

                    if (radioErkek.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@a8", 1);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@a8", 0);
                    }
                    komut.ExecuteNonQuery();

                    MessageBox.Show(txtKullaniciAdi.Text + "  Kullanıcısı Başarıyla Güncellenmiştir.", "Stok Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    baglanti.Close();
                    Yenile();
                    Temizle();

                }
                baglanti.Close();


                /////////////

               
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void btnCikisKullanicilar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Oturumu kapatmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                this.Hide(); // Form1'i gizle
                Form2 girisFormu = new Form2();
                girisFormu.Show(); // Form2'yi göster
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtKategori.Text == "")
            {
                MessageBox.Show("Lütfen kategori adı giriniz!");
                return;
            }

            try
            {
                baglanti.Open();
                string query = "INSERT INTO KategoriTablo (Kategori) VALUES (@kategori)";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kategori eklendi.");
                KategoriTablosunuGetir();
                TemizleKategori();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                baglanti.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtKategoriNo.Text == "" || txtKategori.Text == "")
            {
                MessageBox.Show("Lütfen kategori no ve adı giriniz!");
                return;
            }

            try
            {
                baglanti.Open();
                string query = "UPDATE KategoriTablo SET Kategori = @kategori WHERE KategoriNo = @no";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@kategori", txtKategori.Text);
                cmd.Parameters.AddWithValue("@no", txtKategoriNo.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kategori güncellendi.");
                KategoriTablosunuGetir();
                TemizleKategori();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                baglanti.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtKategoriNo.Text == "")
            {
                MessageBox.Show("Lütfen silinecek kategori numarasını giriniz!");
                return;
            }

            DialogResult onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    baglanti.Open();
                    string query = "DELETE FROM KategoriTablo WHERE KategoriNo = @no";
                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    cmd.Parameters.AddWithValue("@no", txtKategoriNo.Text);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kategori silindi.");
                    KategoriTablosunuGetir();
                    TemizleKategori();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    baglanti.Close();
                }
            }
        }

        private void TemizleKategori()
        {
            txtKategoriNo.Text = "";
            txtKategori.Text = "";
        }

        private void KategoriTablosunuGetir()
        {
            try
            {
                baglanti.Open();
                string sorgu = "SELECT KategoriNo, Kategori FROM KategoriTablo";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewKategori.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori verileri alınamadı: " + ex.Message);
                baglanti.Close();
            }
        }

        private void dataGridViewKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridViewKategori.SelectedCells[0].RowIndex;

            txtKategoriNo.Text = dataGridViewKategori.Rows[satir].Cells["KategoriNo"].Value.ToString();
            txtKategori.Text = dataGridViewKategori.Rows[satir].Cells["Kategori"].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtKategoriNo.Text = "";
            txtKategori.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = e.RowIndex;
            if (secilen < 0) return;

            DataGridViewRow row = dataGridView1.Rows[secilen];

            txtKullaniciId.Text = row.Cells["KullaniciId"].Value.ToString();
            txtAd.Text = row.Cells["Ad"].Value.ToString();
            txtSoyad.Text = row.Cells["Soyad"].Value.ToString();
            txtKullaniciTuru.Text = row.Cells["KullaniciTuru"].Value.ToString();
            txtKullaniciAdi.Text = row.Cells["KullaniciAdi"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtSifre.Text = row.Cells["Sifre"].Value.ToString();
            txtSirket.Text = row.Cells["Sirket"].Value.ToString();

            // Cinsiyet bool olduğu için kontrol gerekiyor
            if (row.Cells["Cinsiyet"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Cinsiyet"].Value))
                radioErkek.Checked = true;
            else
                radioBayan.Checked = true;
        }
    }
}
