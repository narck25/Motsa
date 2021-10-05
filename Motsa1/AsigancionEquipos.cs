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
    public partial class AsigancionEquipos : Form
    {
        public AsigancionEquipos()
        {
            InitializeComponent();
            llenacombobox();
            llenacombomarxas();

        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1;MultipleActiveResultSets=True");

        public void llenacombobox()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select  Nombre from Responsabes", con);
            da.Fill(ds, "Nombre");
            ComboNombre.DataSource = ds.Tables[0].DefaultView;
            ComboNombre.ValueMember = "Nombre";
            con.Close();
        }

        public void llenacombomarxas()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("  select distinct Marca from Laptops_PC", con);
            da.Fill(ds, "Marca");
            comboMarca.DataSource = ds.Tables[0].DefaultView;
            comboMarca.ValueMember = "Marca";
            con.Close();
        }

        private void ComboNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand Comm1 = new SqlCommand("select * from Responsabes where nombre = '" + ComboNombre.Text + "'", con);
            con.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            while (DR1.Read())
            {
                txtApellido.Text = DR1.GetValue(1).ToString();
                txtdepa.Text = DR1.GetValue(2).ToString();
            }
            con.Close();
            DR1.Close();

        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {


        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("  select distinct Modelo from Laptops_PC where Marca = '"+comboMarca.Text+"'", con);
            da.Fill(ds, "Modelo");
            ComboModelo.DataSource = ds.Tables[0].DefaultView;
            ComboModelo.ValueMember = "Modelo";
            con.Close();
        }

        private void ComboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand Comm2 = new SqlCommand("select * from Laptops_PC where Marca = '"+comboMarca.Text+"' and Modelo='"+ComboModelo.Text+"'", con);
            con.Open();
            SqlDataReader DR2 = Comm2.ExecuteReader();
            while (DR2.Read())
            {
                txtSerie.Text = DR2.GetValue(6).ToString();
                txtCpu.Text = DR2.GetValue(8).ToString();
                txtRam.Text = DR2.GetValue(11).ToString();
                txtHDD.Text = DR2.GetValue(12).ToString();
                txtSSD.Text = DR2.GetValue(13).ToString();
                txtSO.Text = DR2.GetValue(4).ToString();
                txtMAC.Text = DR2.GetValue(14).ToString();

            }
            con.Close();
            DR2.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (ComboNombre.SelectedIndex==-1 || comboMarca.SelectedIndex==-1)
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q = ("insert into AsignacionEquipos Values (getdate(),'"+ComboNombre.Text+"','"+txtApellido.Text+"','"+txtdepa.Text+"','"+comboMarca.Text+"','"+ComboModelo.Text+"','"+txtSerie.Text+"','"+ComboCargador.Text+"')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                    comboMarca.SelectedIndex = -1;
                    ComboModelo.SelectedIndex = -1;
                    txtApellido.Text = "";
                    txtdepa.Text = "";
                    ComboNombre.SelectedIndex = -1;
                    ComboCargador.SelectedIndex = -1;

                }
            }
        }
    }
    
}
