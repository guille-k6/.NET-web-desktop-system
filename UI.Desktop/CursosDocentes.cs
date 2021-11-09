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
    public partial class CursosDocentes : Form
    {
        public CursosDocentes()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            CursoDocenteLogic curLogic = new CursoDocenteLogic();
            dgvCursosDocentes.AutoGenerateColumns = false;
            dgvCursosDocentes.DataSource = curLogic.GetAll();
        }
        private void CursosDocentes_Load(object sender, EventArgs e)
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
            var curDesktop = new CursoDocDesktop(ApplicationForm.ModoForm.Alta);
            curDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvCursosDocentes.SelectedRows[0].DataBoundItem).ID;
            var curDesktop = new CursoDocDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            curDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvCursosDocentes.SelectedRows[0].DataBoundItem).ID;
            var curDesktop = new CursoDocDesktop(ID, ApplicationForm.ModoForm.Baja);
            curDesktop.ShowDialog();
            this.Listar();
        }
    }
}
