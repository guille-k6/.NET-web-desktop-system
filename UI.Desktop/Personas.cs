using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DataSource = ul.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPersonas.ShowDialog();
            this.Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPersonas = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersonas.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPersonas.ShowDialog();
            this.Listar();
        }
    }
}
