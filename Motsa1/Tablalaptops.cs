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
    public partial class Tablalaptops : Form
    {
        public Tablalaptops()
        {
            InitializeComponent();
            llenarTable();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        public void llenarTable()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select CONVERT(varchar,AsignacionEquipos.Fecha_Asignacion,106) as Fecha_Asignacion,AsignacionEquipos.Nombres,AsignacionEquipos.Apellidos, AsignacionEquipos.Departamento,AsignacionEquipos.Marca,AsignacionEquipos.Modelo,Laptops_PC.Color,AsignacionEquipos.NSerie,Laptops_PC.SistemasOperativo, Laptops_PC.Procesador,Laptops_PC.RAM,Laptops_PC.HDD, Laptops_PC.SSD, Laptops_PC.MAC,Laptops_PC.Observaciones from AsignacionEquipos inner join Laptops_PC on AsignacionEquipos.NSerie = Laptops_PC.Nserie";
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

        private void ToolStripButton2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            AsigancionEquipos myForm = new AsigancionEquipos();
            myForm.StartPosition = FormStartPosition.CenterScreen;
            myForm.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            llenarTable();
        }
    }
}
