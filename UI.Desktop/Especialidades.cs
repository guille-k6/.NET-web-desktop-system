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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            EspecialidadLogic EspLogic = new EspecialidadLogic();
            this.dgvEspecialidad.AutoGenerateColumns = false;
            this.dgvEspecialidad.DataSource = EspLogic.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnAcutalizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop espDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            espDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidad.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop espDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            espDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidad.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop espDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
            espDesktop.ShowDialog();
            this.Listar();
        }
    }
}
