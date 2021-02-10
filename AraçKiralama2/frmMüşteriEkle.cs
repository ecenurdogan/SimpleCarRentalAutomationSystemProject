using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AraçKiralama2
{
    public partial class frmMüşteriEkle : Form
    {
        Araç_Kiralama arac_kiralama = new Araç_Kiralama();
        public frmMüşteriEkle()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string cümle = "insert into müşteri(tc,adsoyad,telefon,adres,email,ehliyetno,ehliyettar,ehliyetyeri) values(@tc,@adsoyad,@telefon,@adres,@email,@ehliyetno,@ehliyettar,@ehliyetyeri)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut2.Parameters.AddWithValue("@email", txtEmail.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtEhliyetNo.Text);
            komut2.Parameters.AddWithValue("@ehliyettar", txtEhliyetTarih.Text);
            komut2.Parameters.AddWithValue("@ehliyetyeri", txtEhliyetYeri.Text);
            arac_kiralama.ekle_sil_güncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
