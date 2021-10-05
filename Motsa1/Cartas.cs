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
using System.IO;
using System.Diagnostics;

namespace Motsa1
{
    public partial class Cartas : Form
    {
        public Cartas()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1;MultipleActiveResultSets=True");

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Todos los archivos(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                txtfile.Text = openFileDialog1.FileName;
            }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if(txtdocname.Text.Trim().Equals("")||txtfile.Text.Trim().Equals(""))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }
            byte[] file = null;
            Stream mysteam = openFileDialog1.OpenFile();
            using (MemoryStream ms = new MemoryStream())
            {
                mysteam.CopyTo(ms);
                file = ms.ToArray();
            }
            using (Model.motsaEntities1 db = new Model.motsaEntities1())
            {
                Model.Cartas oDocument = new Model.Cartas();
                oDocument.Personal = txtnombre.Text;
                oDocument.Tipo = combotipo.Text;
                oDocument.Documento = txtdocname.Text.Trim();
                oDocument.Archivo = file;
                oDocument.realname = openFileDialog1.SafeFileName;


                db.Cartas.Add(oDocument);
                db.SaveChanges();

               
            }

            txtnombre.Text = "";
            combotipo.SelectedIndex = - 1;
            txtdocname.Text = "";
            txtfile.Text = "";
            MessageBox.Show("Se ha guardado con éxito");
            Refresh();
        }
        private void Refresh()
        {
            using (Model.motsaEntities1 db = new Model.motsaEntities1())
            {
                var lst = from d in db.Cartas
                          select new {d.id,d.Tipo, d.Documento };
                dataGridView1.DataSource = lst.ToList();
                          
            }
        }

        private void Cartas_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>0)
            {
                int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                using (Model.motsaEntities1 db = new Model.motsaEntities1())
                {
                    var oDocument = db.Cartas.Find(id);
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullfilepath = folder + oDocument.realname;

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    if (!File.Exists(fullfilepath))
                        Directory.Delete(fullfilepath);

                    File.WriteAllBytes(fullfilepath, oDocument.Archivo);
                    Process.Start(fullfilepath);
                }
            }
        }
    }
}
