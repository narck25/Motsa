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
    public partial class Lineas : Form
    {
        public Lineas()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if(txtLinea.Text==""||txtFechaplan.Text==""||txtCost.Text==""||comoMEses.SelectedIndex==-1|| txtPlan.Text=="")
            {
                MessageBox.Show(" Verifica que los datos estén completos");
            }
            else
            {
                if (txtLinea.Text.Length <10)
                {
                    MessageBox.Show("El NUMERO NO ESTA COMPLETO " + txtLinea.Text + " Deben ser 10 digitos");
                }
                else
                {
                    Int64 line = Int64.Parse(txtLinea.Text);
                    decimal cost = decimal.Parse(txtCost.Text);
                    con.Open();
                    string q = (" if not exists (select * from Lineas where Numero = "+line+")insert into Lineas values ("+line+",'"+txtPlan.Text+"','"+txtFechaplan.Text+"','"+comoMEses.Text+"',"+cost+")");
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtLinea.Text = "";
                    txtPlan.Text = "";
                    txtFechaplan.Text = "";
                    comoMEses.SelectedIndex = -1;
                    txtCost.Text = "";
                
                }
            }
        }
    }
}
