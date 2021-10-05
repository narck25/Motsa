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
    public partial class Atalappc : Form
    {
        public Atalappc()
        {
            InitializeComponent();
            llenacombobox();
            llenacombobox1();
            llenacombobox2();
            llenacombobox3();
            llenacombobox4();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void llenacombobox()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from TipoEquipos", con);
            da.Fill(ds, "Nombre");
            ComboTipo.DataSource = ds.Tables[0].DefaultView;
            ComboTipo.ValueMember = "Nombre";
        }
        public void llenacombobox1()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from Marcas", con);
            da.Fill(ds, "Nombre");
            ComboMarca.DataSource = ds.Tables[0].DefaultView;
            ComboMarca.ValueMember = "Nombre";
        }
        public void llenacombobox2()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from Ubicaciones", con);
            da.Fill(ds, "Nombre");
            ComboUbicacion.DataSource = ds.Tables[0].DefaultView;
            ComboUbicacion.ValueMember = "Nombre";
        }
        public void llenacombobox3()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from Modelos", con);
            da.Fill(ds, "Nombre");
            ComboModelo.DataSource = ds.Tables[0].DefaultView;
            ComboModelo.ValueMember = "Nombre";
        }
        public void llenacombobox4()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct nombre from SistemaOperativo", con);
            da.Fill(ds, "Nombre");
            ComboSO.DataSource = ds.Tables[0].DefaultView;
            ComboSO.ValueMember = "Nombre";
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text=="" || combobits.SelectedIndex==-1  )
            {

                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            { con.Open();
                string q = (" if not exists (select * from Laptops_PC where Nserie = '" + txtNserie.Text + "') insert into Laptops_PC values ('" + ComboTipo.Text + "','" + ComboMarca.Text + "','" + ComboUbicacion.Text + "','" + ComboModelo.Text + "','" + ComboSO.Text + "','" + txtNombre.Text + "','" + txtNserie.Text + "','" + txtColor.Text + "','" + txtProcesador.Text + "','" + txtGhz.Text + "','" + combobits.Text + "','" + txtRam.Text + "','" + txtHdd.Text + "','" + txtSsd.Text + "','" + txtMAC.Text + "','" + txtObservaciones.Text + "',gedate())");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();

                foreach (Control c in gpespec.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                        combobits.SelectedIndex = -1;
                    }
                }
                foreach (Control c in gpdatos.Controls)
                {
                    if (c is ComboBox)
                    {
                        c.Text = "";                      
                    }
                }

            }
        }
    }
}
