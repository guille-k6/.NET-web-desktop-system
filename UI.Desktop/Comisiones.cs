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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            ComisionLogic comLogic = new ComisionLogic();
            this.dgvComisiones.AutoGenerateColumns = false;
            dgvComisiones.DataSource = comLogic.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop comDesktop = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            comDesktop.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop comDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            comDesktop.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop comDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
            comDesktop.ShowDialog();
            this.Listar();
        }
    }
}
