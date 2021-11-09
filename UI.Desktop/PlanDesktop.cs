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
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
            EspecialidadAdapter adap = new EspecialidadAdapter();
            var lasEspe = new List<Especialidad>();
            lasEspe = adap.GetAll();
            foreach (Especialidad element in lasEspe)
            {
                cbIDEspecialidad.Items.Add(element.ID.ToString());
            }
        }

        public Business.Entities.Plan PlanActual { get; set; }

        public PlanDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
            
        }
        public PlanDesktop (int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic plnLogic = new PlanLogic();
            this.PlanActual = plnLogic.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIDPlan.Text = PlanActual.ID.ToString();
            this.txtDescripcion.Text = PlanActual.Descripcion;
            this.cbIDEspecialidad.SelectedItem = PlanActual.IDEspecialidad.ToString();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.cbIDEspecialidad.Enabled = false;
                this.txtDescripcion.Enabled = false;
                this.btnAceptar.Text = "Eliminar";
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    this.PlanActual = new Business.Entities.Plan();
                }
                //else if (this.Modo == ModoForm.Modificacion)
                //{
                //    PlanActual.ID = Convert.ToInt32(this.txtIDEspecialidad.Text);
                //}

                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = Convert.ToInt32(this.cbIDEspecialidad.Text);

                if (this.Modo == ModoForm.Alta)
                {
                    this.PlanActual.State = BusinessEntities.States.New;
                }
                else if (this.Modo == ModoForm.Modificacion)
                {
                    this.PlanActual.State = BusinessEntities.States.Modified;
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic plnLogic = new PlanLogic();
            if (this.Modo == ModoForm.Baja)
            {
                plnLogic.Delete(PlanActual.ID);
            }
            else
            {
                plnLogic.Save(PlanActual);
            }
        }
        public override bool Validar()
        {
            bool val1;

            val1 = this.txtDescripcion.Text != String.Empty && 
                   this.cbIDEspecialidad.Text != String.Empty;
                
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

        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIDEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
