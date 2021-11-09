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
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tp2_netDataSet1.planes' table. You can move, or remove it, as needed.
            this.planesTableAdapter.Fill(this.tp2_netDataSet1.planes);

            this.reportViewer1.RefreshReport();
        }
    }
}
