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
using Data.Database;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public Materia MateriaActual { get; set; }
        public MateriaDesktop ()
        {
            InitializeComponent();
            
            PlanAdapter adap = new PlanAdapter();
            var losPlanes = new List<Plan>();
            losPlanes = adap.GetAll();
            foreach (Plan element in losPlanes)
            {
                cbIDPlan.Items.Add(element.ID.ToString());
            }
        }
        public MateriaDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public MateriaDesktop (int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            MateriaLogic matLogic = new MateriaLogic();
            MateriaActual = matLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.MateriaActual = new Materia();
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.ID = Convert.ToInt32(this.txtIDMateria.Text);
            }
            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            this.MateriaActual.IDPlan = Convert.ToInt32(this.cbIDPlan.Text);

            if (this.Modo == ModoForm.Alta)
            {
                this.MateriaActual.State = BusinessEntities.States.New;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.State = BusinessEntities.States.Modified;
            }

        }
        public override void MapearDeDatos()
        {
            this.txtIDMateria.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cbIDPlan.SelectedItem = this.MateriaActual.IDPlan.ToString();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtIDMateria.Enabled = false;
                this.txtDescripcion.Enabled = false;
                this.txtHsSemanales.Enabled = false;
                this.txtHsTotales.Enabled = false;
                this.cbIDPlan.Enabled = false;
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic matLogic = new MateriaLogic();
            if (this.Modo == ModoForm.Baja)
            {
                matLogic.Delete(MateriaActual.ID);
            }
            else
            {
                matLogic.Save(MateriaActual);
            }
        }
        public override bool Validar()
        {
            bool val1;

            val1 = this.txtDescripcion.Text != String.Empty &&
                this.txtHsSemanales.Text != String.Empty &&
                this.txtHsTotales.Text != String.Empty &&
                this.cbIDPlan.Text != String.Empty;
            int a = 2;
            if (this.txtHsSemanales.Text == "")
            {
                Notificar("Horas semanales vacías", "Las horas semanales deben ser cargadas.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (this.txtHsTotales.Text == "")
            {
                Notificar("Horas totales vacías", "Las horas totales deben ser cargadas.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (Convert.ToInt32(this.txtHsSemanales.Text) > Convert.ToInt32(this.txtHsTotales.Text))
            {
                Notificar("Horas incorrectas", "Las horas semanales deben ser menores a las totales.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (!Int32.TryParse(this.txtHsSemanales.Text, out a) || !Int32.TryParse(this.txtHsTotales.Text, out a) || Convert.ToInt32(this.txtHsSemanales.Text) < 0 || Convert.ToInt32(this.txtHsTotales.Text) < 0)
            {
                Notificar("Horas invalidas", "Las horas deben ser enteros mayores a 0.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            if (val1 == false)
            {
                Notificar("Campos incompletos", "No todos los campos requeridos fueron completados. Por favor, intente nuevamente.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else
            {
                return true;
            }
           
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
