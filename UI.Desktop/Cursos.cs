using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            CursoLogic curLogic = new CursoLogic();
            dgvCursos.AutoGenerateColumns = false;
            dgvCursos.DataSource = curLogic.GetAll();
        }
        private void Cursos_Load(object sender, EventArgs e)
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
            CursoDesktop curDesktop = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            curDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop curDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            curDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop curDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            curDesktop.ShowDialog();
            this.Listar();
        }
    }
}
