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

namespace Personel_Kayit
{
    public partial class Formİstatistik : Form
    {
        public Formİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EMRE\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void Formİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from Table_1",baglanti);
            SqlDataReader d1= komut1.ExecuteReader();
            while (d1.Read())
            {
                LblToplam.Text = d1[0].ToString();
            }
            baglanti.Close();
            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from Table_1 Where PerDurum = 1",baglanti);
            SqlDataReader d2= komut2.ExecuteReader();
            while (d2.Read()) 
            {
                LblEvli.Text= d2[0].ToString();
            }
            baglanti.Close();
            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from Table_1 Where PerDurum = 0",baglanti);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read()) { LblBekar.Text = dr3[0].ToString(); }
            baglanti.Close();
            //Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) from Table_1 ",baglanti);
            SqlDataReader d4 = komut4.ExecuteReader();
            while (d4.Read()) {LblSehir.Text = d4[0].ToString();}
            baglanti.Close();
            //TOPLAM MAAŞ
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) from Table_1", baglanti);
            SqlDataReader d5= komut5.ExecuteReader();
            while (d5.Read()) {LblMaas.Text = d5[0].ToString(); } baglanti.Close();
            //ORTALAMA MAAS
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from Table_1", baglanti);
            SqlDataReader d6= komut6.ExecuteReader();
            while (d6.Read()) { LblOrtMaas.Text = d6[0].ToString(); }
            baglanti.Close();
        }
    }
}
