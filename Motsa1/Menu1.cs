using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motsa1
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
            sistemaToolStripMenuItem.Available = false;
        }

        private void InventarioConsilidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SistemasOperativoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            /*So myForm = new So();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.Left = (this.ClientSize.Width - myForm.Width) / 2;
            myForm.Top = (this.ClientSize.Height - myForm.Height) / 2;*/

        }

        private void TipoDeEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ModelosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Areas zone = new Areas();
            zone.TopLevel = false;
            zone.AutoScroll = true;
            panel1.Controls.Add(zone);
            zone.Show();
            zone.Left = (this.ClientSize.Width - zone.Width) / 2;
            zone.Top = (this.ClientSize.Height - zone.Height) / 2;
        }

        private void UsuariosDePCToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ubicaciones ubic = new ubicaciones();
            ubic.TopLevel = false;
            ubic.AutoScroll = true;
            panel1.Controls.Add(ubic);
            ubic.Show();
            ubic.Left = (this.ClientSize.Width - ubic.Width) / 2;
            ubic.Top = (this.ClientSize.Height - ubic.Height) / 2;
        }

        private void LaptopsYPCRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AsignacionActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsigancionEquipos AsigEquipos = new AsigancionEquipos();
            AsigEquipos.TopLevel = false;
            AsigEquipos.AutoScroll = true;
            panel1.Controls.Add(AsigEquipos);
            AsigEquipos.Show();
            AsigEquipos.Left = (this.ClientSize.Width - AsigEquipos.Width) / 2;
            AsigEquipos.Top = (this.ClientSize.Height - AsigEquipos.Height) / 2;
        }

        private void CelularesYTabletsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void LineasYPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SO_Table tabeSO = new SO_Table() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tabeSO.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tabeSO);
            tabeSO.Show();
        }

        private void AltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            So myForm = new So();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
            myForm.Left = (this.ClientSize.Width - myForm.Width) / 2;
            myForm.Top = (this.ClientSize.Height - myForm.Height) / 2;
        }

        private void RegistroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TypepcsTable tabletipo = new TypepcsTable() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tabletipo.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tabletipo);
            tabletipo.Show();
        }

        private void AltaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Typepcs tipe = new Typepcs();
            tipe.TopLevel = false;
            tipe.AutoScroll = true;
            panel1.Controls.Add(tipe);
            tipe.Show();
            tipe.Left = (this.ClientSize.Width - tipe.Width) / 2;
            tipe.Top = (this.ClientSize.Height - tipe.Height) / 2;
        }

        private void AltaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Marcas marc = new Marcas();
            marc.TopLevel = false;
            marc.AutoScroll = true;
            panel1.Controls.Add(marc);
            marc.Show();
            marc.Left = (this.ClientSize.Width - marc.Width) / 2;
            marc.Top = (this.ClientSize.Height - marc.Height) / 2;
        }

        private void RegistroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MarcasTable tablemarcas = new MarcasTable() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablemarcas.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablemarcas);
            tablemarcas.Show();
        }

        private void AltaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Modelo model = new Modelo();
            model.TopLevel = false;
            model.AutoScroll = true;
            panel1.Controls.Add(model);
            model.Show();
            model.Left = (this.ClientSize.Width - model.Width) / 2;
            model.Top = (this.ClientSize.Height - model.Height) / 2;
        }

        private void RegistroToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ModeloTable tablemodelo = new ModeloTable() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablemodelo.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablemodelo);
            tablemodelo.Show();
        }

        private void AltaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PersonalMotsa personal = new PersonalMotsa();
            personal.TopLevel = false;
            personal.AutoScroll = true;
            panel1.Controls.Add(personal);
            personal.Show();
            personal.Left = (this.ClientSize.Width - personal.Width) / 2;
            personal.Top = (this.ClientSize.Height - personal.Height) / 2;
        }

        private void RegistroToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            personaltable tablapersonal = new personaltable() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablapersonal.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablapersonal);
            tablapersonal.Show();
        }

        private void AltaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Atalappc alta = new Atalappc();
            alta.TopLevel = false;
            alta.AutoScroll = true;
            panel1.Controls.Add(alta);
            alta.Show();
            alta.Left = (this.ClientSize.Width - alta.Width) / 2;
            alta.Top = (this.ClientSize.Height - alta.Height) / 2;
        }

        private void RegistroToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Atalappctabla tablaaltas = new Atalappctabla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablaaltas.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablaaltas);
            tablaaltas.Show();
        }

        private void AltaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CelularesIpad celu = new CelularesIpad();
            celu.TopLevel = false;
            celu.AutoScroll = true;
            panel1.Controls.Add(celu);
            celu.Show();
            celu.Left = (this.ClientSize.Width - celu.Width) / 2;
            celu.Top = (this.ClientSize.Height - celu.Height) / 2;
        }

        private void RegistroToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CelularesIpadtabla tablacel = new CelularesIpadtabla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablacel.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablacel);
            tablacel.Show();
        }

        private void AltaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Lineas line = new Lineas();
            line.TopLevel = false;
            line.AutoScroll = true;
            panel1.Controls.Add(line);
            line.Show();
            line.Left = (this.ClientSize.Width - line.Width) / 2;
            line.Top = (this.ClientSize.Height - line.Height) / 2;
        }

        private void RegistroToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Lineastabla tablalinea = new Lineastabla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablalinea.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablalinea);
            tablalinea.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            Tablalaptops tablalaptosp = new Tablalaptops() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablalaptosp.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablalaptosp);
            tablalaptosp.Show();
        }

        private void HistoricoDeAsignacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tablalaptops tablalaptosp = new Tablalaptops() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tablalaptosp.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(tablalaptosp);
            tablalaptosp.Show();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            AsigancionEquipos AsigEquipos = new AsigancionEquipos();
            AsigEquipos.TopLevel = false;
            AsigEquipos.AutoScroll = true;
            panel1.Controls.Add(AsigEquipos);
            AsigEquipos.Show();
            AsigEquipos.Left = (this.ClientSize.Width - AsigEquipos.Width) / 2;
            AsigEquipos.Top = (this.ClientSize.Height - AsigEquipos.Height) / 2;
        }

        private void AgregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Correos emailalta = new Correos();
            emailalta.TopLevel = false;
            emailalta.AutoScroll = true;
            panel1.Controls.Add(emailalta);
            emailalta.Show();
            emailalta.Left = (this.ClientSize.Width - emailalta.Width) / 2;
            emailalta.Top = (this.ClientSize.Height - emailalta.Height) / 2;
        }

        private void RegistroToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            /*
            BuscadorCorreos buscadoremail = new BuscadorCorreos() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            buscadoremail.FormBorderStyle = (FormBorderStyle);
            this.panel1.Controls.Add(buscadoremail);
            buscadoremail.Show();
            */
            BuscadorCorreos buscadoremail = new BuscadorCorreos();
            buscadoremail.TopLevel = false;
            buscadoremail.AutoScroll = true;
            panel1.Controls.Add(buscadoremail);
            buscadoremail.Show();
            buscadoremail.Left = (this.ClientSize.Width - buscadoremail.Width) / 2;
            buscadoremail.Top = (this.ClientSize.Height - buscadoremail.Height) / 2;
        }

        private void AsignacionActualDeCelularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignacionCelulares AsigCelulares = new AsignacionCelulares();
            AsigCelulares.TopLevel = false;
            AsigCelulares.AutoScroll = true;
            panel1.Controls.Add(AsigCelulares);
            AsigCelulares.Show();
            AsigCelulares.Left = (this.ClientSize.Width - AsigCelulares.Width) / 2;
            AsigCelulares.Top = (this.ClientSize.Height - AsigCelulares.Height) / 2;
        }

        private void CartasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cartas carts1 = new Cartas();
            carts1.TopLevel = false;
            carts1.AutoScroll = true;
            panel1.Controls.Add(carts1);
            carts1.Show();
            carts1.Left = (this.ClientSize.Width - carts1.Width) / 2;
            carts1.Top = (this.ClientSize.Height - carts1.Height) / 2;
        }
    }   
}
