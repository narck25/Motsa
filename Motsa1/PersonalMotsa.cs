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
    public partial class PersonalMotsa : Form
    {
        public PersonalMotsa()
        {
            InitializeComponent();
            llenacombobox();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void llenacombobox()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Nombre from Area", con);
            da.Fill(ds, "Nombre");
            comboArea.DataSource = ds.Tables[0].DefaultView;
            comboArea.ValueMember = "Nombre";
        }


        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "" || txt_Apell.Text =="" || comboArea.SelectedIndex == -1)
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q = ("if not exists (select * from Responsabes where nombre ='" + txt_nombre.Text + "' and apellido = '" + txt_Apell.Text + "' and  area ='" + comboArea.Text + "')insert into Responsabes values ('" + txt_nombre.Text + "','" + txt_Apell.Text + "','" + comboArea.Text + "')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                txt_nombre.Text = "";
                txt_Apell.Text = "";
                comboArea.SelectedIndex = -1;
            }
        }
    }
}
