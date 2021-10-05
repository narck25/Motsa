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
    public partial class Typepcs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        public Typepcs()
        {
            InitializeComponent();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
 
        }

        private void Bt_exit_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (combotipo.SelectedIndex == -1 || txt_pref.Text == "")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {

            }
            {
                con.Open();
                string q = ("if not exists  (select * from TipoEquipos where Nombre= '" + combotipo.Text + "')insert into TipoEquipos (Nombre, Prefijo) values ('" + combotipo.Text + "','" + txt_pref.Text + "')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                combotipo.SelectedIndex = -1;
                txt_pref.Text = "";
            }
        }
    }
}
