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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            var alu = new AlumnoInscripcionLogic();
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.dgvAlumnos.DataSource = alu.GetAll();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            var aluDesktop = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            aluDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            var aluDesktop = new AlumnoDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            aluDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            var aluDesktop = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
            aluDesktop.ShowDialog();
            this.Listar();
        }
    }
}
