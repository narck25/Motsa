using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Motsa1
{
    public partial class BuscadorCorreos : Form
    {
        public BuscadorCorreos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Correos myForm = new Correos();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Show();
        }

        private void BtnNombre_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "  select * from Correos where Personal  like '"+txtNombre.Text+"%'";
            cmd1.Connection = con;
            DataSet DS = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd1);
            adap.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
            txtNombre.Text = "";
        }

        private void BtnCorreo_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Correos where Correo like '" + txtCorreo.Text+"%'";
            cmd1.Connection = con;
            DataSet DS = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd1);
            adap.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
            txtCorreo.Text = "";
        }



        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "select * from Correos where Correo like '" + txtCorreo.Text + "%'";
                cmd1.Connection = con;
                DataSet DS = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(cmd1);
                adap.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                con.Close();
                txtCorreo.Text = "";

            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "  select * from Correos where Personal  like '" + txtNombre.Text + "%'";
                cmd1.Connection = con;
                DataSet DS = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(cmd1);
                adap.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                con.Close();
                txtNombre.Text = "";

            }
        }
    }
}
