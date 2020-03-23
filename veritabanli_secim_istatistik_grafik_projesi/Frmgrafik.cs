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
namespace veritabanli_secim_istatistik_grafik_projesi
{
    public partial class Frmgrafik : Form
    {
        public Frmgrafik()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-3VB3SSC;Initial Catalog=DBSECIM;Integrated Security=True");
        private void Frmgrafik_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand command = new SqlCommand("select ILCEAD from tblsecim", bgl);
            SqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                cmbilcead.Items.Add(dr[0]);
            }
            bgl.Close();
            //Grafiğe sonuçları getirme..
            bgl.Open();
            SqlCommand command2 = new SqlCommand("select sum(APARTI),sum(BPARTI),sum(CPARTI),sum(DPARTI),sum(EPARTI) from tblsecim",bgl);
            SqlDataReader dr2 = command2.ExecuteReader();
            while(dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("Aparti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("Bparti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("Cparti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("Dparti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("Eparti", dr2[4]);
            }
            bgl.Close();
        }

        private void cmbilcead_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand command3 = new SqlCommand("select * from tblsecim where ILCEAD= @p1",bgl);
            command3.Parameters.AddWithValue("@p1", cmbilcead.Text);
            SqlDataReader dr = command3.ExecuteReader();
            while(dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = Convert.ToInt16(dr[6]);
                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();


            }
            bgl.Close();
        }
    }
}
