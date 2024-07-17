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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EMRE\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //Şehire Göre chart grafik dağılımı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select PerSehir,Count(*) From Table_1 Group By PerSehir", baglanti);
            SqlDataReader r1 = komut1.ExecuteReader();
            while (r1.Read()) { chart1.Series["Sehirler"].Points.AddXY(r1[0], r1[1]); }
            baglanti.Close();
            //MESLEĞE GÖRE MAAŞ DAĞILIMI
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select PerMeslek,Avg(PerMaas) From Table_1 Group By PerMeslek",baglanti);
            SqlDataReader r2= komut2.ExecuteReader();
            while (r2.Read()) { chart2.Series["Meslek-Maas"].Points.AddXY(r2[0], r2[1]); }
            baglanti.Close();
        }
    }
}
