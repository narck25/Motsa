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
    public partial class Modelo : Form
    {
        public Modelo()
        {
            InitializeComponent();
            llenacombobox();
            llenacombobox1();

        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        public void llenacombobox()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Nombre from Marcas", con);
            da.Fill(ds, "Nombre");
            comboMar.DataSource = ds.Tables[0].DefaultView;
            comboMar.ValueMember = "Nombre";
        }

        public void llenacombobox1()
        {
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("select distinct nombre from TipoEquipos", con);
            da1.Fill(ds1, "Nombre");
            combotipo.DataSource = ds1.Tables[0].DefaultView;
            combotipo.ValueMember = "Nombre";
        }


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboMar.SelectedIndex == -1 || combotipo.SelectedIndex == -1 || txt_nombre.Text =="")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q = (" if not exists (select * from Modelos where Nombre ='" + txt_nombre.Text + "' and Tipo = '" + combotipo.Text + "' and Marca = '" + comboMar.Text + "')insert into Modelos values ('" + txt_nombre.Text + "','" + combotipo.Text + "','" + comboMar.Text + "')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                comboMar.SelectedIndex = -1;
                combotipo.SelectedIndex = -1;
                txt_nombre.Text = "";
            }
        }

        private void Modelo_Load(object sender, EventArgs e)
        {

        }
    }
}
