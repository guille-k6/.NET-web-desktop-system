using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class LogInAlumno : System.Web.UI.Page
    {
        PersonaLogic _perLogic;
        UsuarioLogic _logic;
        private PersonaLogic perLogic
        {
            get
            {
                if (_perLogic == null)
                {
                    _perLogic = new PersonaLogic();
                }
                return _perLogic;
            }
        }
        private UsuarioLogic usuLogic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
        Usuario UsuarioActual { get; set; }
        Personas PersonaActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ingresarButton_Click(object sender, EventArgs e)
        {
            UsuarioActual = usuLogic.GetbyNomUsuario(nomUsuTextBox.Text);
            if(UsuarioActual.IDPersona != 0)
            {
                PersonaActual = perLogic.GetOne(UsuarioActual.IDPersona);
            }

            //valido nombre d eusuario y contraseña
            if (this.passTextBox.Text == UsuarioActual.Clave && PersonaActual.TipoPersona == Personas.TiposPersonas.alumno)
            {
                Session["IDPerAlu"] = PersonaActual.ID;
                Response.Redirect("~/InscripcionAlumnos.aspx");
            }
            else if (this.passTextBox.Text == UsuarioActual.Clave && PersonaActual.TipoPersona != Personas.TiposPersonas.alumno) 
            {
                Page.Response.Write("El usuario ingresado no pertenece a un alumno");
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrectos");
            }
        }
    }
}