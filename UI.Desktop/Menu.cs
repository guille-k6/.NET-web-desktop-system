using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            var ventana = new Comisiones();
            ventana.ShowDialog();
        }

        private void btnCursosYDocs_Click(object sender, EventArgs e)
        {
            var ventana = new CursosDocentes();
            ventana.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            var ventana = new Cursos();
            ventana.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            var ventana = new Especialidades();
            ventana.ShowDialog();
        }

        private void btnInsAlumnos_Click(object sender, EventArgs e)
        {
            var ventana = new Alumnos();
            ventana.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            var ventana = new Materias();
            ventana.ShowDialog();
        }

        private void btnModulos_Click(object sender, EventArgs e)
        {
            var ventana = new Modulos();
            ventana.ShowDialog();
        }

        private void btnModulosUsuarios_Click(object sender, EventArgs e)
        {
            var ventana = new ModuloUsuarios();
            ventana.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            var ventana = new Personas();
            ventana.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            var ventana = new Planes();
            ventana.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            var ventana = new Usuarios();
            ventana.ShowDialog();
        }

        private void btnReportCursos_Click(object sender, EventArgs e)
        {
            var ventana = new ReporteCursos();
            ventana.ShowDialog();
        }

        private void btnReportPlanes_Click(object sender, EventArgs e)
        {
            var ventana = new ReportePlanes();
            ventana.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
