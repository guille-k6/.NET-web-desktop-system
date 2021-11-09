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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        public ModuloUsuario ModuloUsuarioActual { get; set; }
        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }
        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            var modLogic = new ModuloUsuarioLogic();
            this.ModuloUsuarioActual = modLogic.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    this.ModuloUsuarioActual = new Business.Entities.ModuloUsuario();
                }

                this.ModuloUsuarioActual.IdModulo = Convert.ToInt32(this.txtIDModulo.Text);
                this.ModuloUsuarioActual.IdUsuario = Convert.ToInt32(this.txtIDUsuario.Text);
                this.ModuloUsuarioActual.PermiteAlta = this.cbAlta.Checked;
                this.ModuloUsuarioActual.PermiteBaja = this.cbBaja.Checked;
                this.ModuloUsuarioActual.PermiteModificacion = this.cbModificacion.Checked;
                this.ModuloUsuarioActual.PermiteConsulta = this.cbConsulta.Checked;

                if (this.Modo == ModoForm.Alta)
                {
                    this.ModuloUsuarioActual.State = BusinessEntities.States.New;
                }
                else if (this.Modo == ModoForm.Modificacion)
                {
                    this.ModuloUsuarioActual.State = BusinessEntities.States.Modified;
                }
            }
        }
        public override void MapearDeDatos()
        {
            this.txtIDModuloUsuario.Text = ModuloUsuarioActual.ID.ToString();
            this.txtIDModulo.Text = ModuloUsuarioActual.IdModulo.ToString();
            this.txtIDUsuario.Text = ModuloUsuarioActual.IdUsuario.ToString();
            this.cbAlta.Checked = ModuloUsuarioActual.PermiteAlta;
            this.cbBaja.Checked = ModuloUsuarioActual.PermiteBaja;
            this.cbModificacion.Checked = ModuloUsuarioActual.PermiteModificacion;
            this.cbConsulta.Checked = ModuloUsuarioActual.PermiteConsulta;

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.txtIDModulo.Enabled = false;
                this.txtIDUsuario.Enabled = false;
                this.cbAlta.Enabled = false;
                this.cbBaja.Enabled = false;
                this.cbModificacion.Enabled = false;
                this.cbConsulta.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ModuloUsuarioLogic modLogic = new ModuloUsuarioLogic();
            modLogic.Save(ModuloUsuarioActual);
        }
        public override bool Validar()
        {
            bool val1;

            val1 = txtIDModulo.Text != String.Empty
                && txtIDUsuario.Text != String.Empty;

            return val1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ModuloUsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
