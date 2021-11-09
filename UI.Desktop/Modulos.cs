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
    public partial class Modulos : Form
    {
        public Modulos()
        {
            InitializeComponent();
        }

        private void Modulos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            ModuloLogic modLogic = new ModuloLogic();
            dgvModulos.AutoGenerateColumns = false;
            dgvModulos.DataSource = modLogic.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloDesktop modDesktop = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            modDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModuloDesktop plnDesktop = new ModuloDesktop(ApplicationForm.ModoForm.Modificacion, ID);
            plnDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
            ModuloDesktop plnDesktop = new ModuloDesktop(ApplicationForm.ModoForm.Baja, ID);
            plnDesktop.ShowDialog();
            this.Listar();
        }
    }
}
