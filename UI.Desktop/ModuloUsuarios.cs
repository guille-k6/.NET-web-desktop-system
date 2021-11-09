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
    public partial class ModuloUsuarios : Form
    {
        public ModuloUsuarios()
        {
            InitializeComponent();
        }

        private void ModuloUsuarioDesktop_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            ModuloUsuarioLogic modLogic = new ModuloUsuarioLogic();
            dgvModulosUsuarios.AutoGenerateColumns = false;
            dgvModulosUsuarios.DataSource = modLogic.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop modDesktop = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            modDesktop.ShowDialog();
            Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
            ModuloUsuarioDesktop modDesktop = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            modDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
            ModuloUsuarioDesktop modDesktop = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
            modDesktop.ShowDialog();
            this.Listar();
        }
    }
}
