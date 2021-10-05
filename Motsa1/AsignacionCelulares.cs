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
    public partial class AsignacionCelulares : Form
    {
        public AsignacionCelulares()
        {
            InitializeComponent();
            llenacombobox();
            llenarIMEI();
            llenarLineas();
            comboIMEI.SelectedIndex = 1;
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
        public void llenarIMEI()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct IMEI from Celulares", con);
            da.Fill(ds, "IMEI");
            comboIMEI.DataSource = ds.Tables[0].DefaultView;
            comboIMEI.ValueMember = "IMEI";
            con.Close();
        }
        public void llenarLineas()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Numero from Lineas", con);
            da.Fill(ds, "Numero");
            comboLinea.DataSource = ds.Tables[0].DefaultView;
            comboLinea.ValueMember = "Numero";
            con.Close();
        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {

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

        private void ComboIMEI_SelectedIndexChanged(object sender, EventArgs e)
        {
             SqlCommand Comm2 = new SqlCommand("select * from Celulares where IMEI ='"+comboIMEI.Text+"'", con);
             con.Open();
             SqlDataReader DR2 = Comm2.ExecuteReader();
             while (DR2.Read())
             {
                 txtMarca.Text = DR2.GetValue(0).ToString();
                 txtModelo.Text = DR2.GetValue(1).ToString();
                 txtSerie.Text = DR2.GetValue(2).ToString();
             }
             con.Close();
             DR2.Close();

            //Int64 imei1 = Int64.Parse(comboIMEI.Text);
            //int idprovider = Integer.parseInt((String)IdProviderComboBox.getSelectedItem());

            //int imei1 = int.Parse(comboIMEI.ToString());
            //Int64 imei2 = Int64.Parse(comboIMEI.Text);
           // labelimei.Text = comboIMEI.Text;
            //Int64 imei1 = Int64.Parse(labelimei.Text);
           // int imei1 = Convert.ToInt32(labelimei.Text);
            // SqlCommand Comm2 = new SqlCommand("select * from Celulares where IMEI =" + imei1 + "", con);
          /*  SqlCommand Comm2 = new SqlCommand("  select * from Celulares where IMEI =CAST('"+ labelimei.Text+"' AS bigint)", con);
            con.Open();
            SqlDataReader DR2 = Comm2.ExecuteReader();
            while (DR2.Read())
            {
                txtMarca.Text = DR2.GetValue(0).ToString();
                txtModelo.Text = DR2.GetValue(1).ToString();
                txtSerie.Text = DR2.GetValue(2).ToString();

            }
            con.Close();
            DR2.Close();*/
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (ComboNombre.SelectedIndex == -1 || comboIMEI.SelectedIndex == -1 || comboLinea.SelectedIndex==-1)
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                con.Open();
                string q = ("insert into AsignacionCelulares values (GETDATE(),'"+ComboNombre.Text+"','"+txtApellido.Text+"','"+txtdepa.Text+"','"+comboLinea.Text+"','"+comboIMEI.Text+"','"+ComboCargador.Text+"','"+comboAudio.Text+"')");
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                    comboLinea.SelectedIndex = -1;
                    comboIMEI.SelectedIndex = -1;
                    ComboNombre.SelectedIndex = -1;
                    txtApellido.Text = "";
                    txtdepa.Text = "";
                    ComboNombre.SelectedIndex = -1;
                    ComboCargador.SelectedIndex = -1;
                    comboAudio.SelectedIndex = -1;

                }
            }
        }
    }
}
