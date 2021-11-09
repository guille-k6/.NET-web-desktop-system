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
using System.Text.RegularExpressions;
using Data.Database;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
            cbxTipoPersona.Items.Add(Business.Entities.Personas.TiposPersonas.alumno);
            cbxTipoPersona.Items.Add(Business.Entities.Personas.TiposPersonas.docente);
            cbxTipoPersona.Items.Add(Business.Entities.Personas.TiposPersonas.usuario);

            PlanAdapter adap = new PlanAdapter();
            var losPlanes = new List<Plan>();
            losPlanes = adap.GetAll();
            foreach (Plan element in losPlanes)
            {
                cbxPlan.Items.Add(element.ID.ToString());
            }
        }
        public PersonaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            var Per = new PersonaLogic();
            var User = new UsuarioLogic();
            this.PersonaActual = Per.GetOne(ID);
            this.UsuarioActual = User.GetOne(ID);
            this.MapearDeDatos();
        }

        public Business.Entities.Personas PersonaActual { get; set; }
        public Business.Entities.Usuario UsuarioActual { get; set; }

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.cbxPlan.SelectedItem = this.PersonaActual.IDPlan.ToString();
            this.cbxTipoPersona.SelectedItem = this.PersonaActual.TipoPersona;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtFecha.Text = this.PersonaActual.FechaNacimiento.ToString();
            // llenamos los datos de la persona aca arriba.
            this.txtNombreUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.chBHabilitado.Checked = this.UsuarioActual.Habilitado;
            // aca llenamos los datos del usuario.

            if ((this.Modo.Equals("Alta")) || (this.Modo.Equals("Modificacion")))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtApellido.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtEmail.Enabled = false;
                this.cbxPlan.Enabled = false;
                this.cbxTipoPersona.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.txtLegajo.Enabled = false;
                this.txtFecha.Enabled = false;
                this.txtNombreUsuario.Enabled = false;
                this.chBHabilitado.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
            }
            else if (this.Modo.Equals("Consulta"))
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.PersonaActual = new Business.Entities.Personas();
                this.UsuarioActual = new Business.Entities.Usuario();
            }
            if ((this.Modo == ModoForm.Alta) || (this.Modo == ModoForm.Modificacion))
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    this.txtID.Text = this.PersonaActual.ID.ToString();
                }

                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.IDPlan = Convert.ToInt32(this.cbxPlan.SelectedItem);
                this.PersonaActual.TipoPersona = (Business.Entities.Personas.TiposPersonas)(this.cbxTipoPersona.SelectedIndex + 1);
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                this.PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFecha.Text);
                //arriba la persona, abajo el ususario.
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.NombreUsuario = this.txtNombreUsuario.Text;
                this.UsuarioActual.Habilitado = this.chBHabilitado.Checked;
                this.UsuarioActual.IDPersona = this.PersonaActual.ID;

            }
            if (this.Modo == ModoForm.Alta)
            {
                this.PersonaActual.State = (Business.Entities.BusinessEntities.States.New);
                this.UsuarioActual.State = (Business.Entities.BusinessEntities.States.New);
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.State = (Business.Entities.BusinessEntities.States.Modified);
                this.UsuarioActual.State = (Business.Entities.BusinessEntities.States.Modified);
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            var perLogic = new PersonaLogic();
            var usuLogic = new UsuarioLogic();
            if (this.Modo == ModoForm.Baja)
            {
                usuLogic.Delete(PersonaActual.ID);
                perLogic.Delete(PersonaActual.ID);
            }
            else
            {
                perLogic.Save(PersonaActual);
                UsuarioActual.IDPersona = PersonaActual.ID;
                usuLogic.Save(UsuarioActual);
            }
        }
        public override bool Validar()
        {
            bool val1/*correo*/,
                val2/*campos vacios*/,
                val3/*telefono > 10 lenght*/,
                val5/*valida formato de fecha*/,
                val6/*se fija que el usuario el correo y la contra sea mas de 8 chares*/,
                val7/*se fija que coincidan las claves*/;

            // Valida si el correo es valido

            String expresion; // expresion para correos
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
                && this.txtDireccion.Text != String.Empty
                && this.txtLegajo.Text != String.Empty
                && this.txtFecha.Text != String.Empty
                && this.cbxPlan.Text != String.Empty
                && this.cbxTipoPersona.Text != String.Empty
                && this.txtNombreUsuario.Text != String.Empty
                && this.txtClave.Text != String.Empty
                && this.txtConfirmarClave.Text != String.Empty;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                val2 = this.txtApellido.Text != String.Empty
                && this.txtNombre.Text != String.Empty
                && this.txtDireccion.Text != String.Empty
                && this.txtLegajo.Text != String.Empty
                && this.txtFecha.Text != String.Empty
                && this.cbxPlan.Text != String.Empty
                && this.cbxTipoPersona.Text != String.Empty
                && this.txtEmail.Text != String.Empty;
            }
            else { val2 = true; }

            // llamar val3 a la verificación del teléfono

            if (this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.Alta)
            {
                if(this.txtTelefono.Text.Length < 10)
                {
                    val3 = false;
                }
                else
                {
                    val3 = true;
                }
                
            }
            else
            {
                val3 = true;
            }

            if (this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.Alta)
            {
                //this.PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFecha.Text);               
                DateTime temp;
                if (DateTime.TryParse(txtFecha.Text, out temp))
                {
                    val5 = true;
                }
                else
                {
                    val5 = false;
                }
            }
            else
            {
                val5 = true;
            }


            if ((this.txtClave.Text != String.Empty) && (this.txtConfirmarClave.Text != String.Empty) && (this.Modo == ModoForm.Modificacion))
            {
                val6 = this.txtClave.Text.Length >= 8
                    && this.txtNombreUsuario.Text.Length >= 8
                    && this.txtEmail.Text.Length >= 8;
            }

            else if (this.Modo == ModoForm.Alta)
            {
                val6 = this.txtClave.Text.Length >= 8
                    && this.txtNombreUsuario.Text.Length >= 8
                    && this.txtEmail.Text.Length >= 8;
            }
            else
            {
                val6 = true;
            }
            int a = 2;
            if (!Int32.TryParse(this.txtLegajo.Text, out a) && this.txtLegajo.Text != "")
            {
                Notificar("Legajo inválido.", "El legajo debe ser un numero entero.", (MessageBoxButtons)0, (MessageBoxIcon)48);
                return false;
            }

            val7 = this.txtClave.Text.Equals(this.txtConfirmarClave.Text);

            if ((val1 == false) || (val2 == false) || (val3 == false) || (val5 == false) || (val6 == false) || (val7 == false))
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
                    Notificar("Campos incorrectos", "Recuerde que su numero de telefono debe tener más de 8 caracteres. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val5 == false)
                {
                    Notificar("Campos incorrectos", "Recuerde que su fecha de nacimiento debe ir en el formato DD/MM/AAAA", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val6 == false)
                {
                    Notificar("Campos incorrectos", "Recuerde que la clave, su usuario y su correo deben tener más de 9 caracteres. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                else if (val7 == false)
                {
                    Notificar("Clave incorrecta", "La clave ingresada no coincide con su confirmación. Por favor, intente nuevamente", (MessageBoxButtons)0, (MessageBoxIcon)48);
                }
                return false;
            }
            else 
            { 
                return true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
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
            Close();
        }

        private void cbxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
