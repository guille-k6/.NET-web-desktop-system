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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic espLogic = new EspecialidadLogic();
            EspecialidadActual = espLogic.GetOne(ID);
            this.MapearDeDatos();
        }


        public Especialidad EspecialidadActual { get; set; }
        public override void MapearDeDatos() 
        {
            this.txtIDEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescEspecialidad.Text = this.EspecialidadActual.Descripcion;

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtIDEspecialidad.Enabled = false;
                this.txtDescEspecialidad.Enabled = false;
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
                this.EspecialidadActual.State = BusinessEntities.States.New;
            }
            else if(this.Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.State = BusinessEntities.States.Modified;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.Descripcion = this.txtDescEspecialidad.Text;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            //EspecialidadLogic espLogic = new EspecialidadLogic();
            //espLogic.Save(EspecialidadActual);

            // Por qué es necesario generar un nuevo usuario logic?
            EspecialidadLogic espLogic = new EspecialidadLogic();
            if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    espLogic.Delete(EspecialidadActual.ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
                }
            }
            else
            {
                try
                {
                    espLogic.Save(EspecialidadActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
                }
            }
        }
        public override bool Validar() 
        {
            bool val1;

            // Valida que los textbox no estén vacios

            val1 = this.txtDescEspecialidad.Text != String.Empty;

            if (val1 == false)
            {
                Notificar("Campos incompletos", "No todos los campos requeridos fueron completados. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
            this.Close();
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
