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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-3VB3SSC;Initial Catalog=DBSECIM;Integrated Security=True");

        private void btnoygiris_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand command = new SqlCommand("insert into tblsecim (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI)values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl);
            command.Parameters.AddWithValue("@p1", txtilcead.Text);
            command.Parameters.AddWithValue("@p2", txta.Text);
            command.Parameters.AddWithValue("@p3", txtb.Text);
            command.Parameters.AddWithValue("@p4", txtc.Text);
            command.Parameters.AddWithValue("@p5", txtd.Text);
            command.Parameters.AddWithValue("@p6", txte.Text);
            command.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Ekleme başarılı");
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            Frmgrafik frg = new Frmgrafik();
            frg.Show();
            this.Hide();
        }
    }
}
