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
    public partial class Correos : Form
    {
        public Correos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1;MultipleActiveResultSets=True");


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCorreo.Text == ""||txtPass.Text=="")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                    con.Open();
                    string q = ("insert into Correos values ('"+txtNombre.Text+"','"+txtCorreo.Text+"','"+txtPass.Text+"') ");
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtPass.Text = "";
            }
        }
    }
}
