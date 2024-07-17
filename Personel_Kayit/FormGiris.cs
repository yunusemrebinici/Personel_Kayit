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
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EMRE\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }
        

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Yonetici where KullaniciAd=@p1 and sifre=@p2", baglanti);
            komut1.Parameters.AddWithValue("@p1",TxtKullanıcıAd.Text);
            komut1.Parameters.AddWithValue("@p2",TxtKullaniciSifre.Text);
            SqlDataReader r1 = komut1.ExecuteReader();
            if (r1.Read())
            {
                Form1 cs= new Form1();
                cs.Show();
                this.Hide();
            }
            else { MessageBox.Show("HATALI ŞİFRE"); }
            baglanti.Close();
        }
    }
}
