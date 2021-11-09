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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            MateriaLogic matLogic = new MateriaLogic();
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.DataSource = matLogic.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
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
            MateriaDesktop matDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            matDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop matDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            matDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop matDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
            matDesktop.ShowDialog();
            this.Listar();
        }
    }
}
