using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Database;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ReporteCursos : Form
    {
        public ReporteCursos()
        {
            InitializeComponent();
        }

        private void ReporteCursos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tp2_netDataSet.cursos' table. You can move, or remove it, as needed.
            this.cursosTableAdapter.Fill(this.tp2_netDataSet.cursos);

        }

        private void rvCursos_Load(object sender, EventArgs e)
        {
            this.rvCursos.RefreshReport();
        }
    }
}
