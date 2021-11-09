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
    public partial class ModuloDesktop : ApplicationForm
    {
        public Modulo ModuloActual { get; set; }
        public ModuloDesktop()
        {
            InitializeComponent();
        }
        public ModuloDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public ModuloDesktop(ModoForm modo, int ID) : this()
        {
            ModuloLogic modLogic = new ModuloLogic();
            this.Modo = modo;
            this.ModuloActual = modLogic.GetOne(ID);
            this.MapearDeDatos();
        }
        private void ModuloDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtIdModulo.Text = ModuloActual.ID.ToString();
            this.txtDescripcion.Text = ModuloActual.Descripcion;
            this.txtEjecuta.Text = ModuloActual.Ejecuta;

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
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
                    this.ModuloActual = new Business.Entities.Modulo();
                }
                //else if (this.Modo == ModoForm.Modificacion)
                //{
                //    PlanActual.ID = Convert.ToInt32(this.txtIDEspecialidad.Text);
                //}

                this.ModuloActual.Descripcion = this.txtDescripcion.Text;
                this.ModuloActual.Ejecuta = this.txtEjecuta.Text;

                if (this.Modo == ModoForm.Alta)
                {
                    this.ModuloActual.State = BusinessEntities.States.New;
                }
                else if (this.Modo == ModoForm.Modificacion)
                {
                    this.ModuloActual.State = BusinessEntities.States.Modified;
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloLogic plnLogic = new ModuloLogic();
            if (this.Modo == ModoForm.Baja)
            {
                plnLogic.Delete(ModuloActual.ID);
            }
            else
            {
                plnLogic.Save(ModuloActual);
            }
        }
        public override bool Validar()
        {
            bool val1;

            val1 = txtDescripcion.Text != String.Empty
                && txtEjecuta.Text != String.Empty;

            return val1;
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
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
