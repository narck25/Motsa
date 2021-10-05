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
    public partial class CelularesIpad : Form
    {
        public CelularesIpad()
        {
            InitializeComponent();
            llenacombobox1();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");


        public void llenacombobox1()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from Marcas", con);
            da.Fill(ds, "Nombre");
            comboMarcas.DataSource = ds.Tables[0].DefaultView;
            comboMarcas.ValueMember = "Nombre";
        }
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboMarcas.SelectedIndex==-1||txtimei.Text ==""||txtModelo.Text==""||txtSerie.Text=="")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                if (txtimei.Text.Length <15)
                {
                    MessageBox.Show("El IMEI NO ESTA COMPLETO "+txtimei.Text+" Deben ser 15 digitos");
                }
                else
                {
                    Int64 imei1 = Int64.Parse(txtimei.Text);

                    con.Open();
                    string q = (" if not exists (select * from Celulares where IMEI = " + imei1 + ")insert into Celulares Values ('" + comboMarcas.Text + "','" + txtModelo.Text + "','" + txtSerie.Text + "'," + imei1 + ",gedate()) ");
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtimei.Text = "";
                    txtModelo.Text = "";
                    txtSerie.Text = "";
                    comboMarcas.SelectedIndex = -1;
                }
            }
        }
    }
}
