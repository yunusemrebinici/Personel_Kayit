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
using System.Security.Cryptography;


namespace Personel_Kayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Data Source=EMRE\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        void temizle()
        {
            Txtad.Text = "";
            Txtmeslek.Text = "";
            MskMaas.Text = "";
            TxtSoyad.Text = "";
            CmbSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Txtad.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Table_1' table. You can move, or remove it, as needed.
            this.table_1TableAdapter.Fill(this.personelVeriTabaniDataSet.Table_1);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            this.table_1TableAdapter.Fill(this.personelVeriTabaniDataSet.Table_1);
        }
            
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into dbo.Table_1 (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",Txtad.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4",MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", Txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", LblDurum.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true) 
            {
                LblDurum.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                LblDurum.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            Txtmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            LblDurum.Text= dataGridView1.Rows[secim].Cells[5].Value.ToString();

        }

        private void LblDurum_TextChanged(object sender, EventArgs e)
        {
            if (LblDurum.Text=="True")
            {
                radioButton1.Checked = true;

            }
            if (LblDurum.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsit = new SqlCommand("Delete From dbo.Table_1 Where Perid=@k1",baglanti);
            komutsit.Parameters.AddWithValue("@k1",Txtid.Text);
            komutsit.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void BtnGuncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand güncelle = new SqlCommand("Update dbo.Table_1 Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where Perid=@a7",baglanti);
            güncelle.Parameters.AddWithValue("@a1", Txtad.Text);
            güncelle.Parameters.AddWithValue("@a2",TxtSoyad.Text);
            güncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            güncelle.Parameters.AddWithValue("@a4",MskMaas.Text);
            güncelle.Parameters.AddWithValue("@a5", LblDurum.Text);
            güncelle.Parameters.AddWithValue("@a6",Txtmeslek.Text);
            güncelle.Parameters.AddWithValue("@a7", Txtid.Text);
            güncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme yapıldı");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Formİstatistik f1=new Formİstatistik();
            f1.Show();
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler f1 = new FrmGrafikler();
            f1.Show();
            
        }
    }
}
