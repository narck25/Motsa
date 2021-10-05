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
    public partial class ModeloTable : Form
    {
        public ModeloTable()
        {
            InitializeComponent();
            llenarTable();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        public void llenarTable()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Modelos";
            cmd1.Connection = con;
            DataSet DS = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd1);
            adap.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            llenarTable();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Modelo myForm = new Modelo();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Show();
        }
    }
}
