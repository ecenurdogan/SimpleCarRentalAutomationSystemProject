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
    public partial class frmAraçListele : Form
    {

        Araç_Kiralama arackiralama = new Araç_Kiralama();
        public frmAraçListele()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            Plakatxt.Text = satır.Cells["plaka"].Value.ToString();
            Markacombo.Text = satır.Cells["marka"].Value.ToString();
            Sericombo.Text = satır.Cells["seri"].Value.ToString();
            Yiltxt.Text = satır.Cells["yil"].Value.ToString();
            Renktxt.Text = satır.Cells["renk"].Value.ToString();
            Kmtxt.Text = satır.Cells["km"].Value.ToString();
            Yakıtcombo.Text = satır.Cells["yakit"].Value.ToString();
            Ücrettxt.Text = satır.Cells["kiraücreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
        }

        private void frmAraçListele_Load(object sender, EventArgs e)
        {
            YenileAraçlarListesi();

            comboAraçlar.SelectedIndex = 0;
        }

        private void YenileAraçlarListesi()
        {
            string cümle = "select *from araç ";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update araç set marka=@marka,seri=@seri, yil=@yil,renk=@renk,km=@km,yakit=@yakit,kiraücreti=@kiraücreti,resim=@resim,tarih=@tarih where plaka=@plaka ";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", Yiltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakit", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraücreti", float.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = " ";
            YenileAraçlarListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from araç where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            YenileAraçlarListesi();
            pictureBox2.ImageLocation = " ";
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";

        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("DUSTER");
                    Sericombo.Items.Add("SANDERO");
                    Sericombo.Items.Add("LOGAN MCV");
                }
                else if (Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("Q8");
                    Sericombo.Items.Add("A3");
                    Sericombo.Items.Add("A8 L");
                    Sericombo.Items.Add("A7 SPORTBACK");
                    Sericombo.Items.Add("RS6 AVANT");
                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("ACCENT BLUE");
                    Sericombo.Items.Add("ELANTRA");
                    Sericombo.Items.Add("İ 10");
                    Sericombo.Items.Add("İ 20");
                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("Picanto");
                    Sericombo.Items.Add("Rio HB");
                    Sericombo.Items.Add("Niro ");
                    Sericombo.Items.Add("Stinger");
                }
                else if (Markacombo.SelectedIndex == 4)
                {
                    Sericombo.Items.Add("Polo");
                    Sericombo.Items.Add("Golf");
                    Sericombo.Items.Add("Passat");
                    Sericombo.Items.Add("Tiguan");
                }
                else if (Markacombo.SelectedIndex == 5)
                {
                    Sericombo.Items.Add("Corolla");
                    Sericombo.Items.Add("Pirius");
                    Sericombo.Items.Add("Yaris");
                    Sericombo.Items.Add("Camry");
                }
                else if (Markacombo.SelectedIndex == 6)
                {
                    Sericombo.Items.Add("Fabia");
                    Sericombo.Items.Add("Octavia");
                    Sericombo.Items.Add("Yeti");
                    Sericombo.Items.Add("Fapid");
                }
                else if (Markacombo.SelectedIndex == 7)
                {
                    Sericombo.Items.Add("Astra Sedan");
                    Sericombo.Items.Add("Combo");
                    Sericombo.Items.Add("Grandland X");
                    Sericombo.Items.Add("Corsa");
                }
                else if (Markacombo.SelectedIndex == 8)
                {
                    Sericombo.Items.Add("208");
                    Sericombo.Items.Add("301");
                    Sericombo.Items.Add("SUV 3008");

                }
                else if (Markacombo.SelectedIndex == 9)
                {
                    Sericombo.Items.Add("CLIO");
                    Sericombo.Items.Add("CAPTUR");
                    Sericombo.Items.Add("MEGANE");
                    Sericombo.Items.Add("Renault ZOE");
                }
                else if (Markacombo.SelectedIndex == 10)
                {
                    Sericombo.Items.Add("Qashqai");
                    Sericombo.Items.Add("Juke");
                    Sericombo.Items.Add("Micra");
                    Sericombo.Items.Add("Navara");
                }
                else if (Markacombo.SelectedIndex == 11)
                {
                    Sericombo.Items.Add("Mini Cabrio");
                    Sericombo.Items.Add("Mini Countryman");

                }
                else if (Markacombo.SelectedIndex == 12)
                {
                    Sericombo.Items.Add("A-Serisi");
                    Sericombo.Items.Add("B-Serisi");
                    Sericombo.Items.Add("CLA");
                    Sericombo.Items.Add("GLA");
                }
                else if (Markacombo.SelectedIndex == 13)
                {
                    Sericombo.Items.Add("Cabrio");
                    Sericombo.Items.Add("Active Tourer");
                    Sericombo.Items.Add("M240i Coupé");
                    Sericombo.Items.Add("xDrive Sedan");
                }
                else if (Markacombo.SelectedIndex == 14)
                {
                    Sericombo.Items.Add("124 Spider");
                    Sericombo.Items.Add("500");
                    Sericombo.Items.Add("500X Cross");
                    Sericombo.Items.Add("Panda");
                }
                else if (Markacombo.SelectedIndex == 15)
                {
                    Sericombo.Items.Add("Fiesta");
                    Sericombo.Items.Add("Focus");
                    Sericombo.Items.Add("Mondeo");
                    Sericombo.Items.Add("Yeni Mustang");
                }

            }
            catch
            {
                ;
            }
        }

        private void comboAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboAraçlar.SelectedIndex == 0)
                {
                    YenileAraçlarListesi();
                }
                if (comboAraçlar.SelectedIndex == 1)
                {
                    string cümle = "select *from araç where durumu='BOŞ' ";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (comboAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select *from araç  where durumu='DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch
            {
                ;
            }
        }

    }
}
