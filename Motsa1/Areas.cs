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
    public partial class Areas : Form
    {
        public Areas()
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
            if (textBox1.Text == "")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {   
                con.Open();
                string q = (" if not exists (select *  from Area where nombre = '" + textBox1.Text + "')insert into Area (Nombre) values ('" + textBox1.Text + "')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
            }
        }
    }
}
