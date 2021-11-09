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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            var User = new UsuarioLogic();
            try
            {
                this.UsuarioActual = User.GetOne(ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
            }
            
            this.MapearDeDatos();
        }
        public UsuarioDesktop(ModoForm modo, int IDPersona, string NombrePer, string ApellidoPer, string MailPer) //: this()
        {
            this.Modo = modo;

            this.UsuarioActual = new Business.Entities.Usuario();
            this.UsuarioActual.IDPersona = IDPersona;

            this.txtNombre.Text = NombrePer;
            this.UsuarioActual.Apellido = ApellidoPer;
            this.UsuarioActual.EMail = MailPer;
        }

        public Business.Entities.Usuario UsuarioActual { get; set; }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            if ((this.Modo.Equals("Alta")) || (this.Modo.Equals("Modificacion")))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtApellido.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtUsuario.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
                this.txtEmail.Enabled = false;
                this.chkHabilitado.Enabled = false;
            }
            else if (this.Modo.Equals("Consulta"))
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos() 
        {
            //if (this.Modo == ModoForm.Alta)
            //{
            //    //this.UsuarioActual = new Business.Entities.Usuario();

            //}
            if ((this.Modo == ModoForm.Alta) || (this.Modo == ModoForm.Modificacion))
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    this.txtID.Text = this.UsuarioActual.ID.ToString();
                }

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;

            }
            if (this.Modo == ModoForm.Alta)
            {
                this.UsuarioActual.State = (Business.Entities.BusinessEntities.States.New);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.State = (Business.Entities.BusinessEntities.States.Modified);
            }

        }
        public override void GuardarCambios() 
        {
            MapearADatos();

            var UserLogic = new UsuarioLogic();
            if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    UserLogic.Delete(UsuarioActual.ID);
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
                    UserLogic.Save(UsuarioActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.ToString());
                }
            }
            

        }
        public override bool Validar() 
        {
            bool val1, val2, val3, val4;

            // Valida si el correo es valido

            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(this.txtEmail.Text, expresion))
            {
                if (Regex.Replace(this.txtEmail.Text, expresion, String.Empty).Length == 0)
                {
                    val1 = true;
                }
                else
                {
                    val1 = false;
                }
            }
            else
            {
                val1 = false;
            }

            // Valida que los textbox no estén vacios

            

            if (this.Modo == ModoForm.Alta)
            {
                val2 = this.txtApellido.Text != String.Empty
                && this.txtNombre.Text != String.Empty
                && this.txtEmail.Text != String.Empty
                && this.txtClave.Text != String.Empty
                && this.txtConfirmarClave.Text != String.Empty
                && this.txtUsuario.Text != String.Empty;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                val2 = this.txtApellido.Text != String.Empty
                && this.txtNombre.Text != String.Empty
                && this.txtEmail.Text != String.Empty
                && this.txtUsuario.Text != String.Empty;
            }
            else { val2 = true; }
            

            // Valida que la clave coincida con la confirmacion

            val3 = this.txtClave.Text.Equals(this.txtConfirmarClave.Text);

            // Valida que los campos tengan al menos 8 caracteres

            if ((this.txtClave.Text != String.Empty) && (this.txtConfirmarClave.Text != String.Empty) && (this.Modo == ModoForm.Modificacion))
            {
                val4 = this.txtClave.Text.Length >= 8
                    && this.txtUsuario.Text.Length >= 8
                    && this.txtEmail.Text.Length >= 8;
            }
                
            else if (this.Modo == ModoForm.Alta)
            {
                val4 = this.txtClave.Text.Length >= 8
                    && this.txtUsuario.Text.Length >= 8
                    && this.txtEmail.Text.Length >= 8;
            } 
            else 
            {
                val4 = true; 
            }

                if ((val1 == false) || (val2 == false) || (val3 == false) || (val4 == false))
            {
                if (val2 == false)
                {
                    Notificar("Campos incompletos", "No todos los campos requeridos fueron completados. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val1 == false)
                {
                    Notificar("Correo inválido", "El correo ingresado no es correcto. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val3 == false)
                {
                    Notificar("Clave incorrecta", "La clave ingresada no coincide con su confirmación. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val4 == false)
                {
                    Notificar("Campos incorrectos", "Recuerde que la clave, su usuario y su correo deben tener más de 8 caracteres. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                return false;
            }
            else { return true; }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            // Es el metodo close? En el punto 20 parte 2 del apunte TP2 L04 no está claro
            Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
