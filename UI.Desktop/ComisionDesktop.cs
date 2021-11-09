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
    public partial class ComisionDesktop : ApplicationForm
    {
        public Comision ComisionActual { get; set; }
        public ComisionDesktop()
        {
            InitializeComponent();

            PlanAdapter PlanAdap = new PlanAdapter();
            var losPlanes = new List<Plan>();
            losPlanes = PlanAdap.GetAll();
            foreach (Plan element in losPlanes)
            {
                cbIDPlan.Items.Add(element.ID.ToString());
            }
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic comLogic = new ComisionLogic();
            this.ComisionActual = comLogic.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos() 
        {
            this.txtIDComision.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cbIDPlan.SelectedItem = this.ComisionActual.IDPlan.ToString();
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.txtDescripcion.Enabled = false;
                this.txtAnioEspecialidad.Enabled = false;
                this.cbIDPlan.Enabled = false;
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.ComisionActual = new Comision();
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.ID = Convert.ToInt32(this.txtIDComision.Text);
            }
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
            this.ComisionActual.IDPlan = Convert.ToInt32(this.cbIDPlan.Text);

            if (this.Modo == ModoForm.Alta)
            {
                this.ComisionActual.State = BusinessEntities.States.New;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.State = BusinessEntities.States.Modified;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            ComisionLogic comLogic = new ComisionLogic();
            if (this.Modo == ModoForm.Baja)
            {
                comLogic.Delete(ComisionActual.ID);
            }
            else
            {
                comLogic.Save(ComisionActual);
            }
        }
        public override bool Validar() 
        {
            bool val1;

            val1 = this.cbIDPlan.Text != String.Empty &&
                this.txtDescripcion.Text != String.Empty &&
                this.txtAnioEspecialidad.Text != String.Empty;
            int a = 2;
            if (this.txtAnioEspecialidad.Text == "")
            {
                Notificar("Año vacío", "El año debe ser cargado.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else if (!Int32.TryParse(this.txtAnioEspecialidad.Text, out a) || Convert.ToInt32(this.txtAnioEspecialidad.Text) > 2100 || Convert.ToInt32(this.txtAnioEspecialidad.Text) < 1900)
            {
                Notificar("Año inválido", "El año debe ser entero entre 1900 y 2100", (MessageBoxButtons)0, (MessageBoxIcon)48);
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

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }
            else if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
