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
    public partial class So : Form
    {
        public So()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        private void Button1_Click(object sender, EventArgs e)
        {
            if(comboSO.SelectedIndex==-1)
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q =("insert into SistemaOperativo (Nombre, Fecha) values ('"+comboSO.Text+ "',getdate())");
                SqlCommand cmd = new SqlCommand(q,con);
                cmd.ExecuteNonQuery();
                con.Close();
                comboSO.SelectedIndex = -1;
            }
        }

        private void Bt_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboSO.SelectedIndex == -1)
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q = ("if not exists (select * from SistemaOperativo where Nombre ='" + comboSO.Text + "')insert into SistemaOperativo (Nombre, Fecha) values ('" + comboSO.Text + "',getdate())");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                comboSO.SelectedIndex = -1;
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
