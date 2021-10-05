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
    public partial class CelularesIpadtabla : Form
    {
        public CelularesIpadtabla()
        {
            InitializeComponent();
            llenarTable();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        public void llenarTable()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = " select * from Celulares";
            cmd1.Connection = con;
            DataSet DS = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd1);
            adap.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            con.Close();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            llenarTable();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            CelularesIpad myForm = new CelularesIpad();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Show();
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
